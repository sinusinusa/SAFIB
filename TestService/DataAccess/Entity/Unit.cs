﻿using System.Collections.Generic;

namespace TestService.DataAccess.Entity
{
    public class Unit
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        //public string? Status { get; set; }
        public int MainId { get; set; }

        public Unit? MainUnit { get; set; }
        public ICollection<Unit>? SubUnits { get; set; }
    }
}
