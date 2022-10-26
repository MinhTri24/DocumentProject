namespace DocumentProject.Models;

public class DocumentCategory
{
    public int Id { get; set; }
    
    public Document Document { get; set; }
    public Category Category { get; set; }
}