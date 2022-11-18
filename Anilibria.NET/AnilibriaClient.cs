using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Anilibria.NET.Models;
using Anilibria.NET.Models.TitleModel;

namespace Anilibria.NET
{
    /// <summary>
    /// Anilibria client
    /// </summary>
    public class AnilibriaClient : IDisposable
    {
        #region Client

        /// <summary>
        /// Http AnilibriaClient
        /// Use it to send GET methods
        /// </summary>
        internal readonly HttpClient HttpClient = new HttpClient();

        #endregion

        public AnilibriaClient()
        {

        }

        public void Dispose() => HttpClient.Dispose();
    }
}