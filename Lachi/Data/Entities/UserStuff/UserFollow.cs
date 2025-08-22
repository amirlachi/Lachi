﻿namespace Lachi.Data.Entities.UserStuff
{
    public class UserFollow
    {
        public Guid FollowerId { get; set; }
        public User Follower { get; set; } = null!;

        public Guid FollowingId { get; set; }
        public User Following { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
