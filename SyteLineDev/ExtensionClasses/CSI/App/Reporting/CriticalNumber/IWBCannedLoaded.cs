//PROJECT NAME: Reporting
//CLASS NAME: IWBCannedLoaded.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting.CriticalNumber
{
	public interface IWBCannedLoaded
	{
		(int? ReturnCode,
			string Return) WBCannedLoadedSp(
			string KeyReset,
			string vKey,
			string Return);
	}
}

