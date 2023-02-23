using System;
using System.ComponentModel.DataAnnotations;

namespace Mission7.Models
{
	public class Category
	{
		[Key]
		[Required]
		public int CategoryId { get; set; }
		[Required]
		public string CategoryName { get; set; }
	}
}

