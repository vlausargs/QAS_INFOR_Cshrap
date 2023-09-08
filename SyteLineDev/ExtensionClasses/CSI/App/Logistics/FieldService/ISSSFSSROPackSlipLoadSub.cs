//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSROPackSlipLoadSub.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSSROPackSlipLoadSub
	{
		(ICollectionLoadResponse Data, int? ReturnCode,
			string Infobar) SSSFSSROPackSlipLoadSubSp(
			int? PackNum,
			string InWhse,
			string SRONum,
			int? SROLine,
			int? SROOper,
			int? TransPosted,
			int? AllShipTos,
			string ShipToType,
			string ShipToNum,
			int? ShipToSeq,
			int? AddMode = 0,
			string Infobar = null);
	}
}

