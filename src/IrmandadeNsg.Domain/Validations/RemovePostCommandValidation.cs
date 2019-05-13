using IrmandadeNsg.Domain.Commands;

namespace IrmandadeNsg.Domain.Validations
{
    public class RemovePostCommandValidation : PostValidation<RemovePostCommand>
    {
        public RemovePostCommandValidation()
        {
            ValidateId();
        }
    }
}
