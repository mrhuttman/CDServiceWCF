using System;

namespace CDServiceWCF.Entity
{
    public class SearchCDs_Genre_Input
    {
        public string Genre;
        public int Page;

        public SearchCDs_Genre_Input()
        {
            this.Genre = string.Empty;
            this.Page = -1;
        }
    }
}