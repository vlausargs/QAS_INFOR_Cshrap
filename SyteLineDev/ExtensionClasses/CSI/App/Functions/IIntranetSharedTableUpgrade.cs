//PROJECT NAME: Data
//CLASS NAME: IIntranetSharedTableUpgrade.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IIntranetSharedTableUpgrade
	{
		(int? ReturnCode,
			string Infobar) IntranetSharedTableUpgradeSp(
			string Mode = "CREATE",
			string Infobar = null);
	}
}

