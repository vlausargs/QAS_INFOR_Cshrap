//PROJECT NAME: Data
//CLASS NAME: IWBFSCanContRenPerSubGetRecs.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IWBFSCanContRenPerSubGetRecs
	{
		int? WBFSCanContRenPerSubGetRecsSp(
			int? KPINum,
			DateTime? AsOfDate,
			string Parm1 = null,
			string Parm2 = null,
			string Parm3 = null,
			string Parm4 = null,
			string Parm5 = null,
			string Parm6 = null,
			string Parm7 = null,
			string Parm8 = null);
	}
}

