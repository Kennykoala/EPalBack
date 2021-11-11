using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPalBack.ViewModels
{
    public class MemberagerangeViewModel
    {
        public List<Addmemberrange> Addmemberranges { get; set; }
    }

    public class Addmemberrange
     {
          
        public TimeSpan Age { get; set; }
        public DateTime? BirthDay { get; set; }
    }
    
}
