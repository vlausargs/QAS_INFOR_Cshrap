//PROJECT NAME: Material
//CLASS NAME: IUpdateItemLocAcct.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IUpdateItemLocAcct
	{
		(int? ReturnCode, string Infobar) UpdateItemLocAcctSp(string PItem,
		string PItemProductCode,
		string Infobar);
	}
}

