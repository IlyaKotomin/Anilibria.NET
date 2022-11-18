using Anilibria.NET.Models;
using Anilibria.NET.Models.TitleModel;
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

        public static Task<Title[]> GetTitlesAsync(int[] ids) =>
            Utilities.GetData<Title[]>(HttpClient, Urls.GetTitlesUri(ids).AbsoluteUri);

        public static Task<Title[]> GetTitlesUpdatesAsync(int limit = 5, int after = 0) =>
            Utilities.GetData<Title[]>(HttpClient, Urls.GetTitlesUpdatesUri(limit,after).AbsoluteUri);

        public static Task<Title[]> GetTitlesChangesAsync(DateTime dateTime, int after = 0) =>
            Utilities.GetData<Title[]>(HttpClient, Urls.GetTitlesChangesUri(dateTime, after).AbsoluteUri);

        public static Task<Schedule[]> GetTitlesScheduleAsync(int[] days) =>
            Utilities.GetData<Schedule[]>(HttpClient, Urls.GetTitlesScheduleUri(days).AbsoluteUri);

        public static Task<string[]> GetCachingNodesAsync() =>
            Utilities.GetData<string[]>(HttpClient, Urls.GetCachingNodesUri().AbsoluteUri);

        public static Task<Title> GetRandomTitleAsync() =>
            Utilities.GetData<Title>(HttpClient, Urls.GetRandomeTitleUri().AbsoluteUri);
    }
}
