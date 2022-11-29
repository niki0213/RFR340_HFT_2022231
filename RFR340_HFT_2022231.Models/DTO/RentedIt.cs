using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFR340_HFT_2022231.Models.DTO
{
    public class RentedIt
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public override bool Equals(object obj)
        {
            RentedIt b = obj as RentedIt;
            if (b == null)
            {
                return false;
            }
            else
            {
                return this.ID == b.ID
                    && this.Name == b.Name


            }
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.ID, this.Name);

        }
        public override string ToString()
        {
            return "ID: " + ID + "\tName: " + Name;
        }

    }
}
