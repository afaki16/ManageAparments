using Abp.Application.Services.Dto;

namespace ManageApartments.Domain.LoginImage.Dtos
{
    public class LoginImageFullOutput : EntityDto<int>
    {
        public string PhotoUrl { get; set; }
        public Base64FileUpload? Base64FileUpload { get; set; }
    }
}
