//PROJECT NAME: Logistics
//CLASS NAME: IValidateAptrxGenAPTrans.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IValidateAptrxGenAPTrans
	{
		(int? ReturnCode, string PromptMsg,
		string PromptButtons,
		string Infobar) ValidateAptrxGenAPTransSp(decimal? PMatlCost,
		string PVendCurrCode,
		string PVchAdj,
		string PromptMsg,
		string PromptButtons,
		string Infobar);
	}
}

