//PROJECT NAME: Logistics
//CLASS NAME: IPochgP1.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IPochgP1
	{
		(int? ReturnCode, int? PAbort,
		string Infobar,
		string PromptMsg,
		string PromptButtons) PochgP1Sp(string PPoNum,
		string PPoStat,
		int? PAbort,
		string Infobar,
		string PromptMsg,
		string PromptButtons);
	}
}

