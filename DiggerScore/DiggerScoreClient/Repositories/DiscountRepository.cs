﻿using DiggerScoreClient.SubModels;
using System.Text.Json;

namespace DiggerScoreClient.Repositories
{
    public class DiscountRepository : IDisposable
    {
        public Discount Get()
        {
            using (FileStream fs = new FileStream(@"D:\GitHubRepositories\C_Sharp_Course_Final_Project\DiggerScore\DiggerScoreAdministration\.json\Discount.json", FileMode.OpenOrCreate))
            {
                return JsonSerializer.Deserialize<Discount>(fs)!;
            }
        }

        public void Dispose() { }
    }
}