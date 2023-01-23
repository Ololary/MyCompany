using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;


public abstract class EntityBase
{
    protected EntityBase()=> DateAdded= DateTime.UtcNow;

    [System.ComponentModel.DataAnnotations.Required]
    public Guid Id { get; set; }

    [Display(Name ="�������� (���������)")]
    public virtual string? Title { get; set; }

    [Display(Name = "������� ��������")]
    public virtual string? Subtitle { get; set; }

    [Display(Name = "������ ��������")]
    public virtual string? Text { get; set; }

    [Display(Name = "��������� ��������")]
    public virtual string? TitleImagePath { get; set; }

    [Display(Name = "SEO ������� Title")]
    public string? Metatitle { get; set; }

    [Display(Name = "SEO ������� Description")]
    public string? MetaDiscription { get; set; }

    [Display(Name = "SEO ������� KeyWords")]
    public string? MetaKeywords { get; set; }

    [DataType(DataType.Time)]
    public DateTime DateAdded { get; set; }
}