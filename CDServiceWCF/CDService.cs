using CDServiceWCF.Entity;
using DAO;
using System;
using System.ServiceModel.Activation;

namespace CDServiceWCF
{
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
	public class CDService : ICDService
	{
		public string AddCD(Media_Music_CDs CD)
		{
			string result;
			try
			{
				int newItemNo = CDs.AddCD(CD);
				bool flag = -1 != newItemNo;
				if (!flag)
				{
					throw new Exception("AddCD: Save was not successful.");
				}
				result = newItemNo.ToString();
			}
			catch (Exception ex)
			{
				result = ex.Message;
			}
			return result;
		}

		public string DeleteCD(int ID)
		{
			string result;
			try
			{
				CDs.DeleteCD(ID);
				result = "Success";
			}
			catch (Exception ex)
			{
				result = ex.Message;
			}
			return result;
		}

        public int GetBindersCount()
        {
            return CDs.GetBindersCount();
        }

		public Media_Music_CDs GetCD(int ID)
		{
			return CDs.GetCD(ID);
		}

        public int GetCDsCount()
        {
            return CDs.GetCDsCount();
        }

		public CDSearchResult SearchCDs_NoFilter(int Page)
		{            
            CDSearchResult result = new CDSearchResult();
            try
            {
                result.CDs = CDs.SearchCDs_NoFilter(Page);
                result.NumRows = result.CDs.Count;
                result.TotalNumRows = GetCDsCount();
                result.Response = "Success";
            }
            catch (Exception ex)
            {
                result.NumRows = -1;
                result.Response = ex.Message;
            }
            return result;
		}

		public CDSearchResult SearchCDs_Artist(SearchCDs_Artist_Input input)
		{
            CDSearchResult result = new CDSearchResult();
            try
            {
                result.CDs = CDs.SearchCDs_Artist(input.Artist, input.Page);
                result.NumRows = result.CDs.Count;
                result.TotalNumRows = CDs.SearchCDs_Artist_Count(input.Artist);
                result.Response = "Success";
            }
            catch (Exception ex)
            {
                result.NumRows = -1;
                result.Response = ex.Message;
            }
            return result;            
		}

		public CDSearchResult SearchCDs_Title(SearchCDs_Title_Input input)
		{
            CDSearchResult result = new CDSearchResult();
            try
            {
                result.CDs = CDs.SearchCDs_Title(input.Title, input.Page);
                result.NumRows = result.CDs.Count;
                result.TotalNumRows = CDs.SearchCDs_Title_Count(input.Title);
                result.Response = "Success";
            }
            catch (Exception ex)
            {
                result.NumRows = -1;
                result.Response = ex.Message;
            }
            return result;
        }

		public CDSearchResult SearchCDs_Binder(SearchCDs_Binder_Input input)
		{
            CDSearchResult result = new CDSearchResult();
            try
            {
                result.CDs = CDs.SearchCDs_Binder(input.BinderNo, input.Page);
                result.NumRows = result.CDs.Count;
                result.TotalNumRows = CDs.SearchCDs_Binder_Count(input.BinderNo);
                result.Response = "Success";
            }
            catch (Exception ex)
            {
                result.NumRows = -1;
                result.Response = ex.Message;
            }
            return result;
        }

        public CDSearchResult SearchCDs_Advanced(SearchCDs_Advanced_Input input)
        {
            CDSearchResult result = new CDSearchResult();
            try
            {
                result.CDs = CDs.SearchCDs_Advanced(input);
                result.NumRows = result.CDs.Count;
                result.TotalNumRows = CDs.SearchCDs_Advanced_Count(input);
                result.Response = "Success";
            }
            catch (Exception ex)
            {
                result.NumRows = -1;
                result.Response = ex.Message;
            }
            return result;
        }

		public string UpdateCD(Media_Music_CDs CD)
		{
            try
            {
                CDs.UpdateCD(CD);
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }			
		}


	}
}
