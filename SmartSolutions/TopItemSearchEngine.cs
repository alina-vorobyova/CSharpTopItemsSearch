using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartSolutions
{
    class TopItemSearchEngine
    {
        readonly char[] punctuationMarks = { ' ', '+', ',', '.', '-', '\'', '"', '&', '!', '?', ':', ';', '#', '~', '=', '/', '$', '£', '^', '(', ')', '_', '<', '>' };
        Dictionary<string, PopularItem> popularItems = new Dictionary<string, PopularItem>();
        string[] words;

        public IEnumerable<string> RecieveMostPopularItem(SearchParams searchParams)
        {
            return ReceiveMostPopularItem(
                searchParams.NumToys,
                searchParams.TopItems,
                searchParams.Items,
                searchParams.NumQuotes,
                searchParams.Quotes);
        }

        public IEnumerable<string> ReceiveMostPopularItem(int numToys, int topToys, IEnumerable<string> toys, int numQuotes, IEnumerable<string> quotes)
        {
            var popularItems = TopItemSearch(toys, quotes);

            return popularItems
                .Values
                .OrderByDescending(x => x.Count)
                .ThenByDescending(x => x.CountOfQuotes)
                .ThenBy(x => x.Name)
                .Take(topToys)
                .Select(x => x.Name);
        }

        private Dictionary<string, PopularItem> TopItemSearch(IEnumerable<string> items, IEnumerable<string> quotes)
        {
            foreach (var quote in quotes)
            {
                words = quote.ToLower().Split(punctuationMarks);
                foreach (var word in words)
                {
                    if (items.Select(x => x.ToLower()).Contains(word))
                    {
                        if (!popularItems.ContainsKey(word))
                            AddPopularItem(word);
                        else
                            popularItems[word].Count++;
                    }
                }
                foreach (var item in popularItems.Values)
                {
                    if (quote.Contains(item.Name, StringComparison.OrdinalIgnoreCase))
                        item.CountOfQuotes++;
                }
            }
            return popularItems;
        }

        private void AddPopularItem(string popularItemName)
        {
            popularItems.Add(popularItemName, new PopularItem
            {
                Name = popularItemName,
                Count = 1,
                CountOfQuotes = 0
            });
        }
    }
}