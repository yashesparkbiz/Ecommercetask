using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommercetask.Data.Model
{
    public class InvalidException : Exception
    {
        public InvalidException(string message) : base(message)
        {

        }
    }

    public class Error
    {
        public string Message { get; set; }
        public string Code { get; set; }
        public string Path { get; set; }
    }
}
