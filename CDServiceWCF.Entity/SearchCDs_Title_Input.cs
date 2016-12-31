using System;

namespace CDServiceWCF.Entity
{
	public class SearchCDs_Title_Input
	{
		public string Title;
		public int Page;

		public SearchCDs_Title_Input()
		{
			this.Title = string.Empty;
			this.Page = -1;
		}
	}
}
