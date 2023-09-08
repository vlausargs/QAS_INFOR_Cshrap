//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSroAlloc.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSSroAlloc
	{
		(int? ReturnCode,
			string Infobar) SSSFSSroAllocSp(
			string iOldSroNum,
			int? iOldSroLine,
			int? iOldSroOper,
			string iOldWhse,
			string iOldItem,
			decimal? iOldMatlQty,
			string iOldSroStat,
			string iOldOpStat,
			string iSroNum,
			int? iSroLine,
			int? iSroOper,
			string iWhse,
			string iItem,
			decimal? iMatlQty,
			string iSroStat,
			string iOpStat,
			int? iNotUsed,
			string Infobar);
	}
}

