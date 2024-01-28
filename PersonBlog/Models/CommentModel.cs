using Microsoft.Build.Framework;

namespace PersonBlog.Models
{
	public class CommentModel
	{
		public int Id { get; set; }
        public int BlogId { get; set; }
        [Required]
		public string? UserName { get; set; }
		[Required]
		public string? Content { get; set; }
		public DateTime Create_Date { get; set; } = DateTime.Now;
	}
}
