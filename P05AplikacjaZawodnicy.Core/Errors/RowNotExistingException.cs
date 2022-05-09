using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05AplikacjaZawodnicy.Core.Errors
{
    public class RowNotExistingException : Exception
    {
        public RowNotExistingException(string msg) : base(msg)
        {
            
        }
    }
}
