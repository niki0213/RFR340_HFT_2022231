using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFR340_HFT_2022231.Models
{
    public class Rent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RentID { get; set; }

        public int BookID { get; set; }
        public int PersonID { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public Rent()
        {

        }
    }
}
