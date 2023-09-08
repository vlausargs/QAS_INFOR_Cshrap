//PROJECT NAME: Config
//CLASS NAME: ICfgCheckXref.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Config
{
	public interface ICfgCheckXref
	{
		(int? ReturnCode,
			string pFromSite,
			string pToSite,
			string Infobar) CfgCheckXrefSp(
			string pRefNum,
			int? pLineSuf,
			string pFromSite,
			string pToSite,
			string Infobar);
	}
}

