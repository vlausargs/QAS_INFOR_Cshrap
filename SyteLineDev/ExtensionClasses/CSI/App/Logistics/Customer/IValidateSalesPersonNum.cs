//PROJECT NAME: Logistics
//CLASS NAME: IValidateSalesPersonNum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IValidateSalesPersonNum
	{
		(int? ReturnCode, string PromptMsg,
		string PromptButtons,
		string Infobar) ValidateSalesPersonNumSp(string Slsman,
		string PromptMsg,
		string PromptButtons,
		string Infobar);
	}
}

