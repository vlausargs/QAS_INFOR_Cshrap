//PROJECT NAME: Production
//CLASS NAME: IWcMachineTimeTransPre.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IWcMachineTimeTransPre
	{
		(int? ReturnCode, string PWorkCenter,
		int? TRptInHrs,
		string PromptMsg,
		string PromptButtons,
		string Infobar) WcMachineTimeTransPreSp(string PWorkCenter,
		int? TRptInHrs,
		string PromptMsg,
		string PromptButtons,
		string Infobar);
	}
}

