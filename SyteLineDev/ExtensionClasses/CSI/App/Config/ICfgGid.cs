//PROJECT NAME: Config
//CLASS NAME: ICfgGid.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Config
{
	public interface ICfgGid
	{
		string CfgGidFn(
			string RefType,
			string CoNum,
			int? CoLine);
	}
}

