using System;
using System.Collections.Generic;

#nullable disable

namespace EPalBack.DataModels
{
    public partial class MessageType
    {
        public MessageType()
        {
            Chatlists = new HashSet<Chatlist>();
            LiveChats = new HashSet<LiveChat>();
        }

        public int MessageTypeId { get; set; }
        public string MessageTypeName { get; set; }

        public virtual ICollection<Chatlist> Chatlists { get; set; }
        public virtual ICollection<LiveChat> LiveChats { get; set; }
    }
}
