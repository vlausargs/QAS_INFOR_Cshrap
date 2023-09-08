//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSroAllocSroStatChanged.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSSroAllocSroStatChanged
	{
		(int? ReturnCode,
			string Infobar) SSSFSSroAllocSroStatChangedSp(
			string iSroNum,
			string iOldSroStat,
			string iSroStat,
			string Infobar);
	}
}

