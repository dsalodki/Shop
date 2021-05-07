﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class Item
    {
        public Item(decimal? id, string name)
        {
            Id = id;
            Name = name;
        }

        public decimal? Id { get; set; }
        public string Name { get; set; }
    }
}
