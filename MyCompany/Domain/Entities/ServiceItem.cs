using System.ComponentModel.DataAnnotations;

public class Serviceitem : EntityBase
{
    [Required(ErrorMessage ="��������� �������� ������")]
    [Display(Name = "�������� ������")]
    public override string? Title { get; set; }

    [Display(Name = "������� �������� ������")]
    public override string? Subtitle { get; set; }

    [Display(Name = "������ �������� ������")]
    public override string? Text { get; set; }


}