//PROJECT NAME: Data
//CLASS NAME: IInsertShipCo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IInsertShipCo
	{
		int? InsertShipCoSp(
			string pCoType = null,
			int? pBatchID = null,
			string pCoStat = null,
			string pCoitemStat = null,
			string pStartCoNum = null,
			string pEndCoNum = null,
			string pStartCustNum = null,
			string pEndCustNum = null,
			string pStartItem = null,
			string pEndItem = null,
			int? IncludeShipEarly = null,
			DateTime? CutoffDate = null);
	}
}

