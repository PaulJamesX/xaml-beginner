﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace RestaurantManager.Models
{
    public class Order : IComparable<Order>
    {
        [Key]
        public int Id { get; set; }

        public string SpecialRequests { get; set; }

        public ObservableCollection<MenuItem> Items{ get; set; }

        public Table Table { get; set; }

        public bool Complete { get; set; }

        public bool Expedite { get; set; }

        public override string ToString()
        {
            return String.Join(", ", Items.Select(i => i.Title));
        }

        public int CompareTo(Order other)
        {
            return this.Table.Description.CompareTo(other.Table.Description);
        }

    }
}
