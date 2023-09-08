//PROJECT NAME: Production
//CLASS NAME: IGntHlCritUpd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IGntHlCritUpd
	{
		(int? ReturnCode, string Infobar) GntHlCritUpdSp(Guid? Rowp,
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

