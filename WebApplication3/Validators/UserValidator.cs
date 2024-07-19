using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using WebApplication3.Data;
using WebApplication3.Models;
using WebApplication3.Request;

namespace WebApplication3.Validators
{
    public class UserLoginValidator: AbstractValidator<UserLogin>
    {
        public UserLoginValidator() { 
            RuleFor(x => x.Email).NotNull().EmailAddress().MaximumLength(255);
            RuleFor(x => x.Password).NotNull().MaximumLength(255);
        }
    }

    public class UserRegisterValidator: AbstractValidator<User>
    {
        private readonly ApiContext _context;

        public UserRegisterValidator(ApiContext context)
        {
            _context = context;

            RuleFor(x => x.Email)
                .NotNull()
                .EmailAddress()
                .MaximumLength(255)
                .Must((user, email) => _context.Users.FirstOrDefault(x => x.Email == email) == null);
            RuleFor(x => x.Password).NotNull().MinimumLength(8).MaximumLength(255);
        }
    }
}
