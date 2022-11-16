using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Anilibria.NET.Models;

namespace Anilibria.NET
{
    /// <summary>
    /// Anilibria client
    /// </summary>
    public class Client : IDisposable
    {
        #region Client

        /// <summary>
        /// Http Client
        /// Use it to send GET methods
        /// </summary>
        private readonly HttpClient _httpClient = new HttpClient();

        #endregion

        public Client()
        {

        }



        public void Dispose() => _httpClient.Dispose();
    }
}