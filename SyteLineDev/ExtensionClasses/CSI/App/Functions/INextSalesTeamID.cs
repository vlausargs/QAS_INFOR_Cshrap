//PROJECT NAME: Data
//CLASS NAME: INextSalesTeamID.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface INextSalesTeamID
	{
		(int? ReturnCode,
			string Key,
			string Infobar) NextSalesTeamIDSp(
			string Context,
			string Prefix,
			int? KeyLength,
			string Key,
			string Infobar);
	}
}

