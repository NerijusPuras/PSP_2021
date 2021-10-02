using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteka
{
    public class ValidationRule
    {
        public ValidationRule(int length, string prefix)
        {
            this.length = length;
            this.prefix = prefix;
        }

        public int length { get; set; }
        public string prefix { get; set; }
    }
}
