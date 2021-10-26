using System;
using System.Collections.Generic;

#nullable disable

namespace EPalBack.DataModels
{
    public partial class Payment
    {
        public int PaymentId { get; set; }
        public string TransactionUid { get; set; }
        public DateTime TransationDateTime { get; set; }
        public string ConfirmationId { get; set; }
        public int PayMethod { get; set; }
        public int OrderId { get; set; }

        public virtual Order Order { get; set; }
    }
}
