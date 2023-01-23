using System.ComponentModel.DataAnnotations;

public class Serviceitem : EntityBase
{
    [Required(ErrorMessage ="Заполните назвагие услуги")]
    [Display(Name = "Название услуги")]
    public override string? Title { get; set; }

    [Display(Name = "Краткое описание услуги")]
    public override string? Subtitle { get; set; }

    [Display(Name = "Полное описание услуги")]
    public override string? Text { get; set; }


}