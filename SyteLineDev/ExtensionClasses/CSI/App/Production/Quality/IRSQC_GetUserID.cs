//PROJECT NAME: Production
//CLASS NAME: IRSQC_GetUserID.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_GetUserID
	{
		(int? ReturnCode, string EmpNum,
		string Infobar) RSQC_GetUserIDSp(string EmpNum,
		string Infobar);
	}
}

