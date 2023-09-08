//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ProjNomInv.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ProjNomInv
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ProjNomInvSp(string StartingProjNum = null,
		string EndingProjNum = null,
		string StartingInvMsNum = null,
		string EndingInvMsNum = null,
		string StartingInvNum = null,
		string EndingInvNum = null,
		int? PrintMilestoneNotes = null,
		int? PrintCustomerNotes = null,
		int? PrintProjectNotes = null,
		int? PrintStandardNotes = null,
		int? PrintEuroTotal = null,
		int? XLateToDomestic = null,
		int? ShowInternal = null,
		int? ShowExternal = null,
		int? DisplayHeader = null,
		int? TaskID = null,
		string Username = null,
		string BGSessionId = null,
		int? PrintDiscountAmt = 0,
		string pSite = null,
		string BGUser = null);
	}
}

