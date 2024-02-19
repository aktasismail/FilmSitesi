using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.RequestFeature
{
    public class MetaData
    {
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int TotalPage { get; set; }
        public int PageSize { get; set; }
        public bool NextPage => CurrentPage < TotalPage;
        public bool PreviousPage => CurrentPage > 1;
    }
}
