﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using RecipeApp.UI.WPF.Models;

namespace RecipeApp.UI.WPF.Services
{
    public interface IHttpClientService
    {
        Task<T> GetAsync<T>(Request request);

        Task Post(Request request);

        Task Put(Request request);

        Task Delete(Request request);
    }
}
