using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
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

    }
}
