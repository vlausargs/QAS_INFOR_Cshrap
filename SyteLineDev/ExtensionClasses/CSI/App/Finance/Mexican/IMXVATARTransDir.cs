//PROJECT NAME: Finance
//CLASS NAME: IMXVATARTransDir.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.Mexican
{
	public interface IMXVATARTransDir
	{
		(int? ReturnCode,
			string Infobar) MXVATARTransDirSp(
			int? PCheckNum = null,
			string PCustNum = null,
			string Infobar = null);
	}
}

