﻿using System.Web.Http;

namespace BiddingSystem
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        public static void Configure(HttpConfiguration config = null)
        {

            #region Initialize the Web API
            if (config == null)
            {
                GlobalConfiguration.Configure(WebApiConfig.Register);
                config = GlobalConfiguration.Configuration;
            }
            else
            {
                // used in the integration tests
                WebApiConfig.Register(config);
            }

            #endregion
        }
    }
}
