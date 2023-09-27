using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace basement_learn_v1.Models;

public class Category
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(30 ,ErrorMessage = "Max Length is 30")]
    [DisplayName("Category Name")]
    public string Name { get; set; }
    [DisplayName("Display Order")]
    [Range(1,50 , ErrorMessage = "Range 1-50")]
    public int DisplayOrder { get; set; }
}
