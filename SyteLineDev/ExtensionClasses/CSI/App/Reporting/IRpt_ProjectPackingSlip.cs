//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ProjectPackingSlip.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ProjectPackingSlip
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ProjectPackingSlipSp(string PckCall,
		int? MinPackNum = null,
		int? MaxPackNum = null,
		int? PrintProjNotes = 0,
		int? PrintResNotes = 0,
		int? ShowInternal = 0,
		int? ShowExternal = 0,
		int? DisplayHeader = 0,
		int? ActiveStatus = 1,
		int? InActiveStatus = 1,
		int? CompleteStatus = 1,
		int? IncludeSN = 0,
		string pSite = null);
	}
}

