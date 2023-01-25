using System.ComponentModel.DataAnnotations;

public class TextField : EntityBase
{
    [Required]
    public string? CodeWord { get; set; }

    [Display(Name = "�������� ������� (��������)")]
    public override string? Title { get; set; } = "�������������� ��������";

    [Display(Name = "���������� ��������")]
    public override string? Text { get; set; } = "���������� ����������� ���������������";

}