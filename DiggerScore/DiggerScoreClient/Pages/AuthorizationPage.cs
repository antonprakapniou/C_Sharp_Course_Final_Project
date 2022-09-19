using DiggerScoreClient.BaseModels;
using DiggerScoreClient.MainModels;
using DiggerScoreClient.Repositories;
using Validation;

namespace DiggerScoreClient.Pages
{
    public sealed class AuthorizationPage :BasePage, IDisposable
    {
        public override string? PageName { get; set; } = "Authorization page";

        public User? CurrentUser { get; set; }

        public AuthorizationPage()
        {
            Console.WriteLine(
                    "Press\n" +
                    "<< 1 >> to registration\n" +
                    "<< other key >> to login");

            using UserRepository _ = new();
            {
                if (Console.ReadLine()!.Equals("1"))
                {
                    Task<User> task = _.CreateAndGetAsync();
                    task.Wait();
                    CurrentUser=task.Result;

                    using (UserActionHistoryRepository repos = new())
                    {
                        repos.Create(new(CurrentUser.Name, "registered"));
                    }
                }

                else
                {
                    Task<User> task = _.GetByLoginAndPasswordAsync();
                    task.Wait();
                    CurrentUser=task.Result;

                    using (UserActionHistoryRepository repos = new())
                    {
                        repos.Create(new(CurrentUser.Name, "login"));
                    }
                }
            }

            Console.WriteLine($"\nYour data\n{CurrentUser}");            

            Log!.Information($"{CurrentUser.Name} {CurrentUser.Login} logged in".WithCurrentThreadId());

            Console.WriteLine(
                "Press\n" +
                "<< 1 >> to change any points\n" +
                "<< other key >> to continue");

            string? answer = Console.ReadLine();

            if (answer!.Equals("1"))
            {
                UserDataUpdatePage page = new(CurrentUser);
                CurrentUser=page.NewUser;
                Console.WriteLine($"\nYour new data\n{CurrentUser}");
            }
        }

        public void Dispose() { }
    }
}