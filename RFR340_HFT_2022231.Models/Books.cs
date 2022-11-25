using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RFR340_HFT_2022231.Models
{
    public class Books
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookID { get; set; }

       

        [StringLength(150)]
        public string Title { get; set; }

        [StringLength(100)]
        public string Author { get; set; } 
        public int PublicationYear { get; set; }
        public int PublisherID { get; set; }

       
        public virtual ICollection<Rent> Rent { get; set; }
        public virtual ICollection<Person> Person { get; set; }
        public virtual Publisher Publisher { get; set; }

        public Books()
        {

        }
        public Books(string s)
        {
            string[] t = s.Split('#');
            BookID = int.Parse(t[0]);
            Title = t[1];
            Author = t[2];
            PublicationYear =int.Parse( t[3]);
            PublisherID = int.Parse(t[4]);
        }
    }
}
