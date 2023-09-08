//PROJECT NAME: Config
//CLASS NAME: ICfgClearXref.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Config
{
	public interface ICfgClearXref
	{
		(int? ReturnCode,
			int? pAbort,
			string Infobar) CfgClearXrefSp(
			string pFromSite,
			string pRefNum,
			int? pRefLine,
			string pCoNum,
			int? pCoLine,
			int? pCoRelease,
			int? pAbort,
			string Infobar);
	}
}

