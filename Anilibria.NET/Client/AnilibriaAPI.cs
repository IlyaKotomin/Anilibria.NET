﻿using Anilibria.NET.Builders;
using Anilibria.NET.Helpers;
using Anilibria.NET.Models;
using Anilibria.NET.Models.TitleModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anilibria.NET.Client
{
    public static class AnilibriaAPI
    {
        internal static HttpClient HttpClient = new HttpClient();

        /// <summary>
        /// Returns title by id
        /// </summary>
        /// <param name="id">Title ID</param>
        /// <returns>anime title</returns>
        public static Task<Title> GetTitleAsync(int id) =>
            Utilities.GetData<Title>(HttpClient, Urls.GetTitleUri(id).AbsoluteUri);

        public static Task<Title> GetTitleAsync(string code) =>
            Utilities.GetData<Title>(HttpClient, Urls.GetTitleUri(code).AbsoluteUri);

        public static Task<Title[]> GetTitlesAsync(string[] codes) =>
            Utilities.GetData<Title[]>(HttpClient, Urls.GetTitlesUri(codes).AbsoluteUri);

        public static Task<Title[]> GetTitlesAsync(int[] ids) =>
            Utilities.GetData<Title[]>(HttpClient, Urls.GetTitlesUri(ids).AbsoluteUri);

        public static Task<Title[]> GetTitlesUpdatesAsync(int limit = 5, int after = 0) =>
            Utilities.GetData<Title[]>(HttpClient, Urls.GetTitlesUpdatesUri(limit, after).AbsoluteUri);

        public static Task<Title[]> GetTitlesChangesAsync(DateTime dateTime, int after = 0) =>
            Utilities.GetData<Title[]>(HttpClient, Urls.GetTitlesChangesUri(dateTime, after).AbsoluteUri);

        public static Task<Schedule[]> GetTitlesScheduleAsync(int[] days) =>
            Utilities.GetData<Schedule[]>(HttpClient, Urls.GetTitlesScheduleUri(days).AbsoluteUri);

        public static Task<string[]> GetCachingNodesAsync() =>
            Utilities.GetData<string[]>(HttpClient, Urls.GetCachingNodesUri().AbsoluteUri);

        public static Task<Title> GetRandomTitleAsync() =>
            Utilities.GetData<Title>(HttpClient, Urls.GetRandomeTitleUri().AbsoluteUri);

        public static Task<YouTubePost[]> GetYouTubePostsAsync(DateTime dateTime, int limit = 5, int after = 0) =>
            Utilities.GetData<YouTubePost[]>(HttpClient, Urls.GetYouTubeUri(dateTime, limit, after).AbsoluteUri);

        public static Task<Feed[]> GetFeedAsync(DateTime dateTime, int limit = 5, int after = 0) =>
            Utilities.GetData<Feed[]>(HttpClient, Urls.GetFeedUri(dateTime, limit, after).AbsoluteUri);

        public static Task<int[]> GetAnimeYearsAsync() =>
            Utilities.GetData<int[]>(HttpClient, Urls.GetAnimeYearsUri().AbsoluteUri);

        public static Task<string[]> GetGenresAsync(GenresSortingType sortingType) =>
            Utilities.GetData<string[]>(HttpClient, Urls.GetAnimeGenresUri(sortingType).AbsoluteUri);

        public static Task<Title[]> SearchTitlesAsync(SearchQueryBuilder queryBuilder) =>
            Utilities.GetData<Title[]>(HttpClient, Urls.GetSearchTitlesUri(queryBuilder).AbsoluteUri);
    }
}