using System.ComponentModel.DataAnnotations;

public class LoginViewModels
{
    [Required]
    [Display(Name = "�����")]
    public string? UserName { get; set; }

    [Required]
    [UIHint("password")]
    [Display(Name = "������")]
    public string? Password { get; set; }

    [Display(Name = "��������� ����?")]
    public bool RememberMe { get; set;}

}