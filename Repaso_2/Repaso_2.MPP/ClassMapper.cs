using Repaso_2.Contracts.ClassMapper;
using Repaso_2.Utilities.Attributes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Repaso_2.MPP
{
    public class ClassMapper<T> : IClassMapper<T>
    {
        public List<T> Map(DataSet dataSet)
        {
            List<T> result = new List<T>();

            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                object instance = Activator.CreateInstance(typeof(T));
                var properties = instance.GetType().GetProperties();

                foreach (var prop in properties)
                {
                    if (prop.GetCustomAttributes().Any(p => p.GetType() == typeof(NoQueryAttribute)))
                    {
                        continue;
                    }

                    object col = GetRowValues(prop, row);
                    prop.SetValue(instance, col);
                }

                result.Add((T)instance);
            }
            return result;
        }

        private object GetRowValues(PropertyInfo prop, DataRow row)
        {
            try
            {
                object result = row[prop.Name];

                if (result == DBNull.Value)
                {
                    return null;
                }

                return result;
            }
            catch (Exception)
            {

                if (prop.GetType().IsValueType)
                {
                    return Activator.CreateInstance(prop.GetType());
                }

                return null;
            }
        }
    }
}
