﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smarty.Data.Models
{
	public class SmartyUser : IdentityUser
	{
		public Member Member { get; set; }
		public int MemberId{ get; set; }

	}
}
