using RaterApp.Logic;
using RaterApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RaterApp.Repository
{
    public class DataSource
    {
        private  static IList<RatingModel> ratingList = null;

        private  static IList<RatingProviderModel> ratingProvidersList = null;


        public IList<RatingModel> RatingList
        {
            get
            {
                
                return GetRatingsDataSource();
            }
        }

        public IList<RatingProviderModel> RatingProvidersList
        {
            get
            {

                return GetRatingProvidersDataSource();
            }
        }



        public IList<RatingModel> GetRatingsDataSource()
        {
            if (ratingList == null)
            {
                ratingList = new List<RatingModel>();

                var ratingModel1 = new RatingModel() { MovieName = "Spiderman", Channel= "HBO", BroadcastTime = new DateTime(2017, 11, 4, 8, 15, 0) };
                var ratingModel2 = new RatingModel() { MovieName = "Batman", Channel = "PRO TV", BroadcastTime = new DateTime(2017, 11, 4, 8, 30, 0) };
                var ratingModel3 = new RatingModel() { MovieName = "Superman", Channel = "AXN", BroadcastTime = new DateTime(2017, 11, 4, 8, 45, 0) };


                ratingList.Add(ratingModel1);
                ratingList.Add(ratingModel2);
                ratingList.Add(ratingModel3);



            }

            return ratingList;

        }

        public IList<RatingProviderModel> GetRatingProvidersDataSource()
        {

            if (ratingProvidersList == null)
            {
                ratingProvidersList = new List<RatingProviderModel>();

                var provider1 = new RatingProviderModel() { id = 1, Name = "TIVO", TrustScore = 0.5M, ApiUrl = "http://www.omdbapi.com" };
                var provider2 = new RatingProviderModel() { id = 2, Name = "IMDB", TrustScore = 0.3M, ApiUrl = "http://www.omdbapi.com" };
                var provider3 = new RatingProviderModel() { id = 3, Name = "The Movie DB", TrustScore = 0.2M, ApiUrl = "https://api.themoviedb.org/3/" };
                ratingProvidersList.Add(provider1);
                ratingProvidersList.Add(provider2);
                ratingProvidersList.Add(provider3);
            }
            return ratingProvidersList;
        }
    }
}