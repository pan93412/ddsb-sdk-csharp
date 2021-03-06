﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ddsb_sdk
{
    public class DDSB
    {
        private static readonly HttpClient client = new HttpClient();
        /// <summary>
        /// The url to shorten.
        /// </summary>
        private string Url { get; set; }
        /// <summary>
        /// The custom identifier of dd.sb url.
        /// </summary>
        public string CustomId { get; set; }
        /// <summary>
        /// The password of this shortened url.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Construct a <see cref="DDSB"/> object.
        /// </summary>
        /// <param name="url">See <see cref="Url"/></param>
        public DDSB(string url)
        {
            Url = url;
        }

        /// <summary>
        /// Build the query for a request.
        /// </summary>
        /// <param name="url">The url to shorten.</param>
        /// <param name="customId">The custom identifier of dd.sb url.</param>
        /// <param name="password">The password of this shortened url.</param>
        /// <returns>The query in name/value pair.</returns>
        protected string BuildQuery(string url, string customId, string password)
        {
            List<string> pair = new List<string>();

            if (url != null)
            {
                pair = pair.Append($"url={url}").ToList();
            }
            else
            {
                throw ThrowWhenFailed("10000");
            }

            if (customId != null)
            {
                pair = pair.Append($"cust={customId}").ToList();
            }

            if (password != null)
            {
                pair = pair.Append($"pass={password}").ToList();
            }

            return string.Join("&", pair);
        }
        /// <summary>
        /// Fetch the response from dd.sb
        /// </summary>
        /// <param name="url">The url to shorten.</param>
        /// <param name="customId">The custom identifier of dd.sb url.</param>
        /// <param name="password">The password of this shortened url.</param>
        /// <returns>The response in <see cref="DDSBRawResponse"/></returns>
        protected async Task<DDSBRawResponse> GetResponse(string url, string customId, string password)
        {
            string toRequest = $"https://dd.sb/api.php?{BuildQuery(url, customId, password)}";
            HttpResponseMessage response = await client.GetAsync(toRequest);
            return JsonConvert.DeserializeObject<DDSBRawResponse>(
                await response.Content.ReadAsStringAsync()
            );
        }

#nullable enable
        /// <summary>
        /// Throw errors when something failed.
        /// </summary>
        /// <param name="code"></param>
        protected Exception? ThrowWhenFailed(string code)
        {
            Exception? toThrow = null;
            switch (code)
            {
                case "10000":
                    toThrow = Errors.err10000;
                    break;
                case "10001":
                    toThrow = Errors.err10001;
                    break;
                case "10002":
                    toThrow = Errors.err10002;
                    break;
                case "10003":
                    toThrow = Errors.err10003;
                    break;
                case "10004":
                    toThrow = Errors.err10004;
                    break;
            }

            return toThrow;
        }
#nullable disable

        /// <summary>
        /// Generate a dd.sb shortened url.
        /// </summary>
        /// <returns>See <see cref="DDSBInfo"/></returns>
        public async Task<DDSBInfo> Generate()
        {
            DDSBRawResponse resp = await GetResponse(Url, CustomId, Password);
            Exception error = ThrowWhenFailed(resp.Error);

            if (error != null)
            {
                throw error;
            }

            return new DDSBInfo
            {
                ShortenId = resp.Rand,
                Password = resp.Pass,
            };
        }
    }
}
