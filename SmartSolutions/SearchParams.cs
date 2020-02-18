using System;
using System.Collections.Generic;
using System.Text;

namespace SmartSolutions
{
    class SearchParams
    {
        public int NumToys { get; set; }
        public int TopItems { get; set; }
        public IEnumerable<string> Items { get; set; }
        public int NumQuotes { get; set; }
        public IEnumerable<string> Quotes { get; set; }
    }
}
