//PROJECT NAME: Logistics
//CLASS NAME: IAppmtValidatePayment.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IAppmtValidatePayment
	{
		(int? ReturnCode, string Infobar) AppmtValidatePaymentSp(string PVendNum,
		int? PCheckSeq,
		string PBankCode,
		int? PReapplication,
		string Infobar);
	}
}

