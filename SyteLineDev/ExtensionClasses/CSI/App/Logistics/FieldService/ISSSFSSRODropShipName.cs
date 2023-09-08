//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSRODropShipName.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSSRODropShipName
	{
		string SSSFSSRODropShipNameFn(
			string iDropType,
			string iDropNum,
			int? iDropSeq);
	}
}

