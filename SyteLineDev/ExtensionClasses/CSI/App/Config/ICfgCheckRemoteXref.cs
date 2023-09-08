//PROJECT NAME: Config
//CLASS NAME: ICfgCheckRemoteXref.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Config
{
	public interface ICfgCheckRemoteXref
	{
		(ICollectionLoadResponse Data, int? ReturnCode,
			int? pReturnVal,
			string Infobar) CfgCheckRemoteXrefSp(
			string pRefNum,
			int? pLineSuf,
			int? pReturnVal,
			string Infobar);
	}
}

