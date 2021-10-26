using System;
using System.Collections.Generic;

#nullable disable

namespace EPalBack.DataModels
{
    public partial class Server
    {
        public Server()
        {
            ProductServers = new HashSet<ProductServer>();
        }

        public int ServerId { get; set; }
        public string ServerName { get; set; }

        public virtual ICollection<ProductServer> ProductServers { get; set; }
    }
}
