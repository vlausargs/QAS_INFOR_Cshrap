//PROJECT NAME: Data
//CLASS NAME: IInsertShipCoA.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IInsertShipCoA
	{
		int? InsertShipCoASp(
			string PShipCoCoNum,
			int? PBatchId);
	}
}

