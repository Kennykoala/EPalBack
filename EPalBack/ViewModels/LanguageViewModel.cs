using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPalBack.ViewModels
{
    public class LanguageViewModel
    {
        public List<language> LanguageAll { get; set; }

        public int? Gender { get; set; }
    }

    public class language
    {
        public int LanguageId { get; set; }

        public string LanguageName { get; set; }
    }

    
}
