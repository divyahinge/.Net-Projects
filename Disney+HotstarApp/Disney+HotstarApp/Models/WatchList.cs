using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Disney_HotstarApp.Models
{
    public class WatchList
    {
       private List<Feedback> feedback = new List<Feedback>();

        public List<Feedback> GetAllMovies()
        {
            return feedback;
        }

        public bool AddFeedback(Feedback fb)
        {
            bool status = false;
            feedback.Add(fb);
            status = true;
            return status;
        }

        public bool RemoveFeedback(int id)
        {
            bool status = false;
            Feedback feedb=feedback.Find((thefb)=>thefb.Id == id);
            feedback.Remove(feedb);
            status = true;
            return status;
        }

        public bool UpdateFeedback(Feedback fbtobeupdated)
        {
            bool status = false;
            Feedback feedb = feedback.Find((thefb) => thefb.Id == fbtobeupdated.Id);
            feedb.Review = fbtobeupdated.Review;
            status = true;
            return status;
        }
    }
}