using System;

namespace Domain
{
    public class Сomment
    {
        public int Id { get; }

        public string UserName { get; }

        public string Email { get; }

        public string? HomePage { get; }

        public string Text { get; }

        public string Ip { get; }

        public string BrowserData { get; }

        public DateTime DateAdded { get; }

        public int? ParentId { get; }

        public Сomment(
            string userName,
            string email,
            string? homePage,
            string text,
            string ip,
            string browserData,
            int? parentId)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentException(nameof(userName));
            }

            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentException(nameof(email));
            }

            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentException(nameof(text));
            }

            if (string.IsNullOrEmpty(ip))
            {
                throw new ArgumentException(nameof(ip));
            }

            if (string.IsNullOrEmpty(browserData))
            {
                throw new ArgumentException(nameof(browserData));
            }

            UserName = userName;
            Email = email;
            HomePage = homePage;
            Text = text;
            Ip = ip;
            BrowserData = browserData;
            ParentId = parentId;

            DateAdded = DateTime.Now;
        }
    }
}
