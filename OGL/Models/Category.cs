using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OGL.Models
{
  public class Category
  {
    [Key]
    [Display(Name = "Id")]
    public int Id { get; set; }

    [Display(Name = "Category name")]
    [Required]
    public string Name { get; set; }

    [Display(Name = "Parent id")]
    [Required]
    public int ParentId { get; set; }

    #region SEO

    [Display(Name = "Title in Google")]
    [MaxLength(72)]
    public string MetaTitle { get; set; }

    [Display(Name = "Description in Google")]
    [MaxLength(160)]
    public string MetaDescription { get; set; }

    [Display(Name = "Tags for Google")]
    [MaxLength(160)]
    public string MetaTags { get; set; }

    [Display(Name = "Page content")]
    [MaxLength(500)]
    public string Content { get; set; }

    #endregion

    public virtual ICollection<Advertisement_Category> Advertisement_Category { get; set; }

    public Category()
    {
      Advertisement_Category = new HashSet<Advertisement_Category>();
    }
  }
}