//PROJECT NAME: Data
//CLASS NAME: ISetNextInvNum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ISetNextInvNum
	{
		(int? ReturnCode,
			string NewInvNum,
			string Infobar) SetNextInvNumSp(
			string Category,
			DateTime? InvDate,
			string TableName,
			string ColumnName,
			int? KeyLength,
			string Type,
			string NewInvNum,
			string Action,
			string Infobar);
	}
}

