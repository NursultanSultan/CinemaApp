using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.Entity.Entities
{
    public class News
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime NewsDate { get; set; }

        public bool IsDelete { get; set; }
    }
}
