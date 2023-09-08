//PROJECT NAME: Data
//CLASS NAME: IPochgP2.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPochgP2
	{
		(int? ReturnCode,
			int? PPoChange,
			string Infobar,
			string PromptMsg,
			string PromptButtons) PochgP2Sp(
			string PPoNum,
			string PPoStat,
			int? PPoChange,
			string Infobar,
			string PromptMsg,
			string PromptButtons);
	}
}

