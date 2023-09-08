//PROJECT NAME: DataCollection
//CLASS NAME: IDcMiscValidateEmpNum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcMiscValidateEmpNum
	{
		(int? ReturnCode, string EmpName,
		string Infobar) DcMiscValidateEmpNumSp(int? Connected,
		string EmpNum,
		string EmpName,
		string Infobar);
	}
}

