using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitap_ENTITIES
{
    public class Book
    {[Key]
        [DisplayName("Kitap Id")]
        public int BookID { get; set; }
        [DisplayName("Kitap Adı")]
        public string BookName { get; set; }
        [DisplayName("Yazar Adı")]
        public string Writer { get; set; }

        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        
    }
}
