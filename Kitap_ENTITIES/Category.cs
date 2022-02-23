using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitap_ENTITIES
{
    public class Category
    {[Key]
        [DisplayName("Kategori Id")]
        public int CategoryID { get; set; }
        [DisplayName("Kategori Adı")]
        public string CategoryName { get; set; }
        public ICollection<Book> Books { get; set; }
        
    }
}
