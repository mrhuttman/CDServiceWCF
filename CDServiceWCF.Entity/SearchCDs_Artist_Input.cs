namespace CDServiceWCF.Entity
{
    public class SearchCDs_Artist_Input
	{
		public string Artist;
		public int Page;

		public SearchCDs_Artist_Input()
		{
			this.Artist = string.Empty;
			this.Page = -1;
		}
	}
}
