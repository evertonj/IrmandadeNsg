using IrmandadeNsg.Domain.Core.Commands;
using IrmandadeNsg.Domain.Validations;
using System;

namespace IrmandadeNsg.Domain.Commands
{
    public class RemovePostCommand : PostCommand
    {

        public RemovePostCommand(Guid id)
        {
            AggregateId = id;
            Id = id;
        }
        public override bool IsValid()
        {
            ValidationResult = new RemovePostCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
