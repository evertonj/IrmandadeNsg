using FluentValidation;
using IrmandadeNsg.Domain.Commands;
using System;

namespace IrmandadeNsg.Domain.Validations
{
    public abstract class PostValidation<T> : AbstractValidator<T> where T : PostCommand
    {
        protected void ValidateId()
        {
            RuleFor(post => post.Id)
                .NotEqual(Guid.Empty);
        }
        protected void ValidateTitle()
        {
            RuleFor(post => post.Title).NotEmpty()
                .Length(2, 150).WithMessage("The Title must have between 2 and 150 characters"); 
        }
        protected void ValidateBody()
        {
            RuleFor(post => post.Body).NotEmpty();
        }
        protected void ValidateImage()
        {
            RuleFor(post => post.Image).NotEmpty();
        }
        protected void ValidateDescription()
        {
            RuleFor(post => post.Description).NotEmpty();
        }
        protected void ValidateTags()
        {
            RuleFor(post => post.Tags).NotEmpty();
        }
        protected void ValidateCategory()
        {
            RuleFor(post => post.Category).NotEmpty();
        }
        protected void ValidateCreated()
        {
            RuleFor(post => post.Created).NotEmpty();
        }

        protected void ValidateMainComments()
        {
            RuleFor(post => post.MainComments).NotEmpty();
        }
    }
}
