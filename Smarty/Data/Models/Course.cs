﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smarty.Data.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public string Description{ get; set; }
        public DayOfWeek Day { get; set; }
        public TimeSpan Time { get; set; }
        public Guid RegisterCode{ get; set; }
        public Guid AccessCode{ get; set; }

    }
}