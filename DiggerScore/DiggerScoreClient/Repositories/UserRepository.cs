using DiggerScoreClient.Contexts;
using DiggerScoreClient.Interfaces;
using DiggerScoreClient.MainModels;
using Validation;

namespace DiggerScoreClient.Repositories
{
    public class UserRepository : IDbRepository<User>, IDisposable
    {
        public void Create(User _)
        {
            using DiggerScoreDbContext db = new();

            db.Users.Add(_);
            db.SaveChanges();
        }

        public User CreateAndGet()
        {
            using DiggerScoreDbContext db = new();

            string? name = PropertyConsoleInput.Name("Name is");
            string? login = string.Empty;
            {
                while (true)
                {
                    string? inputLogin = TypeConsoleInput.NotEmptyString("Login is", "Login cannot be empty. Try again");
                    if (db.Users.ToList().Any(_ => _.Login!.Equals(inputLogin))) Console.WriteLine("This login already exists. Try again");
                    else
                    {
                        login = inputLogin;
                        break;
                    }
                }
            }

            string? password = PropertyConsoleInput.Password("Password is");
            string? phoneNumber = PropertyConsoleInput.PhoneNumber("Phone number is");
            string? email = PropertyConsoleInput.Email("Email is");
            string? delivery = TypeConsoleInput.NotEmptyString("Delivery is", "Delivery cannot be empty. Try again");

            User? user = new(name, login, password, phoneNumber, email, delivery);
            db.Users.Add(user);
            db.SaveChanges();

            return user;
        }

        public User GetByLoginAndPassword()
        {
            using DiggerScoreDbContext db = new();

            User? user = default;

            while (true)
            {
                string? login = TypeConsoleInput.NotEmptyString("Login is", "Login can not be empty. Try again");
                string? password = string.Empty;

                while (true)
                {
                    Console.Write("Password is ");
                    password = TypeConsoleInput.HiddenString();
                    Console.Write("Repeat password ");
                    string? repeatPassword = TypeConsoleInput.HiddenString();

                    if (password!.Equals(repeatPassword)) break;
                }

                if (db.Users.ToList().Any(_ => _.Login!.Equals(login) && _.Password!.Equals(password)))
                {
                    return user = db.Users.ToList().First(_ => _.Login!.Equals(login) && _.Password!.Equals(password));
                }

                else Console.WriteLine("No such user exists. Try again");
            }
        }

        public async Task<User> CreateAndGetAsync()
        {
            await Task.Delay(0);
            return CreateAndGet();
        }

        public async Task<User> GetByLoginAndPasswordAsync()
        {
            await Task.Delay(0);
            return GetByLoginAndPassword();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Read()
        {
            using DiggerScoreDbContext db = new();
            db.Users.ToList().ToConsoleTable(new Dictionary<string, string>
            {
                ["Id"] = "Id",
                ["Name"] = "Name",
                ["Login"] = "Login",
                ["Password"] = "Password",
                ["Phone number"] = "PhoneNumber",
                ["Email"] = "Email",
                ["Delivery"] = "Delivery",
                ["Creation"] = "Creation"
            });
        }

        public void Update(int id) { }

        void IDisposable.Dispose() { }
    }
}