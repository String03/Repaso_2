using Repaso_2.Utilities.Attributes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Repaso_2.Utilities.Extensions
{
    public static class RepositoryExtensions
    {
        public static string GetColumnValues(this Type type)
        {
            try
            {
                var result = type
                    .GetProperties()
                    .Where(x => IsNotNoQuery(x))
                    .Select(x => x.Name);
                return string.Join(",", result);
            }
            catch (Exception ex)
            {

                return "*";
            }
        }

        private static bool IsNotNoQuery(PropertyInfo x)
        {
            try
            {
                return !x.GetCustomAttributes().Any(p => p.GetType() == typeof(NoQueryAttribute));
            }
            catch (Exception)
            {

                return false;
            }
        }

        public static string GetInsertColumn(this Type type)
        {
            try
            {
                var result = type
                    .GetProperties()
                    .Where(x => IsNotNoQuery(x) && !IsPrimaryKey(x))
                    .Select(p => p.Name);
                return string.Join(",", result);
            }
            catch (Exception)
            {

                return null;
            }
        }

        private static bool IsPrimaryKey(PropertyInfo x)
        {
            try
            {
                return x.GetCustomAttributes().Any(p => p.GetType() == typeof(PrimaryKeyAttribute));
            }
            catch (Exception)
            {

                return true;
            }
        }

        public static string GetInsertColumnValue(this object obj)
        {
            try
            {
                Type type = obj.GetType();
                var result = type
                    .GetProperties()
                    .Where(x => IsNotNoQuery(x) && !IsPrimaryKey(x))
                    .Select(p => 
                    {
                        object value = type.GetProperty(p.Name).GetValue(obj);
                        return CreateRightExpressionValue(value);
                    });
                return string.Join(",", result);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public static string GetPrimaryKeyComparation(this object obj)
        {
            try
            {
                Type type = obj.GetType();
                var result = type
                    .GetProperties()
                    .Where(IsPrimaryKey)
                    .Select(p => 
                    {
                        return CreateWhereExpression(p, obj);
                    });
                return string.Join(" AND ", result);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public static string GetUpdateColumnValues(this object obj)
        {
            try
            {
                Type type = obj.GetType();
                    
                var result = type
                    .GetProperties()
                    .Where(x => IsNotNoQuery(x) && !IsPrimaryKey(x))
                    .Select(p => 
                    {
                        object value = type.GetProperty(p.Name).GetValue(obj);
                        return p.Name + " = " + CreateRightExpressionValue(value);
                    });
                return string.Join(",", result);
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        private static object CreateWhereExpression(PropertyInfo p, object obj)
        {
            try
            {
                object value = obj.GetType().GetProperty(p.Name).GetValue(obj);
                return p.Name + CreateRightExpression(value);
            }
            catch (Exception)
            {

                return null;
            }
        }

        private static string CreateRightExpression(object value)
        {
            try
            {
                if (value.GetType() == typeof(Nullable))
                {
                    if (value == null)
                    {
                        return " IS NULL ";
                    }
                }

                return " = " + CreateRightExpressionValue(value);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static object CreateRightExpressionValue(object value)
        {
            try
            {
                if (value == null)
                {
                    return "NULL";
                }

                Type propertyType = value.GetType();

                IEnumerable<Type> intNumberType = new Type[]
                {
                    typeof(int),
                    typeof(short),
                    typeof(long)
                };

                IEnumerable<Type> decimalNumberType = new Type[]
                {
                    typeof(decimal),
                    typeof(double),
                    typeof(float)
                };

                if (intNumberType.Contains(propertyType))
                {
                    return Convert.ToInt64(value).ToString("0", CultureInfo.InvariantCulture);
                }

                else if (decimalNumberType.Contains(propertyType))
                {
                    return Convert.ToDecimal(value).ToString("0.00", CultureInfo.InvariantCulture);
                }

                else if (value.GetType() == typeof(DateTime))
                {
                    return "'" + ((DateTime)value).ToString("s", CultureInfo.InvariantCulture) + "'";
                }

                else if (value.GetType() == typeof(bool))
                {
                    return ((bool)value) ? "1" : "0";
                }

                else
                {
                    return $"'{value.ToString()}'";
                }
            }
            catch 
            {

                return "'0'";
            }
        }
    }
}
