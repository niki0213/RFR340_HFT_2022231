using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFR340_HFT_2022231.Models
{
    public class Books
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookID { get; set; }

        public int PublisherID { get; set; }

        [StringLength(150)]
        public string Title { get; set; }

        [StringLength(100)]
        public string Author { get; set; }

        public DateTime Publication { get; set; }
        public virtual ICollection<Rent> Rent { get; set; }
        public virtual ICollection<Person> Person { get; set; }
        public virtual Publisher Publisher { get; set; }

        public Books()
        {

        }
    }
}
