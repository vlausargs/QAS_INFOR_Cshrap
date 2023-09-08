//PROJECT NAME: Data
//CLASS NAME: IIsExternalAddonAvailable.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IIsExternalAddonAvailable
	{
		int? IsExternalAddonAvailableFn(
			string ModuleName);
	}
}

