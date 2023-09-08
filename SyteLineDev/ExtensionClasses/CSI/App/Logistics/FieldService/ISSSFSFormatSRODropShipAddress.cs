//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSFormatSRODropShipAddress.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSFormatSRODropShipAddress
	{
		string SSSFSFormatSRODropShipAddressFn(
			string iDropType,
			string iDropNum,
			int? iDropSeq);
	}
}

