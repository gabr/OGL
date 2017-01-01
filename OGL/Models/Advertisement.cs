using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OGL.Models
{
  public class Advertisement
  {
    [Key]
    [Display(Name = "Id")]
    public int Id { get; set; }

    [Display(Name = "Advertisement content")]
    [MaxLength(500)]
    [Required]
    public string Content { get; set; }

    [Display(Name = "Advertisement title")]
    [MaxLength(72)]
    [Required]
    public string Title { get; set; }

    [Display(Name = "Add date")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
    [Required]
    public DateTime AddDateTime { get; set; }

    [Required]
    public string ApplicationUserId { get; set; }

    public virtual ICollection<Advertisement_Category> Advertisement_Category { get; set; }

    public virtual ApplicationUser ApplicationUser { get; set; }

    public Advertisement()
    {
      Advertisement_Category = new HashSet<Advertisement_Category>();
    }
  }
}