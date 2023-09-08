//PROJECT NAME: Production
//CLASS NAME: IRSQC_Parmgn.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_Parmgn
	{
		(int? ReturnCode, int? o_check_gage,
		int? o_check_method,
		string Infobar) RSQC_ParmgnSp(int? o_check_gage,
		int? o_check_method,
		string Infobar);
	}
}

