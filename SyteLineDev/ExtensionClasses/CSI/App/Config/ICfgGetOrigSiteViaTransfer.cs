//PROJECT NAME: Config
//CLASS NAME: ICfgGetOrigSiteViaTransfer.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Config
{
	public interface ICfgGetOrigSiteViaTransfer
	{
		(int? ReturnCode, string pOrigSite,
		string Infobar) CfgGetOrigSiteViaTransferSp(string pCep,
		string pCoNum,
		int? pCoLine,
		string pTrnNum,
		int? pTrnLine,
		string pOrigSite,
		string Infobar);
	}
}

