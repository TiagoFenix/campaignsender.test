using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fenix.ESender.Models
{
    public class BaseResponse
    {
        public List<string> errors
        {
            get
            {
                if (_errors == null)
                    _errors = new List<string>();
                return _errors;
            }
            set
            {
                _errors = value;
            }
        }
        private List<string> _errors;
    }
}
