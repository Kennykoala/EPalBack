using System;
using System.Collections.Generic;

#nullable disable

namespace EPalBack.DataModels
{
    public partial class Chatlist
    {
        public int ChatlistId { get; set; }
        public int SenderId { get; set; }
        public int? ReceiverId { get; set; }
        public int MessageTypeId { get; set; }
        public string MessageContent { get; set; }
        public DateTime? SendOrReceiveDateTime { get; set; }

        public virtual MessageType MessageType { get; set; }
        public virtual Member Receiver { get; set; }
        public virtual Member Sender { get; set; }
    }
}
