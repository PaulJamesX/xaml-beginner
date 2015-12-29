using System;
using System.ComponentModel.DataAnnotations;

namespace RestaurantManager.Models
{
    public class MenuItem : IComparable<MenuItem>, IEquatable<MenuItem>
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public override string ToString()
        {
            return this.Title;
        }

        public int CompareTo(MenuItem other)
        {
            return this.Title.CompareTo(other.Title);
        }

        public bool Equals(MenuItem other)
        {
            return this.Title == other.Title;
        }
    }
}