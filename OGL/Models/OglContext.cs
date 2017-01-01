using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace OGL.Models
{
  public class OglContext : IdentityDbContext
  {
    public DbSet<Category> Category { get; set; }
    public DbSet<Advertisement> Advertisement { get; set; }
    public DbSet<ApplicationUser> ApplicationUser { get; set; }
    public DbSet<Advertisement_Category> Advertisement_Category { get; set; }

    public OglContext() : base("DefaultConnection")
    {
    }

    public static OglContext Create()
    {
      return new OglContext();
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      // disable auto tables rename when generating database from code model
      modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

      // disable default cascade delete and configure fluent api
      modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
      modelBuilder.Entity<Advertisement>()
        .HasRequired(x => x.ApplicationUser)
        .WithMany(x => x.Advertisement)
        .HasForeignKey(x => x.ApplicationUserId)
        .WillCascadeOnDelete(true);
    }
  }
}