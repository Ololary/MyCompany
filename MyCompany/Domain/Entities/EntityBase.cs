using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;


public abstract class EntityBase
{
    protected EntityBase()=> DateAdded= DateTime.UtcNow;

    [System.ComponentModel.DataAnnotations.Required]
    public Guid Id { get; set; }

    [Display(Name ="Название (заголовок)")]
    public virtual string? Title { get; set; }

    [Display(Name = "Краткое описание")]
    public virtual string? Subtitle { get; set; }

    [Display(Name = "Полное описание")]
    public virtual string? Text { get; set; }

    [Display(Name = "Титульная картинка")]
    public virtual string? TitleImagePath { get; set; }

    [Display(Name = "SEO метатег Title")]
    public string? Metatitle { get; set; }

    [Display(Name = "SEO метатег Description")]
    public string? MetaDiscription { get; set; }

    [Display(Name = "SEO метатег KeyWords")]
    public string? MetaKeywords { get; set; }

    [DataType(DataType.Time)]
    public DateTime DateAdded { get; set; }
}