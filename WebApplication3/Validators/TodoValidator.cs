using FluentValidation;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Request;

namespace WebApplication3.Validators
{
    public class TodoCreateValidator : AbstractValidator<TodoCreate>
    {
        private readonly ApiContext _context;

        public TodoCreateValidator(ApiContext context)
        {
            _context = context;

            RuleFor(x => x.Title).MaximumLength(50);
            RuleFor(x => x.Description).MaximumLength(255);
            RuleFor(x => x.Sum).NotNull().InclusiveBetween(1, 100000000);
            RuleFor(x => x.Date).NotNull();
            RuleFor(x => x.CategoryId).NotNull().Must((category, categoryId) =>
            {
                return _context.Categories.FirstOrDefault(x => x.Id == categoryId) != null;
            });
        }
    }

    public class TodoUpdateValidator : AbstractValidator<TodoUpdate>
    {
        private readonly ApiContext _context;

        public TodoUpdateValidator(ApiContext context)
        {
            _context = context;

            RuleFor(x => x.Title).MaximumLength(50);
            RuleFor(x => x.Description).MaximumLength(255);
            RuleFor(x => x.Sum).NotNull().InclusiveBetween(1, 100000000);
            RuleFor(x => x.Date).NotNull();
            RuleFor(x => x.CategoryId).NotNull().Must((category, categoryId) =>
            {
                return _context.Categories.FirstOrDefault(x => x.Id == categoryId) != null;
            });
        }
    }
}
