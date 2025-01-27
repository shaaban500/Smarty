﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smarty.Data.ViewModels.Courses
{
	public class SelectCourseViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Code { get; set; }
        public string Description 
        {
			get   
			{
				return $"{Name} ({Code})";
			}
		}

    }
}
