﻿using System;

namespace SocialNetwork.DataModel
{
    public class UserFollower : IBaseModel
    {
        public AppUser User { get; set; }
        public Guid UserId { get; set; }

        public AppUser Follower { get; set; }
        public Guid FollowerId { get; set; }
    }
}
