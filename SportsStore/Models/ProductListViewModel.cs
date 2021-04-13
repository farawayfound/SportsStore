using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportsStore.Models;

namespace SportsStore.Models.ViewModels
{
    public class ProductListViewModel
    {
        //   F i e l d s   &   P r o p e r t i e s

        public IEnumerable<Product> Products { get; set; }

        public PagingInfo PagingInformation { get; set; }

        //   C o n s t r u c t o r s

        //   M e t h o d s
    }

}
