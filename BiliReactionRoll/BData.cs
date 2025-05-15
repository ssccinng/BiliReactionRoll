using System;
using System.Collections.Generic;
using System.Text;

namespace BiliReactionRoll
{

    public class BData
    {
        public int code { get; set; }
        public string message { get; set; }
        public int ttl { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public bool has_more { get; set; }
        public Item[] items { get; set; }
        public string offset { get; set; }
        public int total { get; set; }
    }

    public class Item
    {
        public string action { get; set; }
        public int attend { get; set; }
        public string desc { get; set; }
        public string face { get; set; }
        public string mid { get; set; }
        public string name { get; set; }
    }

}
