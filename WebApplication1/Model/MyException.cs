using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Model
{
    public class MyException : Exception{
        public int i { get; internal set; }

        public MyException(String s, int intin) : base(s)  {
            i = intin;
        }
    }
}

