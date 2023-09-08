//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSUnitWarrDel.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSUnitWarrDel
	{
		int? SSSFSUnitWarrDelSp(
			int? CompId,
			string WarrCode);
	}
}

