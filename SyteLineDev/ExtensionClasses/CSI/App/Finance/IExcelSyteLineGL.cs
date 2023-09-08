//PROJECT NAME: Finance
//CLASS NAME: IExcelSyteLineGL.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IExcelSyteLineGL
	{
		(int? ReturnCode, string Queryname) ExcelSyteLineGLSp(string Queryname,
		string QueryStr,
		string QAccountCode = null,
		string QPeriod = null,
		string QYear = null,
		string UnitCode = null,
		string BalType = null);
	}
}

