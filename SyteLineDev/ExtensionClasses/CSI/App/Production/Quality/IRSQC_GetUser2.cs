//PROJECT NAME: Production
//CLASS NAME: IRSQC_GetUser2.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_GetUser2
	{
		(int? ReturnCode, string o_emp_num,
		string o_name,
		string Infobar) RSQC_GetUser2Sp(string o_emp_num,
		string o_name,
		string Infobar);
	}
}

