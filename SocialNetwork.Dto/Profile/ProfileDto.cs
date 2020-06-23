﻿using System.Collections.Generic;

namespace SocialNetwork.Dto
{
    public class ProfileDto
    {
        public string DisplayName { get; set; }
        public string Username { get; set; }
        public string MainPhoto { get; set; }
        public string Bio { get; set; }
        //public bool IsFollowed { get; set; }
        //public int FollowersCount { get; set; }
        //public int FollowingCount { get; set; }
        public IEnumerable<string> Photos { get; set; }
    }
}
