
using System;

namespace SmartSolutions
{
    class Program
    {
        static void Main(string[] args)
        {
            SearchParams searchParams = new SearchParams();
            searchParams.TopItems = 2;
            searchParams.Items = new string[] { "Elmo", "elsa", "legos", "drone" };
            searchParams.Quotes = new string[]
            {
                "Elmo is the hottest of the season! Elmo will be on every kid's wishlist!",
                "The new Elmo dolls are super high quality",
                "Expect the Elsa dolls to be very popular this year, Elsa!",
                "Elsa and Elmo are the toys I'll be buying for my kids, Elsa is good",
                "For parents of older kids, look into buying them a drone",
                "Warcraft is slowly rising in popularity ahead of the holiday season"
            };

            TopItemSearchEngine topItemSearchEngine = new TopItemSearchEngine();
            var result = topItemSearchEngine.RecieveMostPopularItem(searchParams);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}


