using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App02
{
    interface ILog
    {
        void Write(string message);
        //Task WriteAsync(string message);
    }
}
