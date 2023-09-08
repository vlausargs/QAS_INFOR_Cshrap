//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSPortalKbaseSearch.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.CallCenter
{
	public interface ISSSFSPortalKbaseSearch
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSFSPortalKbaseSearchSp(string SearchType,
		string SearchText,
		int? SearchKeywords,
		int? SearchDescription,
		int? SearchSummary,
		int? SearchResolution,
		string CatGeneral,
		string CatSpecific,
		string CreatedBy,
		string UpdatedBy,
		string AvailableList);
	}
}

