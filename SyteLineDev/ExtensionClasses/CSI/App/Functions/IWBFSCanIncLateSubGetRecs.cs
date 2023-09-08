//PROJECT NAME: Data
//CLASS NAME: IWBFSCanIncLateSubGetRecs.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IWBFSCanIncLateSubGetRecs
	{
		int? WBFSCanIncLateSubGetRecsSp(
			int? KPINum,
			DateTime? AsOfDate,
			string Parm1 = null,
			string Parm2 = null,
			string Parm3 = null,
			string Parm4 = null,
			string Parm5 = null,
			string Parm6 = null,
			string Parm7 = null,
			string Parm8 = null,
			string Parm9 = null,
			string Parm10 = null,
			string Parm11 = null,
			string Parm12 = null);
	}
}

