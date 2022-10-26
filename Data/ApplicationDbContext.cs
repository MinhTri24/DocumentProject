using DocumentProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DocumentProject.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public virtual DbSet<Chapter> Chapters { get; set; }
    public virtual DbSet<Document> Documents { get; set; }
    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<DocumentCategory> DocumentCategories { get; set; }
}