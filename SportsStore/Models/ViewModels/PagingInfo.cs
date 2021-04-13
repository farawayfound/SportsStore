using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SportsStore.Models.ViewModels
{
    public class PagingInfo
    {
        //   F i e l d s   &   P r o p e r t i e s

        public int TotalItems { get; set; }

        public int ItemsPerPage { get; set; }

        public int CurrentPage { get; set; }

        //   C o n s t r u c t o r s

        //   M e t h o d s

        public int TotalPages =>
           (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
    }


}
