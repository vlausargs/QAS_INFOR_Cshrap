//PROJECT NAME: Finance
//CLASS NAME: IARGetChargebackAcct.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.AR
{
	public interface IARGetChargebackAcct
	{
		(int? ReturnCode,
			string PChargebackAcct,
			string PChargebackAcctUnit1,
			string PChargebackAcctUnit2,
			string PChargebackAcctUnit3,
			string PChargebackAcctUnit4,
			string Infobar) ARGetChargebackAcctSp(
			string PCustNum,
			int? PCheckNum,
			string PChargebackType,
			int? PChargebackSeq,
			string PChargebackAcct,
			string PChargebackAcctUnit1,
			string PChargebackAcctUnit2,
			string PChargebackAcctUnit3,
			string PChargebackAcctUnit4,
			string Infobar);
	}
}

