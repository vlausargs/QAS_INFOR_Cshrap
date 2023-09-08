//PROJECT NAME: Production
//CLASS NAME: IGetOperNumForCurrOper.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IGetOperNumForCurrOper
	{
		(int? ReturnCode, int? OperNum,
		string Infobar) GetOperNumForCurrOperSp(string Item,
		int? OperNum,
		string Infobar,
		string AlternateID = null);
	}
}

