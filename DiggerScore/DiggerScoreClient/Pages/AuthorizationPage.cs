using DiggerScoreClient.BaseModels;
using DiggerScoreClient.MainModels;
using DiggerScoreClient.Repositories;

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
                string? answer = Console.ReadLine();

                if (answer!.Equals("1"))
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

            Console.WriteLine("Your data");
            Console.WriteLine(CurrentUser);
            Console.WriteLine("Enter << Escape >> to continue");
            while (Console.ReadKey().Key!=ConsoleKey.Escape) { }
        }

        public void Dispose() { }
    }
}