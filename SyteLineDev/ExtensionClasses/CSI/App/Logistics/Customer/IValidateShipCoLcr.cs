//PROJECT NAME: Logistics
//CLASS NAME: IValidateShipCoLcr.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IValidateShipCoLcr
	{
		(int? ReturnCode, string PromptMsg,
		string PromptButtons,
		string Infobar) ValidateShipCoLcrSp(string PShipCoCoNum,
		int? PErrorOnly,
		int? PLcrOkFlag,
		string PromptMsg,
		string PromptButtons,
		string Infobar,
		int? PBatchId);
	}
}

