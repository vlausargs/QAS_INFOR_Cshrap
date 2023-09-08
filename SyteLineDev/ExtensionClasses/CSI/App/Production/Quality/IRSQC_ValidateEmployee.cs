//PROJECT NAME: Production
//CLASS NAME: IRSQC_ValidateEmploy.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_ValidateEmploy
	{
		(int? ReturnCode, string Name,
		string Infobar) RSQC_ValidateEmployee(int? ValidateOk,
		string EmployeeNum,
		string Name,
		string Infobar);
	}
}

