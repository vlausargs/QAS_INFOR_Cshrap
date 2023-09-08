//PROJECT NAME: Production
//CLASS NAME: IRSQC_GetUser3.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_GetUser3
	{
		(int? ReturnCode,
		string o_user,
		string Infobar) RSQC_GetUser3Sp(
			string o_user,
			string Infobar);
	}
}

