using IrmandadeNsg.Domain.Models;
using IrmandadeNsg.Domain.Validations;
using System;
using System.Collections.Generic;

namespace IrmandadeNsg.Domain.Commands
{
    public class UpdatePostCommand : PostCommand
    {
        public UpdatePostCommand(Guid id, string title, string body, string image, string description, string tags, string category, DateTime created, List<MainComment> mainComments)
        {
            Id = id;
            Title = title;
            Body = body;
            Image = image;
            Description = description;
            Tags = tags;
            Category = category;
            Created = created;
            MainComments = mainComments;
        }


        public override bool IsValid()
        {
            ValidationResult = new UpdatePostCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
