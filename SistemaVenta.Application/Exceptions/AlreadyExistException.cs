using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVenta.Application.Exceptions
{
    public class AlreadyExistException : ApplicationException
    {
        public AlreadyExistException()
        {
            
        }
        public AlreadyExistException(string name) : base($"El resgistro {name}  ya existe")
        {
            
        }

        public AlreadyExistException(string[] elements ): base($"Uno de los siguientes elementos ya esta registrado [{string.Join(',',elements)}]")
        {
            
        }
    }
}
