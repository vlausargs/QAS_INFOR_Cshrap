//PROJECT NAME: Data
//CLASS NAME: IDropTempInvTable.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IDropTempInvTable
	{
		(int? ReturnCode,
			string Infobar) DropTempInvTableSp(
			string Infobar);
	}
}

