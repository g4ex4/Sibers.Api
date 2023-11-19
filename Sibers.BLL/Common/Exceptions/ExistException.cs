using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibers.BLL.Common.Exceptions
{
    public class ExistException : Exception
    {
        public ExistException(string name, object key)
            : base($"Entity \"{name}\" with key ({key}) is exist.") { }
    }
}
