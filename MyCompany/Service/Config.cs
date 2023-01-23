public class Config
{
    //класс обёртка = его свойства соотвествуют свойствам из appsettings.json
    public static string? ConnectionString { get; set; }
    public static string? CompanyName { get; set; }
    public static string? CompanyPhone { get; set; }
    public static string? CompanyPhoneShort { get; set; }
    public static string? CompanyEmail { get; set; }


}