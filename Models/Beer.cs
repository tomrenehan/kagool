using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KagoolTest.Models
{
    public class Beer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string TagLine { get; set; }

        public DateTime FirstBrewed { get; set; }

        public string Description { get; set; }

        public decimal ABV { get; set; }

        public string Image_Url { get; set; }

    }
}