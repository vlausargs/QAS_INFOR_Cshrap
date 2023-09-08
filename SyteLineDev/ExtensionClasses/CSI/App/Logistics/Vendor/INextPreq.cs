//PROJECT NAME: Logistics
//CLASS NAME: INextPreq.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface INextPreq
	{
		(int? ReturnCode, string Key,
		string Infobar) NextPreqSp(string Context,
		string Prefix,
		int? KeyLength,
		string Key,
		string Infobar);
	}
}

