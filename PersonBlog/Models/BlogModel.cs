namespace PersonBlog.Models
{
    public class BlogModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Content { get; set; }
        public DateTime Create_Date { get; set; } = DateTime.Now;
        public DateTime Update_Date { get; set; } = DateTime.Now;
    }
}
