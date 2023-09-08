//PROJECT NAME: Config
//CLASS NAME: ISetAvailCfg.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Config
{
	public interface ISetAvailCfg
	{
		(int? ReturnCode, int? AvailCfg) SetAvailCfgSp(int? AvailCfg,
		string PSite = null);
	}
}

