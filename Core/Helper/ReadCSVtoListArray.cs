using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Xunit.Sdk;

namespace Core.Helper
{
    public class ReadCSVtoListArray : DataAttribute
    {
        private string _filePath;
        public ReadCSVtoListArray(string filePath)          
        {
            this._filePath = filePath;
        }
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            List<object[]> result = new List<object[]>();

            using (var reader = new StreamReader(this._filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    object[] liststring = line.Split(',').ToArray(); // split , in csv                         
                    result.Add(liststring);
                }
                return result;
            }
        }
    }
}
