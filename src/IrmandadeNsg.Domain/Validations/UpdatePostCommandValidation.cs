using IrmandadeNsg.Domain.Commands;

namespace IrmandadeNsg.Domain.Validations
{
    public class UpdatePostCommandValidation : PostValidation<UpdatePostCommand>
    {
        public UpdatePostCommandValidation()
        {
            ValidateId();
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
