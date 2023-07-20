using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoV2.Models
{
    public class TodoItem
    {
        public int id { get; set; }
        public string Description { get; set; } = "";
        public bool IsChecked { get; set; }
    }
}
