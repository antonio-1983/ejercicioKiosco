using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioKiosco.Exceptions
{
    public class CompraRechazadaException : Exception
    {
        public CompraRechazadaException(string message)
        : base(message) { }

    }
}
