using System;

namespace CDServiceWCF.Entity
{
	public class SearchCDs_Binder_Input
	{
		public int BinderNo;
		public int Page;

		public SearchCDs_Binder_Input()
		{
			this.BinderNo = -1;
			this.Page = -1;
		}
	}
}
