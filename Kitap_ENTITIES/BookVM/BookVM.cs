using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitap_ENTITIES.BookVM
{
   public class BookVM
    {
      
        public IEnumerable<Book> blist { get; set; }
        public Book  Book { get; set; }
        public IEnumerable<Category> ctlist { get; set; }
        public Category Category { get; set; }
       
        public IQueryable<SelectListItem> selectListItems { get; set; }
    }
}
