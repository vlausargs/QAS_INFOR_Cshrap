//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSUnitConfigWarrLoad.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSUnitConfigWarrLoad
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSFSUnitConfigWarrLoadSp(int? CompId,
		DateTime? Date,
		int? MeterAmt,
		string FilterString = null);
	}
}

