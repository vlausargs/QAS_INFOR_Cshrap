//PROJECT NAME: Data
//CLASS NAME: INextInvNum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface INextInvNum
	{
		(int? ReturnCode,
			string InvNum,
			string Infobar) NextInvNumSp(
			string Custnum,
			DateTime? InvDate = null,
			string Type = null,
			string InvNum = null,
			string Action = null,
			string Infobar = null,
			string Category = null);
	}
}

