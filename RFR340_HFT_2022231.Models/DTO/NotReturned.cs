using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFR340_HFT_2022231.Models.DTO
{
    public class NotReturned
    {
        public int BID { get; set; }
        public string Title { get; set; }
        public int PID { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public override bool Equals(object obj)
        {
            NotReturned b = obj as NotReturned;
            if (b == null)
            {
                return false;
            }
            else
            {
                return this.BID == b.BID
                    && this.Title == b.Title
                    && this.PID == b.PID
                    && this.Name == b.Name
                    && this.PhoneNumber == b.PhoneNumber;

            }
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.BID, this.Title, this.PID, this.Name, this.PhoneNumber);

        }
        public override string ToString()
        {
            return "BookID: " + BID + "\tTitle: " + Title + "\tPersonID: " + PID+"\tName: "+Name+"\tPhone Number: "+PhoneNumber;
        }
    }
}
