//PROJECT NAME: Data
//CLASS NAME: ICommCalcCon.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICommCalcCon
	{
		(int? ReturnCode,
			string Infobar) CommCalcConSp(
			string InvHdrInvNum,
			string TContract,
			string InvCred,
			string Infobar);
	}
}

