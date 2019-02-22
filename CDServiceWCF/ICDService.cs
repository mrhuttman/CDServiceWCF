using CDServiceWCF.Entity;
using DAO;
using System;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace CDServiceWCF
{
	[ServiceContract]
	public interface ICDService
	{
		[OperationContract, WebInvoke(ResponseFormat = WebMessageFormat.Json)]
		string AddCD(Media_Music_CDs CD);

		[OperationContract, WebInvoke(ResponseFormat = WebMessageFormat.Json)]
		string DeleteCD(int ID);

        [OperationContract, WebInvoke(ResponseFormat = WebMessageFormat.Json)]
        int GetBindersCount();

        [OperationContract, WebInvoke(ResponseFormat = WebMessageFormat.Json)]
        CDSearchResult GetBindersDistinct();

        [OperationContract, WebInvoke(ResponseFormat = WebMessageFormat.Json)]
		Media_Music_CDs GetCD(int ID);

        [OperationContract, WebInvoke(ResponseFormat = WebMessageFormat.Json)]
        int GetCDsCount();

        [OperationContract, WebInvoke(ResponseFormat = WebMessageFormat.Json)]
        CDSearchResult GetGenresDistinct();

        [OperationContract, WebInvoke(ResponseFormat = WebMessageFormat.Json)]
		CDSearchResult SearchCDs_NoFilter(int Page);

		[OperationContract, WebInvoke(ResponseFormat = WebMessageFormat.Json)]
		CDSearchResult SearchCDs_Artist(SearchCDs_Artist_Input input);

		[OperationContract, WebInvoke(ResponseFormat = WebMessageFormat.Json)]
		CDSearchResult SearchCDs_Title(SearchCDs_Title_Input input);

		[OperationContract, WebInvoke(ResponseFormat = WebMessageFormat.Json)]
		CDSearchResult SearchCDs_Binder(SearchCDs_Binder_Input input);

        [OperationContract, WebInvoke(ResponseFormat = WebMessageFormat.Json)]
        CDSearchResult SearchCDs_Genre(SearchCDs_Genre_Input input);

        [OperationContract, WebInvoke(ResponseFormat = WebMessageFormat.Json)]
        CDSearchResult SearchCDs_Advanced(SearchCDs_Advanced_Input input);

        [OperationContract, WebInvoke(ResponseFormat = WebMessageFormat.Json)]
		string UpdateCD(Media_Music_CDs CD);
	}
}
