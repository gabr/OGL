using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OGL.Models
{
  public class ApplicationUser : IdentityUser
  {
    [Display(Name = "User name")]
    public string Name { get; set; }

    [Display(Name = "User surname")]
    public string Surname { get; set; }

    [NotMapped]
    [Display(Name = "User full name")]
    public string FullName
    {
      get { return string.Format("{0} {1}", Name, Surname); }
    }

    public virtual ICollection<Advertisement> Advertisement { get; private set; }

    public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
    {
      // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
      var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
      // Add custom user claims here
      return userIdentity;
    }
  }
}