using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace HyundaiCompany.MVC
{
    public static class GlobalFile
    {
        public static HttpClient Client = new HttpClient();
        static GlobalFile()
        {
            Client.BaseAddress = new Uri("http://localhost:60850/api/");
            Client.DefaultRequestHeaders.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}