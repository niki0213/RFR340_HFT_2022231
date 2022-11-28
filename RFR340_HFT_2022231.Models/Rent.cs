﻿using System;
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
        [Range(1000, 9999)]
        public int BookID { get; set; }
        [Required]
        [StringLength(250)]
        public string Title { get; set; }
        [Required]
        [StringLength(100)]
        public string Author { get; set; }

        [Range(0, 9)]
        public int PublisherID { get; set; }
        [JsonIgnore]
        public virtual ICollection<Rent> Rent { get; set; }
        [JsonIgnore]
        public virtual ICollection<Person> Person { get; set; }
        [JsonIgnore]
        public virtual Publisher Publisher { get; set; }

        public Book()
        {

        }
        public Book(string s)
        {
            string[] t = s.Split('#');
            BookID = int.Parse(t[0]);
            Title = t[1];
            Author = t[2];
            PublisherID = int.Parse(t[3]);
        }
        public override bool Equals(object obj)
        {
            Book b = obj as Book;
            if (b == null)
            {
                return false;
            }
            else
            {
                return this.BookID == b.BookID
                    && this.Title == b.Title
                    && this.Author == b.Author
                    && this.PublisherID == b.PublisherID;
            }
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.BookID, this.Title, this.Author, this.PublisherID);
        }
    }
}
