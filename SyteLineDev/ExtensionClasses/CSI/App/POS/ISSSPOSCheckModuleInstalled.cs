//PROJECT NAME: POS
//CLASS NAME: ISSSPOSCheckModuleInstalled.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.POS
{
	public interface ISSSPOSCheckModuleInstalled
	{
		(int? ReturnCode,
		int? InstalledYN) SSSPOSCheckModuleInstalledSp(
			string ModuleInstalled,
			int? InstalledYN);
	}
}

