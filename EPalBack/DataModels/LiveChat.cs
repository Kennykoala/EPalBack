using System;
using System.Collections.Generic;

#nullable disable

namespace EPalBack.DataModels
{
    public partial class LiveChat
    {
        public int LiveChatId { get; set; }
        public int LiveSenderId { get; set; }
        public int LiveReceiverId { get; set; }
        public int LiveMessageTypeId { get; set; }
        public string LiveMessageContent { get; set; }
        public DateTime LiveMessageDateTime { get; set; }

        public virtual MessageType LiveMessageType { get; set; }
        public virtual Member LiveReceiver { get; set; }
        public virtual Member LiveSender { get; set; }
    }
}
