﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Util
{
    public class AppConfigHelper
    {
        #region Members
        private IConfiguration _configuration { get; }
        #endregion


        #region Constructor
        public AppConfigHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #endregion


        #region Public Methods
        public T GetValue<T>(string key) 
        {
            return _configuration.GetValue<T>(key);
        }
        #endregion
    }
}
