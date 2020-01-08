using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.UI.WPF.Models
{
    /// <summary>
    /// Represents a http request
    /// </summary>
    public class Request
    {
        /// <summary>
        /// Gets or sets the request server url
        /// </summary>
        public string RequestUrl { get; set; }

        /// <summary>
        /// Gets or sets the request endpoint e.g. api/v1/resources 
        /// </summary>
        public string Endpoint { get; set; }

        /// <summary>
        /// Gets a list of query strings
        /// </summary>
        public IEnumerable<QueryString> QueryStrings { get; set; }

        /// <summary>
        /// Gets or sets the method of the request
        /// </summary>
        public HttpMethod Method { get; set; }

        /// <summary>
        /// Gets or sets the body associated with a request
        /// </summary>
        public string Body { get; set; }
    }
}
