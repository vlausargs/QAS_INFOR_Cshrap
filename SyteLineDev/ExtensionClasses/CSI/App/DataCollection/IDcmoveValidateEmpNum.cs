//PROJECT NAME: DataCollection
//CLASS NAME: IDcmoveValidateEmpNum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcmoveValidateEmpNum
	{
		(int? ReturnCode, string EmpNum,
		string EmpName,
		string Infobar) DcmoveValidateEmpNumSp(int? Connected,
		string EmpNum,
		string EmpName,
		string Infobar);
	}
}

