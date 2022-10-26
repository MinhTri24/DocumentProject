using DocumentProject.Models;

namespace DocumentProject.Views.ViewModels;

public class ChapterDetail
{
    public Chapter Chapter { get; set; }
    public List<Chapter> Chapters { get; set; }
}