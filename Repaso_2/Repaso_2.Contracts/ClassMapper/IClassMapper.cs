using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repaso_2.Contracts.ClassMapper
{
    public interface IClassMapper<T>
    {
        List<T> Map(DataSet dataSet);
    }
}
