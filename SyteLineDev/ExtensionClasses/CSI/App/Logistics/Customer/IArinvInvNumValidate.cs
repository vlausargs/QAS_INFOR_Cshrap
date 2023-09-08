//PROJECT NAME: Logistics
//CLASS NAME: IArinvInvNumValidate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IArinvInvNumValidate
	{
		(int? ReturnCode, string PromptMsg,
		string Infobar,
		string CoNum,
		string PCurrCode,
		DateTime? PTaxDate) ArinvInvNumValidateSp(string CustNum,
		string ArinvType,
		string InvNum,
		DateTime? InvDate,
		string CalledFrom,
		string PromptMsg,
		string Infobar,
		int? IsApplyToInvNum = 0,
		string CoNum = null,
		string PCurrCode = null,
		DateTime? PTaxDate = null);
	}
}

