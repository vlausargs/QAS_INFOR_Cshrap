//PROJECT NAME: Finance
//CLASS NAME: IApproveChargeback.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.AR
{
	public interface IApproveChargeback
	{
		(int? ReturnCode,
			string InfoBar) ApproveChargebackSp(
			Guid? RowPointer,
			string CustNum,
			string ChargebackInvNum,
			string InvNum,
			string ChargebackType,
			decimal? Amount,
			int? CheckNum,
			int? ChargebackSeq,
			string InfoBar);
	}
}

