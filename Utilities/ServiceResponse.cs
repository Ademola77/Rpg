using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rpg.Utilities
{
    public class ServiceResponse<T> where T:class
    {
        public T Data { get; set; }
        public bool IsSuccessful { get; set; } =true;
        public string Message { get; set; }=null;
    }
}