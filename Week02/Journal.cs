using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week02
{
    public sealed class Journal : Periodical
    {

        public Journal(string title, string publisher, PublicationType type, string issue) : base(title, publisher, PublicationType.Journal)
        {
        }
        public override string ToString() => $"title: {Title}, issue: {IssueNumber}";
    }
}
