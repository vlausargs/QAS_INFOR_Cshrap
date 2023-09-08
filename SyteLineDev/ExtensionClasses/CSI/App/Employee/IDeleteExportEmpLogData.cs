//PROJECT NAME: Employee
//CLASS NAME: IDeleteExportEmpLogData.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
	public interface IDeleteExportEmpLogData
	{
		int? DeleteExportEmpLogDataSp(string StartingDept,
		string EndingDept,
		string StartingEmpNum,
		string EndingEmpNum);
	}
}

