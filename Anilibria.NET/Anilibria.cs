using Anilibria.NET.Models.Title;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anilibria.NET
{
    public static class Anilibria
    {
        internal static HttpClient HttpClient = new HttpClient();

        public static Task<Title> GetTitleAsync(int id) =>
            Utilities.GetData<Title>(HttpClient, Urls.GetTitleUri(id).AbsoluteUri);

        public static Task<Title> GetTitleAsync(string code) =>
            Utilities.GetData<Title>(HttpClient, Urls.GetTitleUri(code).AbsoluteUri);

        public static Task<Title[]> GetTitlesAsync(string[] codes) =>
            Utilities.GetData<Title[]>(HttpClient, Urls.GetTitlesUri(codes).AbsoluteUri);

    }
}
