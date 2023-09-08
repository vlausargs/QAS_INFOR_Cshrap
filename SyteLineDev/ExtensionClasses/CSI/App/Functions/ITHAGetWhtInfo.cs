//PROJECT NAME: Data
//CLASS NAME: ITHAGetWhtInfo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ITHAGetWhtInfo
	{
		(int? ReturnCode,
			string Whttaxtype,
			string TaxRegNum,
			string CompName,
			string Prop1,
			string Prop2,
			string Prop3) THAGetWhtInfoSp(
			string VendNum = null,
			int? Voucher = null,
			string Whttaxtype = null,
			string TaxRegNum = null,
			string CompName = null,
			string Prop1 = null,
			string Prop2 = null,
			string Prop3 = null,
			string BankCode = null);
	}
}

