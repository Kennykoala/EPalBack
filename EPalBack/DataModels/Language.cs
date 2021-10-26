using System;
using System.Collections.Generic;

#nullable disable

namespace EPalBack.DataModels
{
    public partial class Language
    {
        public Language()
        {
            Members = new HashSet<Member>();
        }

        public int LanguageId { get; set; }
        public string LanguageName { get; set; }

        public virtual ICollection<Member> Members { get; set; }
    }
}
