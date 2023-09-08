//PROJECT NAME: Logistics
//CLASS NAME: INextTrn.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface INextTrn
	{
		(int? ReturnCode, string Key,
		string Infobar) NextTrnSp(string Context,
		string Prefix,
		int? KeyLength,
		string Key,
		string Infobar);
	}
}

