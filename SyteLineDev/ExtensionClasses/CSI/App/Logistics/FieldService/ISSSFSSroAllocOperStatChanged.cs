//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSroAllocOperStatChanged.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSSroAllocOperStatChanged
	{
		(int? ReturnCode,
			string Infobar) SSSFSSroAllocOperStatChangedSp(
			string iSroNum,
			int? iSroLine,
			int? iSroOper,
			string iOldOpStat,
			string iOpStat,
			string Infobar);
	}
}

