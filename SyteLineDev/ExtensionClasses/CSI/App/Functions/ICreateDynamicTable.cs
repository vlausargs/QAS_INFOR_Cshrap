//PROJECT NAME: Data
//CLASS NAME: ICreateDynamicTable.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICreateDynamicTable
	{
		(int? ReturnCode,
			string Infobar) CreateDynamicTableSp(
			string pTable,
			string Infobar,
			string pParm1 = null,
			string pParm2 = null,
			string pColumns = null,
			int? CopyIndexes = 1);
	}
}

