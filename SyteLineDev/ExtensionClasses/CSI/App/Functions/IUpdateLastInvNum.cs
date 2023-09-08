//PROJECT NAME: Data
//CLASS NAME: IUpdateLastInvNum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IUpdateLastInvNum
	{
		int? UpdateLastInvNumSp(
			string TableName,
			string ColumnName,
			string InvNum,
			string Type);
	}
}

