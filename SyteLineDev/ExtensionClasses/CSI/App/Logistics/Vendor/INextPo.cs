//PROJECT NAME: Logistics
//CLASS NAME: INextPo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface INextPo
	{
		(int? ReturnCode, string Key,
		string Infobar) NextPoSp(string Context,
		string Prefix,
		int? KeyLength,
		string Key,
		string Infobar);
	}
}

