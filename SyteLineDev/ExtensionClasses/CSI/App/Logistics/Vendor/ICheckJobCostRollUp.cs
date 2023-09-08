//PROJECT NAME: Logistics
//CLASS NAME: ICheckJobCostRollUp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface ICheckJobCostRollUp
	{
		(int? ReturnCode, string PromptMsg,
		string Infobar) CheckJobCostRollUpSp(string Item,
		string RefNum,
		int? RefLineSuf,
		int? RefRelease,
		string PromptMsg,
		string Infobar);
	}
}

