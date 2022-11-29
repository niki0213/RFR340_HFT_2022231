using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFR340_HFT_2022231.Models.DTO
{
    public class BookInfo
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public override bool Equals(object obj)
        {
            BookInfo b = obj as BookInfo;
            if (b == null)
            {
                return false;
            }
            else
            {
                return this.ID == b.ID
                    && this.Title == b.Title;
            }
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.ID, this.Title);
        }
        public override string ToString()
        {
            return "ID: " + ID + "\tTitle: " + Title;
        }
    }
}
