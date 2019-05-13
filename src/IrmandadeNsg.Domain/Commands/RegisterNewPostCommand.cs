using IrmandadeNsg.Domain.Models;
using IrmandadeNsg.Domain.Validations;
using System;
using System.Collections.Generic;

namespace IrmandadeNsg.Domain.Commands
{
    public class RegisterNewPostCommand : PostCommand
    {
        public RegisterNewPostCommand(string title, string body, string image, string description, string tags, string category, DateTime created, IList<MainComment> mainComments)
        {
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
            ValidationResult = new RegisterNewPostCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
