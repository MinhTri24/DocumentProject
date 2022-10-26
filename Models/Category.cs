namespace DocumentProject.Models;

public class Category
{
    public int Id { get; set; }
    public string CategoryName { get; set; }
    public DateTime CreateAt { get; set; }

    public Category(DateTime createAt)
    {
        CreateAt = createAt;
    }

    public Category()
    {
        CreateAt = DateTime.Now;
    }

    public ICollection<DocumentCategory> DocumentCategories { get; set; }
}