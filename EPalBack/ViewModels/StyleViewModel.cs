using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPalBack.ViewModels
{
    public class StyleViewModel
    {
        public List<style> StyleAll { get; set; }
    }

    public class style
    {
        public int StyleId { get; set; }

        public string StyleName { get; set; }
    }
}
