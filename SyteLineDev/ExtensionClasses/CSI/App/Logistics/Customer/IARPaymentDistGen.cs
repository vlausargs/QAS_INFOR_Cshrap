//PROJECT NAME: Logistics
//CLASS NAME: IARPaymentDistGen.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IARPaymentDistGen
	{
		(int? ReturnCode, string CallVar,
		string ParmsSite,
		string Infobar) ARPaymentDistGenSp(string PBankCode,
		string PCustNum,
		string PType,
		int? PCheckNum,
		int? PReapplication,
		string POpenType,
		string CallVar,
		string ParmsSite,
		string Infobar,
		string CreditMemoNum = null);
	}
}

