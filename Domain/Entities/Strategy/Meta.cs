using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Strategy
{
    public class Meta
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public Meta(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }
}
