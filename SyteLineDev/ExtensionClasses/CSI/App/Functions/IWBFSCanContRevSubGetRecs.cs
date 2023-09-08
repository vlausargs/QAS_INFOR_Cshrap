//PROJECT NAME: Data
//CLASS NAME: IWBFSCanContRevSubGetRecs.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IWBFSCanContRevSubGetRecs
	{
		int? WBFSCanContRevSubGetRecsSp(
			int? KPINum,
			DateTime? AsOfDate,
			string Parm1 = null,
			string Parm2 = null,
			int? CheckStatus = 0);
	}
}

