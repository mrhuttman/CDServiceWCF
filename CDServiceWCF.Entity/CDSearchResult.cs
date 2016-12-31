using DAO;
using System;
using System.Collections.Generic;

namespace CDServiceWCF.Entity
{
	public class CDSearchResult
	{
		public List<Media_Music_CDs> CDs;

		public string Response;

		public int NumRows;

        public int TotalNumRows;

		public CDSearchResult()
		{
			this.CDs = new List<Media_Music_CDs>();
			this.Response = string.Empty;
			this.NumRows = -1;
            this.TotalNumRows = -1;
		}
	}
}
