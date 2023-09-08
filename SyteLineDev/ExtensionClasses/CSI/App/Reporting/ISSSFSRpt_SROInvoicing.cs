//PROJECT NAME: Reporting
//CLASS NAME: ISSSFSRpt_SROInvoicing.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface ISSSFSRpt_SROInvoicing
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) SSSFSRpt_SROInvoicingSp(string Mode = "ToBeInvoiced",
		string PBegSroNum = null,
		string PEndSroNum = null,
		int? PBegSroLine = null,
		int? PEndSroLine = null,
		int? PBegSroOper = null,
		int? PEndSroOper = null,
		string PBegBillMgr = null,
		string PEndBillMgr = null,
		string PBegCustNum = null,
		string PEndCustNum = null,
		string PBegRegion = null,
		string PEndRegion = null,
		DateTime? PBegTransDate = null,
		DateTime? PEndTransDate = null,
		DateTime? PBegCloseDate = null,
		DateTime? PEndCloseDate = null,
		int? PInclCalculated = 1,
		int? PInclProject = 1,
		string PInvCred = "I",
		DateTime? PInvDate = null,
		int? PTransDom = 0,
		string SortBy = "S",
		string StartInvNum = null,
		string EndInvNum = null,
		DateTime? StartInvDate = null,
		DateTime? EndInvDate = null,
		string MooreForm = "N",
		int? PrintCustomerNotes = 0,
		int? PrintSRONotes = 0,
		int? PrintSROLineNotes = 0,
		int? PrintSROOperNotes = 0,
		int? PrintTransNotes = 0,
		int? PrintInternalNotes = 0,
		int? PrintExternalNotes = 0,
		int? PrintSerials = 0,
		int? PrintMatl = 0,
		int? PrintLabor = 0,
		int? PrintMisc = 0,
		int? SummarizeTrans = 0,
		string BillCustCons = "U",
		int? PrintEuroTotal = 0,
		int? InclBillHold = 1,
		string OperationStatus = "I",
		int? DisplayHeader = null,
		string OrderBy = "N",
		string Infobar = null,
		string pSite = null);
	}
}

