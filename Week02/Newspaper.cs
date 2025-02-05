using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week02
{
    public sealed class Newspaper : Periodical
    {
        
        public Newspaper(string title, string publisher, PublicationType type, string issue) : base(title, publisher, PublicationType.Newspaper)
        {
        }
        public override string ToString() => $"title: {Title}, issue: {IssueNumber}";
    }
}
