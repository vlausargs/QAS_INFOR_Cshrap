//PROJECT NAME: Data
//CLASS NAME: INextShipto.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface INextShipto
	{
		(int? ReturnCode,
			string Key,
			string Infobar) NextShiptoSp(
			string Context,
			string Prefix,
			int? KeyLength,
			string Key,
			string Infobar);
	}
}

