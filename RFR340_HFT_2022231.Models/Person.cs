using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RFR340_HFT_2022231.Models
{
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Range(100, 999)]
        public int PersonID { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
        [JsonIgnore]
        public virtual ICollection<Book> Books { get; set; }
        [JsonIgnore]
        public virtual ICollection<Rent> Rent { get; set; }

        public Person()
        {

        }
        public Person(string s)
        {
            string[] t = s.Split('#');
            PersonID = int.Parse(t[0]);
            Name = t[1];
            Phone = t[2];
        }
        public override bool Equals(object obj)
        {
            Person b = obj as Person;
            if (b == null)
            {
                return false;
            }
            else
            {
                return this.PersonID == b.PersonID
                    && this.Name == b.Name
                    && this.Phone == b.Phone;

            }
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.PersonID, this.Name, this.Phone);
        }
    }
}
