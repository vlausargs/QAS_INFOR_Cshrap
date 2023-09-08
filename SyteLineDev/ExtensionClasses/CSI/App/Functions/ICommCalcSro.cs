//PROJECT NAME: Data
//CLASS NAME: ICommCalcSro.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICommCalcSro
	{
		(int? ReturnCode,
			string Infobar) CommCalcSroSp(
			string InvHdrInvNum,
			string TSroNum,
			string InvCred,
			string Infobar);
	}
}

