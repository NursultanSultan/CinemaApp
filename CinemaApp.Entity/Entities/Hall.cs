
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaApp.Entity.Entities
{
    public class Hall 
    {
        public int Id { get; set; }

        public string HallName { get; set; }

        public int Capacity { get; set; }

        public int CinemaId { get; set; }
        public Cinema Cinema { get; set; }

        public bool IsDeleted { get; set; }

    }
}
