//PROJECT NAME: DataCollection
//CLASS NAME: IDcPoValidateEmpNum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcPoValidateEmpNum
	{
		(int? ReturnCode, string EmpNum,
		string EmpName,
		string Infobar) DcPoValidateEmpNumSp(int? Connected,
		string EmpNum,
		string EmpName,
		string Infobar);
	}
}

