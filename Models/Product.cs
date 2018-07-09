﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test2Metanit.Models
{
	public class Product
	{
		public int Id
		{
			get; set;
		}
		public string Name
		{
			get; set;
		}    // название 
		public string Company
		{
			get; set;
		} // производитель
		public decimal Price
		{
			get; set;
		}  // цена
	}
}
