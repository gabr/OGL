using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace OGL.Models
{
  public class OglContext : IdentityDbContext
  {
    public OglContext() : base("DefaultConnection")
    {
    }

    public static OglContext Create()
    {
      return new OglContext();
    }
  }
}