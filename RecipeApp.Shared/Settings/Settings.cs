using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace RecipeApp.Shared.Settings
{
    public class Settings: ISettings
    {
        private string _appsettings;
        private readonly string appSettingsFile;

        /// <summary>
        /// Initializes a new instance of the <see cref="Settings"/> class.
        /// </summary>
        /// <param name="appSettingsFile">The path and name of the app settings file.</param>
        public Settings(string appSettingsFile)
        {
            this.appSettingsFile = appSettingsFile;
        }

        /// <summary>
        /// Load the settings into an settings object
        /// </summary>
        /// <param name="sectionNames">The section name(s) of the settings file to load into an object</param>
        /// <returns>An settings object as <see cref="T"/></returns>
        public T GetSection<T>(string sectionNames) 
            where T: SettingsObject
        {
            if (appSettingsFile == null)
            {
                Console.WriteLine("ApplicationSettings file is not specified in app.config");
                return default;
            }

            // Get appsettings link, open it and read section
            // parse to T
            if (_appsettings == null)
            {
                try
                {
                    using (var streamReader = new StreamReader(appSettingsFile))
                    {
                        _appsettings = streamReader.ReadToEnd();
                    }
                }
                catch (FileNotFoundException fnfex)
                {
                    Console.WriteLine(fnfex.Message);
                    return default;
                }
            }

            var obj = JObject.Parse(_appsettings);
            var sections = sectionNames.Split(':');
            var selectToken = string.Empty;
            for (var x = 0; x < sections.Length - 1; x++)
            {
                selectToken += $"{sections[x]}.";
            }

            selectToken += $"{sections[^1]}";

            var section = obj.SelectToken(selectToken);

            return section == null ? default : JsonConvert.DeserializeObject<T>(section.ToString());
        }
    }
}
