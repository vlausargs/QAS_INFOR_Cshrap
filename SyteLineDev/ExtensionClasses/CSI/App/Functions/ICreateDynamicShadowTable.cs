//PROJECT NAME: Data
//CLASS NAME: ICreateDynamicShadowTable.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICreateDynamicShadowTable
	{
		(int? ReturnCode,
			string Infobar) CreateDynamicShadowTableSp(
			string pTable,
			string Infobar);
	}
}

