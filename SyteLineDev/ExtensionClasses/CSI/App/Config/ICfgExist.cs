//PROJECT NAME: Config
//CLASS NAME: ICfgExist.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Config
{
	public interface ICfgExist
	{
		int? CfgExistFn(
			string pSite,
			string pCoNum,
			int? pCoLine,
			int? pCoRelease);
	}
}

