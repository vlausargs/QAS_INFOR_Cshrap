//PROJECT NAME: Config
//CLASS NAME: ICfgMakeDesc.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Config
{
	public interface ICfgMakeDesc
	{
		(int? ReturnCode,
			string pDesc) CfgMakeDescSp(
			string pConfigType,
			string pCoNum,
			int? pCoLine,
			int? pCoRelease,
			string pJob,
			int? pSuffix,
			string pDesc);
	}
}

