using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace PersonBlog.Models
{
	public class Review 
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Text { get; set; }
		public virtual ICollection<BlogModel> BlogModels { get; set; }


	}
}
