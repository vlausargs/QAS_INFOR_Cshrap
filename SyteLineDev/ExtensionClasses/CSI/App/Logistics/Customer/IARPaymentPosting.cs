//PROJECT NAME: Logistics
//CLASS NAME: IARPaymentPosting.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IARPaymentPosting
	{
		(int? ReturnCode, string Infobar) ARPaymentPostingSp(Guid? PSessionID,
		Guid? PProcessID,
		string PCustNum,
		string PBankCode,
		string PType,
		int? PCheckNum,
		string Infobar,
		string CreditMemoNum = null);
	}
}

