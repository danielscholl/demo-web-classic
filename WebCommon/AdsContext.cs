using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCommon
{
    public class AdsContext : DbContext
    {
        public AdsContext() : base("name=AdsContext")
        {
        }

        public AdsContext(string connString) : base(connString)
        {
        }

        public System.Data.Entity.DbSet<Ad> Ads { get; set; }
    }
}
