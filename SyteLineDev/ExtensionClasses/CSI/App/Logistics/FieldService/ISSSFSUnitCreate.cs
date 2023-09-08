//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSUnitCreate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSUnitCreate
	{
		int? SSSFSUnitCreateSp(
			string InSerNum,
			string InItem,
			DateTime? InCreateDate,
			int? InCompID = 0,
			int? BufferMode = 0);
	}
}

