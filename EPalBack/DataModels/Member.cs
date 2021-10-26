using System;
using System.Collections.Generic;

#nullable disable

namespace EPalBack.DataModels
{
    public partial class Member
    {
        public Member()
        {
            ChatlistReceivers = new HashSet<Chatlist>();
            ChatlistSenders = new HashSet<Chatlist>();
            CommentDetails = new HashSet<CommentDetail>();
            FollowingFollowingNavigations = new HashSet<Following>();
            FollowingMembers = new HashSet<Following>();
            LiveChatLiveReceivers = new HashSet<LiveChat>();
            LiveChatLiveSenders = new HashSet<LiveChat>();
            MeetLikeLikes = new HashSet<MeetLike>();
            MeetLikeMembers = new HashSet<MeetLike>();
            Orders = new HashSet<Order>();
            Products = new HashSet<Product>();
            RecentVistorMembers = new HashSet<RecentVistor>();
            RecentVistorRecentVistorNavigations = new HashSet<RecentVistor>();
        }

        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public int? CityId { get; set; }
        public int? Gender { get; set; }
        public DateTime? BirthDay { get; set; }
        public int? TimeZone { get; set; }
        public int? LanguageId { get; set; }
        public string Bio { get; set; }
        public string ProfilePicture { get; set; }
        public int? LineStatusId { get; set; }
        public string AuthCode { get; set; }
        public bool? IsAdmin { get; set; }
        public string MeetPicture { get; set; }
        public int? LoginMethod { get; set; }
        public string GoogleId { get; set; }
        public string Fbid { get; set; }
        public string LineId { get; set; }

        public virtual City City { get; set; }
        public virtual Language Language { get; set; }
        public virtual LineStatus LineStatus { get; set; }
        public virtual ICollection<Chatlist> ChatlistReceivers { get; set; }
        public virtual ICollection<Chatlist> ChatlistSenders { get; set; }
        public virtual ICollection<CommentDetail> CommentDetails { get; set; }
        public virtual ICollection<Following> FollowingFollowingNavigations { get; set; }
        public virtual ICollection<Following> FollowingMembers { get; set; }
        public virtual ICollection<LiveChat> LiveChatLiveReceivers { get; set; }
        public virtual ICollection<LiveChat> LiveChatLiveSenders { get; set; }
        public virtual ICollection<MeetLike> MeetLikeLikes { get; set; }
        public virtual ICollection<MeetLike> MeetLikeMembers { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<RecentVistor> RecentVistorMembers { get; set; }
        public virtual ICollection<RecentVistor> RecentVistorRecentVistorNavigations { get; set; }
    }
}
