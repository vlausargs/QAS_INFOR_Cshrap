//PROJECT NAME: Production
//CLASS NAME: IRSQC_ValidateIt.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_ValidateIt
	{
		(int? ReturnCode, string Description,
		string Infobar) RSQC_ValidateItem(string SiteRef,
		int? ValidateOk,
		string ItemNum,
		string Description,
		string Infobar);
	}
}

