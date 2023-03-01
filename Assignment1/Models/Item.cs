using System;
using System.Drawing;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Assignment1.Models
{
	public class Item
	{
		public int Id { get; set; }
		public string  itemName { get; set; }
		public float itemCost{ get; set; }

        public string itemDetails { get; set; }

        public DateTime startDate { get; set; }
		public DateTime endDate { get; set; }

		public string category { get; set; }


		public Item()
		{	

		}

	}
	
}

