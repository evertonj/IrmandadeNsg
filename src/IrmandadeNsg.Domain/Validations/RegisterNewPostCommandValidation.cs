using IrmandadeNsg.Domain.Commands;

namespace IrmandadeNsg.Domain.Validations
{
    public class RegisterNewPostCommandValidation : PostValidation<RegisterNewPostCommand>
    {
        public RegisterNewPostCommandValidation()
        {
            ValidateTitle();
            ValidateBody();
            ValidateCategory();
            ValidateDescription();
            ValidateImage();
            ValidateTags();
            ValidateCreated();
        }
    }
}
