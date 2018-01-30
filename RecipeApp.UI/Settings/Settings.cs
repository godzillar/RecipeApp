using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Configuration;
using System.IO;
using System.Linq;

namespace RecipeApp.UI.Settings
{
    public class Settings: ISettings
    {
        private readonly string _appsettingsFile = ConfigurationManager.AppSettings["ApplicationSettings"];
        private string _appsettings;

        /// <summary>
        /// Load the settings into an settings object
        /// </summary>
        /// <param name="sectionNames">The section name(s) of the settings file to load into an object</param>
        /// <returns>An settings object as <see cref="T"/></returns>
        public T GetSection<T>(string sectionNames)
        {
            if (_appsettingsFile == null)
            {
                Console.WriteLine(@"ApplicationSettings file is not specified in app.config");
                return default(T);
            }

            // Get appsettings link, open it and read section
            // parse to T
            if (_appsettings == null)
            {
                try
                {
                    using (var streamReader = new StreamReader(_appsettingsFile))
                    {
                        _appsettings = streamReader.ReadToEnd();
                    }
                }
                catch (FileNotFoundException fnfex)
                {
                    Console.WriteLine(fnfex.Message);
                    return default(T);
                }
            }

            var obj = JObject.Parse(_appsettings);
            var sections = sectionNames.Split(':');
            var selectToken = string.Empty;
            for (var x = 0; x < sections.Length - 1; x++)
            {
                selectToken += $"{sections[x]}.";
            }

            selectToken += $"{sections[sections.Length-1]}";

            var section = obj.SelectToken(selectToken);

            return section == null ? default(T) : JsonConvert.DeserializeObject<T>(section.ToString());
        }
    }
}
