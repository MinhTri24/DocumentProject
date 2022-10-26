namespace DocumentProject.Models;

public class Chapter
{
    public int Id { get; set; }
    public string Content { get; set; }
    public DateTime CreateAt { get; set; }

    public int DocumentId { get; set; }
    public Document Document { get; set; }

    public Chapter()
    {
        CreateAt = DateTime.Now;
    }
}