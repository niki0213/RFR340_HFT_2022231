using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace RFR340_HFT_2022231.Models
{
    public class Publisher
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PublisherID { get; set; }
        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Books> Books { get; set; }
        public Publisher()
        {
        }
        public Publisher(string s)
        {
            string[] t = s.Split('#');
            PublisherID = int.Parse(t[0]);
            Name = t[1];
          
        }

    }
}
