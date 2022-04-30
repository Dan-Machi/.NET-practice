using BasicWebshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicWebshop.ViewModels
{
    public class Storage
    {
        public List<Item> StoredItems { get; set; }
        public double Average { get; set; }
    }
}
