using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover2.Exceptions
{
    [Serializable]
    public class InvalidDirectionException : Exception
    {
        public InvalidDirectionException() : base(String.Format("Invalid Direction!"))
        {

        }
    }
}
