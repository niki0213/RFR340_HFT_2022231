using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFR340_HFT_2022231.Models.DTO
{
    public class BookReadCount
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Count { get; set; }
        public override bool Equals(object obj)
        {
            BookReadCount b = obj as BookReadCount;
            if (b == null)
            {
                return false;
            }
            else
            {
                return this.Id == b.Id
                    && this.Count == b.Count;
            }
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.Id, this.Title, this.Count);
        }
        public override string ToString()
        {
            return "ID: "+Id+"\tTitle: "+Title+"\tCount: "+Count;
        }
    }
}
