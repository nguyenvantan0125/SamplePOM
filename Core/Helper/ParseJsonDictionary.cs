using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using System.Reflection;
using Newtonsoft.Json.Linq;
using Xunit.Sdk;

namespace Core.Helper
{
    public class ParseJsonDictionary : DataAttribute
    {
        private string _filePath;
        private readonly string _propertyName;
        private Validation _validation = new Validation();

        /// <summary>
        /// Load data from a JSON file as the data source for a theory
        /// </summary>
        /// <param name="filePath">The absolute or relative path to the JSON file to load</param>
        public ParseJsonDictionary(string filePath)
            : this(filePath, null)
        {
        }
        public ParseJsonDictionary(string filePath, string propertyName)
        {
            _filePath = filePath;
            _propertyName = propertyName;
        }

        // convert LIST DICTIONARY TO LIST OBJECT        
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            if (testMethod == null)
            {
                throw new ArgumentNullException(nameof(testMethod));
            }

            // Validate and get data from json
            _validation.ValidateFile(this._filePath);
            _validation.ValidateFileEmpty(this._filePath);
            string fileData = File.ReadAllText(this._filePath);
            
            // Not have property 
            if(string.IsNullOrEmpty(_propertyName))
                return JsonTool.GetDictionaryToObject(fileData);

            // Have property
            string dataObject = JsonTool.GetPropertyValue(fileData,_propertyName);
            return JsonTool.GetDictionaryToObject(dataObject.ToString());
        }
    }
}
