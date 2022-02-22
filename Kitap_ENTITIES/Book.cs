using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitap_ENTITIES
{
    public class Book
    {[Key]
        public int BookID { get; set; }
        public string BookName { get; set; }
        public string Writer { get; set; }

        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        
    }
}
