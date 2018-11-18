using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BiddingSystem.Entities;
using Newtonsoft.Json;

namespace BiddingSystem.Specs.ApiClient
{
    public static class Extensions
    {
        /// <summary>
        /// Deserialize the JSON returned from Response into selected type
        /// </summary>
        /// <typeparam name="T">Type to return</typeparam>
        /// <param name="responseMessage">Then response message to deserialize</param>
        /// <returns></returns>
        public static T DeserializeTo<T>(this HttpResponseMessage responseMessage)
        {
            return JsonConvert.DeserializeObject<T>(responseMessage.Content.ReadAsStringAsync().Result);
        }
    }
}
