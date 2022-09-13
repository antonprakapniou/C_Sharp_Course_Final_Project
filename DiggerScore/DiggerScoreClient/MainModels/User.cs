using Validation;

namespace DiggerScoreClient.MainModels
{
    public sealed class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Delivery { get; set; }
        public DateTime? Creation { get; set; }

        public User(string? name, string? login, string? password, string? phoneNumber, string? email, string? delivery)
        {
            Name = name;
            Login = login;
            Password = password;
            PhoneNumber = phoneNumber;
            Email = email;
            Delivery = delivery;
            Creation = DateTime.UtcNow;
        }

        public override string ToString() =>
            $"\nName: {Name}\n" +
            $"Login: {Login}\n" +
            $"Password: {Password!.ToHiddenString()}\n" +
            $"Phone number: {PhoneNumber}\n" +
            $"Email: {Email}\n" +
            $"Delivery: {Delivery}\n" +
            $"Creatinon: {Creation}";
    }
}