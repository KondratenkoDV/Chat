using API.DTOs.Comment;
using FluentValidation;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace API.Helpers.Comment
{
    public class CreateCommentDtoValidator : AbstractValidator<CreateCommentDto>
    {
        public CreateCommentDtoValidator()
        {
            RuleFor(c => c.UserName).Length(2, 50);
            RuleFor(c => c.Email).Length(5, 50).EmailAddress();
            RuleFor(c => c.HomePage).Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _)).When(x => !string.IsNullOrEmpty(x.HomePage));
            RuleFor(c => c.Text).Length(2, 250).Must(HtmlTags);
            RuleFor(c => c.Ip).NotEmpty();
            RuleFor(c => c.BrowserData).NotEmpty();
        }

        private bool HtmlTags(string text)
        {
            var tag = @"<\s*([^ >]+)[^>]*>.*?<\s*/\s*\1\s*>";

            var tagHtml = @"<a\shref=””\stitle=””>|<\/a>|<code>|<\/code>|<i>|<\/i>|<strong>|<\/strong>";

            if (Regex.IsMatch(text, tag))
            {
                var htmlDoc = new HtmlDocument();

                htmlDoc.LoadHtml(text);

                if(htmlDoc.ParseErrors.Any())
                {
                    return false;
                }

                if (!Regex.IsMatch(text, tagHtml))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
