//PROJECT NAME: Logistics
//CLASS NAME: ICLM_FTSLDocumentListing.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface ICLM_FTSLDocumentListing
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_FTSLDocumentListingSp(string Job = null,
		int? Suffix = null,
		int? ViewJob = 0,
		int? ReadSyteLine = 0,
		int? Operation = null,
		string Item = null,
		int? ViewOperation = 0,
		int? ViewItem = 0,
		int? ReadDocTrak = 0);
	}
}

