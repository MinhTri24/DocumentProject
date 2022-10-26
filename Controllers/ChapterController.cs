using DocumentProject.Data;
using DocumentProject.Models;
using DocumentProject.Views.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DocumentProject.Controllers;

public class ChapterController : Controller
{
    private ApplicationDbContext _db;
    
    public ChapterController(ApplicationDbContext db)
    {
        _db = db;
    }
    
    // public IActionResult Index()
    // {
    //     var chapters = _db.Chapters.ToList();
    //     return View(chapters);
    // }
    //
    // public IActionResult Detail(string id)
    // {
    //     int documentId = Int32.Parse(id);
    //     var documents = _db.Documents.Find(documentId);
    //     return View(documents);
    // }
    
    [HttpGet]
    public IActionResult Create(int id)
    {
        ChapterCreate chapterCreate = new ChapterCreate()
        {
            DocumentId = id
        };
        return View(chapterCreate);
    }
    
    [HttpPost]
    public IActionResult Create(ChapterCreate chapterCreate)
    {
        Document? documentInDb = _db.Documents.Find(chapterCreate.DocumentId);
        if (documentInDb == null)
        {
            return Content("Error");
        }
        Chapter chapter = new Chapter()
        {
            DocumentId = chapterCreate.DocumentId,
            Content =  chapterCreate.Content,
            Document = documentInDb
        };
        _db.Chapters.Add(chapter);
        _db.SaveChanges();
        return RedirectToAction("Detail", "Document", new { id = chapterCreate.DocumentId });
    }
    
    public IActionResult Detail(int id)
    {
        var chapter = _db.Chapters
            .Include(c => c.Document)
            .FirstOrDefault(d => d.Id == id);
        if (chapter != null)
        {
            var chapterRelated = _db.Chapters.Where(c => c.DocumentId == chapter.DocumentId).ToList();
            chapterRelated.Remove(chapter);
            ChapterDetail chapterDetail = new ChapterDetail()
            {
                Chapter = chapter,
                Chapters = chapterRelated
            };


            return View(chapterDetail);
        }
        return Content("Not find chapter");
    }

    public IActionResult Delete(int id)
    {
        var chapter = _db.Chapters
            .Include(c => c.Document)
            .FirstOrDefault(d => d.Id == id);
        var documentId = chapter.DocumentId;
        var chapters = _db.Chapters.Find(id);
        if (chapters != null)
        {
            _db.Chapters.Remove(chapters);
            _db.SaveChanges();
            
            //return RedirectToAction("Detail", "Chapters", "nextChapter");
            return RedirectToAction("Detail", "Document", new { id = documentId});
        }

        return RedirectToAction("Detail", "Document", new { id = documentId});
    }
    
    [HttpGet]
    public IActionResult Update(string id)
    {
        int chapterId = Int32.Parse(id);
        var chapters = _db.Chapters.Find(chapterId);
        ChapterUpdate formChapter = new ChapterUpdate()
        {
            Id = chapters.Id,
            Content = chapters.Content
        };
        return View(formChapter);
    }
    
    [HttpPost]
    public IActionResult Update(ChapterUpdate chapterUpdate)
    {
        var chapter = _db.Chapters.Find(chapterUpdate.Id);
        chapter.Content = chapterUpdate.Content;
        _db.SaveChanges();
        string chapterId = $"{chapterUpdate.Id}";
        return RedirectToAction("Detail", new { id = chapterId });
    }
}