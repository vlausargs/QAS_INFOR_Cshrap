//PROJECT NAME: DataCollection
//CLASS NAME: IDcCoValidateEmpNum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcCoValidateEmpNum
	{
		(int? ReturnCode, string EmpNum,
		string EmpName,
		string Infobar) DcCoValidateEmpNumSp(int? Connected,
		string EmpNum,
		string EmpName,
		string Infobar);
	}
}

