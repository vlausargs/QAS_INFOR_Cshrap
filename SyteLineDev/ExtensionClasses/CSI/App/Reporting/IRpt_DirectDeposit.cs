//PROJECT NAME: Reporting
//CLASS NAME: IRpt_DirectDeposit.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_DirectDeposit
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_DirectDepositSp(DateTime? StartingTransDate = null,
			DateTime? EndingTransDate = null,
			string StartingEmpNum = null,
			string EndingEmpNum = null,
			int? ExOptdfDispPrenot = 0,
			int? ExOptdfDispPRec = 0,
			string ExOptdfEmplType = null,
			int? StartDateOffset = null,
			int? EndDateOffset = null,
			int? PDisplayHeader = 1,
			string StartEmpCategory = null,
			string EndEmpCategory = null,
			string pSite = null);
	}
}

