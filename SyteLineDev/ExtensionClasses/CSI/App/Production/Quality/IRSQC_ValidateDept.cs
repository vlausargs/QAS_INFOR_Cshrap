//PROJECT NAME: Production
//CLASS NAME: IRSQC_ValidateDept.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_ValidateDept
	{
		(int? ReturnCode, string Description,
		string Infobar) RSQC_ValidateDeptSp(int? ValidateDept,
		string Dept,
		string Description,
		string Infobar);
	}
}

