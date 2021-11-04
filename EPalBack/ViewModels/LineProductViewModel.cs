using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPalBack.ViewModels
{
    public class LineProductViewModel
    {
        public int ProductId { get; set; }

        public string MemberName { get; set; }

        public string GameName { get; set; }

        public decimal UnitPrice { get; set; }

        public string Server { get; set; }

        public string Position { get; set; }

        public string Level { get; set; }

        public string CreatorImg { get; set; }

        public int? gender { get; set; }
        //public genderenum? gender { get; set; }
    }

    public enum genderenum
    {
        Male = 1,
        Female = 2
    }

}
