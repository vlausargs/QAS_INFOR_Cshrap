//PROJECT NAME: Employee
//CLASS NAME: IExtPrIfErrorSave.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
	public interface IExtPrIfErrorSave
	{
		(int? ReturnCode,
		string Infobar) ExtPrIfErrorSaveSp(
			DateTime? ErrDate,
			string ErrMsg,
			string Infobar);
	}
}

