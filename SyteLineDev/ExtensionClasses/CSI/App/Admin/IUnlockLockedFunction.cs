//PROJECT NAME: Admin
//CLASS NAME: IUnlockLockedFunction.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface IUnlockLockedFunction
	{
		(int? ReturnCode, string Infobar) UnlockLockedFunctionSp(string FunctionName,
		string Infobar);
	}
}

