using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RFR340_HFT_2022231.Models
{
    public class Rent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Range(10,99)]
        public int RentID { get; set; }
        [Required]
        [Range(1000, 9999)]
        public int BookID { get; set; }
        [Required]
        [Range(100,999)]
        public int PersonID { get; set; }
        [Required]
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        [JsonIgnore]
        public virtual Books Books { get; set; }
        [JsonIgnore]
        public virtual Person Person { get; set; }
        public Rent()
        {

        }

        public Rent(string s)
        {
            string[] t = s.Split('#');
            RentID = int.Parse(t[0]);
            BookID = int.Parse(t[1]);
            PersonID = int.Parse(t[2]);
            string[] dates = t[3].Split('.');
            string[] dates2 = t[4].Split('.');
            Start = new DateTime(int.Parse(dates[0]), int.Parse(dates[1]), int.Parse(dates[2]));
            End = new DateTime(int.Parse(dates[0]), int.Parse(dates[1]), int.Parse(dates[2]));
        }
    }
}
