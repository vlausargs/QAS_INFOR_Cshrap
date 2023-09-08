//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSKbaseSearch.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.CallCenter
{
	public interface ISSSFSKbaseSearch
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSFSKbaseSearchSp(string SearchType,
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

