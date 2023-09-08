//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSAcmCreate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSAcmCreate
	{
		(int? ReturnCode,
			string Acct,
			string AcctUnit1,
			string AcctUnit2,
			string AcctUnit3,
			string AcctUnit4,
			string Infobar) SSSFSAcmCreateSp(
			string RefType,
			string RefNum,
			int? RefLine,
			int? RefRelease,
			string InvNum,
			int? InvLine,
			string CustNum,
			string Whse,
			string ProductCode,
			decimal? Amount,
			int? Periods,
			int? CreateLines,
			DateTime? StartDate,
			string Acct,
			string AcctUnit1,
			string AcctUnit2,
			string AcctUnit3,
			string AcctUnit4,
			string Infobar);
	}
}

