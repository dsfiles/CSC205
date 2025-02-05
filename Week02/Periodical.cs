using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week02
{
    public class Periodical : Publication
    {
        //public Publication(string title, string publisher, PublicationType type)
        public Periodical (string title, string publisher, PublicationType type) : base(title, publisher, type)
        { }
        public string IssueNumber { get; }
        public string Frequency { get; }
        public decimal PricePerIssue { get; private set; }

        //public override string ToString() => $"{(string.IsNullOrEmpty(Author) ? "" : Author + ", ")}{Title}";
    }
}
 