using System.ComponentModel.DataAnnotations;

namespace ManageApartments.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}