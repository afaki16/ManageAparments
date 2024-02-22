
namespace ManageApartments.Domain.LoginImage.Dtos
{
    public class CreateLoginImageInput
    {
        public string PhotoUrl { get; set; }
        public Base64FileUpload? Base64FileUpload { get; set; }
    }
}
