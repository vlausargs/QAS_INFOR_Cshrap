//PROJECT NAME: Config
//CLASS NAME: ICfgClearRemoteXref.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Config
{
	public interface ICfgClearRemoteXref
	{
		int? CfgClearRemoteXrefSp(
			string pRefNum,
			int? pRefLine,
			string pCoNum,
			int? pCoLine,
			int? pCoRelease);
	}
}

