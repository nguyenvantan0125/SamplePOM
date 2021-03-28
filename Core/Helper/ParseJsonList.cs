using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit.Sdk;


namespace Core.Helper
{

    public class ParseJsonList : DataAttribute
    {
        private  string _filePath;
        private  string _propertyName;
        private Validation _validation = new Validation();
        /// <summary>
        /// Load data from a JSON file as the data source for a theory
        /// </summary>
        /// <param name="filePath">The absolute or relative path to the JSON file to load</param>
        public ParseJsonList(string filePath)
            : this(filePath, null)
        {
        }

        /// <summary>
        /// Load data from a JSON file as the data source for a theory
        /// </summary>
        /// <param name="filePath">The absolute or relative path to the JSON file to load</param>
        /// <param name="propertyName">The name of the property on the JSON file that contains the data for the test</param>
        public ParseJsonList(string filePath, string propertyName)
        {
            _filePath = filePath;
            _propertyName = propertyName;
        }

        /// <inheritDoc />
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            if (testMethod == null)
            {
                throw new ArgumentNullException(nameof(testMethod));
            }

            // Validate and get data from json files
            _validation.ValidateFile(this._filePath);
            _validation.ValidateFileEmpty(this._filePath);

            string fileData = File.ReadAllText(this._filePath);

            // Not have property
            if (string.IsNullOrEmpty(_propertyName))                
                return JsonConvert.DeserializeObject<List<object[]>>(fileData);

            //Only use the specified property as the data
            var allData = JObject.Parse(fileData);
            var data = allData[_propertyName];

            return data.ToObject<List<object[]>>();
        }
    }
}


