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
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [StringLength(5)]
        public int PersonID { get; set; }
        [StringLength(30)]
        public string FirstName { get; set; }
        [StringLength(30)]
        public string LastName { get; set; }
        [StringLength(11)]
        public int phone { get; set; }
        public virtual ICollection<Books> Books { get; set; }
        public virtual ICollection<Rent> Rent { get; set; }

        public Person()
        {

        }
        public Person(string s)
        {
            string[] t = s.Split('#');
            PersonID = int.Parse(t[0]);
            FirstName = t[1];
            LastName = t[2];
            phone = int.Parse(t[3]);
        }
    }
}
