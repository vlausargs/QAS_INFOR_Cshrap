//PROJECT NAME: Production
//CLASS NAME: IPsStat.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IPsStat
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) PsStatSp(string PsFromStat,
		string PsToStat,
		string FromPsNum,
		string ToPsNum,
		string FromItem,
		string ToItem,
		DateTime? FromDate,
		DateTime? ToDate,
		int? PProcess,
		int? CopyPSItemBOM,
		int? CopyPSReleaseBOM,
		string Infobar,
		int? StartingDateOffset = null,
		int? EndingDateOffset = null);
	}
}

