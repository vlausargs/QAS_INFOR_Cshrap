//PROJECT NAME: Logistics
//CLASS NAME: IConvertPoReqPreProcess.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IConvertPoReqPreProcess
	{
		(int? ReturnCode, int? PPoChangeFlag,
		string PromptMsg,
		string PromptButtons,
		string PoChgPromptMsg,
		string PoChgPromptButtons,
		string VendReqPromptMsg,
		string VendReqPromptButtons,
		string Infobar) ConvertPoReqPreProcessSp(string PPoNum,
		string PReqNum,
		int? PPreqFromLine,
		int? PPreqToLine,
		string PPoType,
		int? PPoChangeFlag,
		string PromptMsg = null,
		string PromptButtons = null,
		string PoChgPromptMsg = null,
		string PoChgPromptButtons = null,
		string VendReqPromptMsg = null,
		string VendReqPromptButtons = null,
		string Infobar = null);
	}
}

