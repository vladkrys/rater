using RaterApp.Models;
using RaterApp.Repository;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace RaterApp.Logic
{
    public static class Helpers
    {

      
        public static void ProcessRatings(IList<RatingProviderModel> ratingProvidersList, IList<RatingModel> ratingList) {
            foreach (var rating in ratingList) {
                var score = 0.0M;
                var totalDistribution = 0.0M;
                var initScore = 0.0M;
                var intermediateScore = 0.0M;
                rating.Providers = new List<ProviderScore>();
                foreach (var ratingProvider in ratingProvidersList)
                {
                    var reqScore = GetScoreForMovies(rating.MovieName, ratingProvider);
                    initScore = ratingProvider.TrustScore * reqScore;
                    intermediateScore += initScore;
                    totalDistribution += ratingProvider.TrustScore;

                    var provider = new ProviderScore { ProviderName = ratingProvider.Name, OfficialScore = reqScore };
                    rating.Providers.Add(provider);
                }
                score = intermediateScore / totalDistribution;
                rating.Rating = score;
                
                
            }

        }

        public static decimal GetScoreForMovies(string name, RatingProviderModel provider)
        {
            var scoreValue = 0.0M;
            if (provider.ApiUrl.Contains("omdbapi"))
            {

                string encodedName = HttpContext.Current.Server.UrlEncode(name);
                string html = string.Empty;
                string url = provider.ApiUrl;
                url += @"/?t=";
                url += encodedName;
                url += @"&apikey=f2d7a6ff";

               

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.AutomaticDecompression = DecompressionMethods.GZip;

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    html = reader.ReadToEnd();
                }


                //parse html response -> get imdb rating

                var score = html.Split(new string[] { "imdbRating" }, StringSplitOptions.None)[1].Replace("\"", "").Split(',')[0].Replace(":", "").Replace(".", ",");

                var numberFormatInfo = new NumberFormatInfo { NumberDecimalSeparator = "," };
                scoreValue = Decimal.Parse(score, numberFormatInfo);
            }
            else if (provider.ApiUrl.Contains("themoviedb"))
            {
                string encodedName = HttpContext.Current.Server.UrlEncode(name);
                string html = string.Empty;
                string url = provider.ApiUrl;
                url += @"search/movie/?";
                url += @"&api_key=f780c8b8315531f63a44191c00a6ca29&query=";
                url += encodedName;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.AutomaticDecompression = DecompressionMethods.GZip;

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    html = reader.ReadToEnd();
                }


                //parse html response -> get imdb rating

                var score = html.Split(new string[] { "vote_average" }, StringSplitOptions.None)[1].Replace("\"", "").Split(',')[0].Replace(":", "").Replace(".", ",");

                var numberFormatInfo = new NumberFormatInfo { NumberDecimalSeparator = "," };
                scoreValue = Decimal.Parse(score, numberFormatInfo);
            }


            return scoreValue;
        }
    }
}