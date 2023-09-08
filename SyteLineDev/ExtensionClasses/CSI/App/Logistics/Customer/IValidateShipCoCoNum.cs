//PROJECT NAME: Logistics
//CLASS NAME: IValidateShipCoCoNum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IValidateShipCoCoNum
	{
			(int? ReturnCode, string PromptMsg,
			string PromptButtons,
			string Infobar) 
		ValidateShipCoCoNumSp(string PCoNum,
			DateTime? PGenDate,
			string PromptMsg,
			string PromptButtons,
			string Infobar);
	}
}

