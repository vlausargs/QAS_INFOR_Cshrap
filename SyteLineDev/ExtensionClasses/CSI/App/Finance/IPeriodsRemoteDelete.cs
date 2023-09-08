//PROJECT NAME: Finance
//CLASS NAME: IPeriodsRemoteDelete.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IPeriodsRemoteDelete
	{
		(int? ReturnCode,
			string Infobar) PeriodsRemoteDeleteSp(
			int? FiscalYear,
			string Infobar,
			int? RepFromTrigger = 0,
			string RepFromSite = null);
	}
}

