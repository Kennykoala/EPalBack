using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPalBack.ViewModels
{
    public class ServerViewModel
    {
        public List<server> ServerAll { get; set; }
    }
    public class server
    {
        public string ServerName { get; set; }

        public int ServerId { get; set; }
    }
}
