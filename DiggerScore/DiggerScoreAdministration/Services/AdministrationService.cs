using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DiggerScoreAdministration.Services
{
    public sealed class AdministrationService
    {
        public static int GetOrderHistoryCount()
        {
            using (DiggerScoreDbContext db = new())
            {
                return db.OrderActionHistories.ToList().Count;
            }
        }

        public static int GetUserHistoryCount()
        {
            using (DiggerScoreDbContext db = new())
            {
                return db.UserActionHistories.ToList().Count;
            }
        }

        public static async Task<int> GetOrderHistoryCountAsync()
        {
            using (DiggerScoreDbContext db = new())
            {
                await Task.Delay(0);
                return GetOrderHistoryCount();
            }
        }

        public static async Task<int> GetUserHistoryCountAsync()
        {
            using (DiggerScoreDbContext db = new())
            {
                await Task.Delay(0);
                return GetUserHistoryCount();
            }
        }

        public static void GetNewOrderActionHistory()
        {
            string? connectionString = @"D:\GitHubRepositories\C_Sharp_Course_Final_Project\DiggerScore\DiggerScoreAdministration\.json\CurrentCount.json";

            HistoryCount? previosHistoryCount = default;

            using (FileStream _ = new FileStream(connectionString, FileMode.OpenOrCreate))
            {
                previosHistoryCount = JsonSerializer.Deserialize<HistoryCount>(_)!;
            }

            int previosOrderCount = previosHistoryCount.OrderHistoryCount;
            Task<int> task1 = GetOrderHistoryCountAsync();
            task1.Wait();
            int newOrderCount = task1.Result;

            Task<int> task2 = GetUserHistoryCountAsync();
            task1.Wait();
            int newUserCount = task2.Result;

            Console.WriteLine($"User activity: {newUserCount}");
            Console.WriteLine($"Orders: {newOrderCount}");

            if (newOrderCount>previosOrderCount)
            {
                Console.WriteLine("You have new order(s)");
                Console.ForegroundColor=ConsoleColor.DarkGray;

                using (DiggerScoreDbContext db = new())
                {
                    List<OrderActionHistory> newOrderList = db.OrderActionHistories.ToList();
                    foreach (var item in db.OrderActionHistories.ToList())
                    {
                        if (item.Id>previosOrderCount) Console.WriteLine(item);
                    }
                }
            }

            using (StreamWriter _ = new(connectionString, false)) { }

            using (FileStream _ = new(connectionString, FileMode.Create))
            {
                JsonSerializer.Serialize<HistoryCount>(_, new(newOrderCount,newUserCount));
            }
        }

        public static async Task GetNewOrderActionHistoryAsync()
        {
            await Task.Run(() => GetNewOrderActionHistory());
        }
    }
}
