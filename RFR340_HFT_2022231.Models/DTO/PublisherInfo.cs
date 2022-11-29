using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFR340_HFT_2022231.Models.DTO
{
    public class PublisherInfo
    {
        public int ID { get; set; }
        public int BookCount { get; set; }
        public override bool Equals(object obj)
        {
            PublisherInfo b = obj as PublisherInfo;
            if (b == null)
            {
                return false;
            }
            else
            {
                return this.ID == b.ID
                    && this.BookCount == b.BookCount;
            }
        } 
        public override int GetHashCode()
            {
                return HashCode.Combine(this.ID, this.BookCount);
            }
        public override string ToString()
        {
            return "ID: " + ID +"\tBook Count: " + BookCount;
        }
    }
        
    }
