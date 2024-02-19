using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.RequestFeature
{
    public abstract class RequestParameters
    {
        const int Maxpagesize = 30;
        public int Pagenumber { get; set; } = 1;
        private int pagesize { get; set; } = 6;
        public int Pagesize
        {
            get { return pagesize; }
            set { pagesize = value > Maxpagesize ? Maxpagesize : value; }
        }
        public string? OrderBy { get; set; }
    }
}
