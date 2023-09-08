//PROJECT NAME: DataCollection
//CLASS NAME: IDcJmcValidateEmpNum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcJmcValidateEmpNum
	{
		(int? ReturnCode, string EmpNum,
		string EmpName,
		string Infobar) DcJmcValidateEmpNumSp(int? Connected,
		string EmpNum,
		string EmpName,
		string Infobar);
	}
}

