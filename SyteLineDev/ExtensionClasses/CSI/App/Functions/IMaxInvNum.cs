//PROJECT NAME: Data
//CLASS NAME: IMaxInvNum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IMaxInvNum
	{
		string MaxInvNumFn(
			string InvNum1,
			string InvNum2);
	}
}

