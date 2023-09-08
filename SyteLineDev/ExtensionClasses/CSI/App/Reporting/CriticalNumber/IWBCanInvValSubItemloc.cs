//PROJECT NAME: Reporting
//CLASS NAME: IWBCanInvValSubItemloc.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting.CriticalNumber
{
	public interface IWBCanInvValSubItemloc
	{
		(int? ReturnCode,
			decimal? Amount) WBCanInvValSubItemlocSp(
			Guid? ItemlocRowPointer,
			decimal? Amount);
	}
}

