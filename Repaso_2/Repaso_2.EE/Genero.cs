using Repaso_2.Utilities.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repaso_2.EE
{
    public class Genero
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Nombre { get; set; }
        [NoQuery]
        public DateTime Fecha_reg { get; set; }
    }
}
