using DiggerScoreClient.BaseModels;
using DiggerScoreClient.Contexts;
using DiggerScoreClient.MainModels;
using DiggerScoreClient.Repositories;
using Validation;

namespace DiggerScoreClient.Pages
{
    public sealed class UserDataUpdatePage:BasePage
    {
        public override string? PageName { get; set; } = "User data update page";

        public User? NewUser { get; set; }

        public UserDataUpdatePage(User? user)
        {
            using (DiggerScoreDbContext db=new())
            {
                try
                {
                    NewUser=db.Users.ToList().First(_=>_.Login!.Equals(user!.Login));
                    while (true)
                    {
                        Console.Clear();

                        Console.WriteLine(

                             "Press\n" +
                             "<< 1 >> to change name\n" +
                             "<< 2 >> to change password\n" +
                             "<< 3 >> to change phoneNumber\n" +
                             "<< 4 >> to change email\n" +
                             "<< 5 >> to change delivery\n"+
                             "<< other key >> to back to shopping");

                        string? answer = Console.ReadLine();

                        if (answer!.Equals("1"))
                        {
                            NewUser.Name=PropertyConsoleInput.Name("New name is");
                            db.SaveChanges();
                        }

                        else if (answer!.Equals("2"))
                        {
                            NewUser.Password=PropertyConsoleInput.Password("New password is");
                            db.SaveChanges();
                        }

                        else if (answer!.Equals("3"))
                        {
                            NewUser.PhoneNumber=PropertyConsoleInput.PhoneNumber("New phone number is");
                            db.SaveChanges();
                        }

                        else if (answer!.Equals("4"))
                        {
                            NewUser.Email=PropertyConsoleInput.Email("New email is");
                            db.SaveChanges();
                        }

                        else if (answer!.Equals("5"))
                        {
                            NewUser.Delivery=TypeConsoleInput.NotEmptyString("New delivery is", "Delivery cannot be empty");
                            db.SaveChanges();
                        }

                        else break;

                        using (UserActionHistoryRepository _ = new())
                        {
                            _.Create(new($"{NewUser!.Name} {NewUser.Login}", "update his data"));
                        }

                        Console.WriteLine($"\nYour new data\n{NewUser}");
                        Console.WriteLine("Enter << Escape >> to continue");
                        while (Console.ReadKey().Key!=ConsoleKey.Escape) { }
                    }                    
                }

                catch (Exception ex)
                {
                    Log!.Error(ex.Message.WithCurrentThreadId());
                }
            }
        }
    }
}