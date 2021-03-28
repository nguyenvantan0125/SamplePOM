using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Helper
{
    class Validation
    {
        public void ValidateFile(string filepath)
        {
            var path = Path.IsPathRooted(filepath)
                ? filepath
                : Path.GetRelativePath(Directory.GetCurrentDirectory(), filepath);

            if (!File.Exists(path))
            {
                throw new ArgumentException($"Could not find file at path: {path}");
            }         
        }

        public void ValidateFileEmpty(string pathfile)
        {
            string datafile = File.ReadAllText(pathfile);
            if (string.IsNullOrEmpty(datafile))
            {
                throw new ArgumentException("$File is EMPTY");
            }          
        }
    }
}
