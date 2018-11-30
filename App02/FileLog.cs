using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace App02
{
    class FileLog : ILog
    {
        public void Write(string message)
        {
            var s = $"{DateTime.Now:s} {message} {Environment.NewLine}";

            File.AppendAllText("log.txt", s);
        }

        public Task WriteAsync(string message)
        {
            throw new NotImplementedException();
        }
    }
}
