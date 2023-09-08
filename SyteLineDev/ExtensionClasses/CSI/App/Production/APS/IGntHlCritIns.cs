//PROJECT NAME: Production
//CLASS NAME: IGntHlCritIns.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IGntHlCritIns
	{
		(int? ReturnCode, string Infobar) GntHlCritInsSp(string Highlightid,
		string Username,
		int? Seqnum,
		int? Type,
		int? Comparison,
		string Param,
		int? Color,
		int? CmpSubstr,
		int? CmpStart,
		int? CmpLength,
		string Infobar);
	}
}

