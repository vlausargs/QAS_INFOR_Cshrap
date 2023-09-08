//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSConfigAutoUpdate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSConfigAutoUpdate
	{
		(int? ReturnCode,
			string Infobar) SSSFSConfigAutoUpdateSp(
			Guid? RowPointer,
			string Infobar);
	}
}

