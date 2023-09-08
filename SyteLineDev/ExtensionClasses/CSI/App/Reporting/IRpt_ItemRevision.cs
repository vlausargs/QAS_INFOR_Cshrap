//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ItemRevision.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ItemRevision
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ItemRevisionSp(string ItemStarting = null,
		string ItemEnding = null,
		string RevisionStarting = null,
		string RevisionEnding = null,
		string ProdCodeStarting = null,
		string ProdCodeEnding = null,
		string ExOptacAbcCode = null,
		int? OperNumStarting = null,
		int? OperNumEnding = null,
		int? ECNNumStarting = null,
		int? ECNNumEnding = null,
		int? PJobRefs = null,
		int? PItemManufacture = null,
		int? PECNItem = null,
		int? HighlightRevDiff = null,
		int? PJobrouteNote = null,
		int? PJobmatlNote = null,
		int? PECNItemNote = null,
		int? PageOper = null,
		int? ExOptacChkEffDates = null,
		DateTime? ExOptdfEffDate = null,
		int? ShowInternal = 1,
		int? ShowExternal = 1,
		int? ExOptdfEffDateOffset = null,
		string SummaryDetail = null,
		string SiteGroup = null,
		int? DisplayHeader = null,
		string BGSessionId = null,
		string pSite = null);
	}
}

