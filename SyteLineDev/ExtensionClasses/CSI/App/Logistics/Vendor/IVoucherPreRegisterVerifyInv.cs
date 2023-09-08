//PROJECT NAME: Logistics
//CLASS NAME: IVoucherPreRegisterVerifyInv.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IVoucherPreRegisterVerifyInv
	{
		(int? ReturnCode, string PromptMsg,
		string PromptButtons) VoucherPreRegisterVerifyInvSp(string PVendNum,
		string PInvNum,
		string PromptMsg,
		string PromptButtons);
	}
}

