using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.UI.Settings
{
    /// <summary>
    /// Interface for <see cref="Settings"/>
    /// </summary>
    public interface ISettings
    {
        /// <summary>
        /// Loads settings of a specific section into a settings object
        /// </summary>
        /// <param name="sectionName">The settings section to load</param>
        /// <returns>A settings object as <see cref="T"/></returns>
        T GetSection<T>(string sectionName);
    }
}
