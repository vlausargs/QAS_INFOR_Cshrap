//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSROPackSlipLine_Load.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSSROPackSlipLine_Load
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSFSSROPackSlipLine_LoadSp(int? PackNum = null,
		string SRONum = null,
		int? SROLine = null,
		int? SROOper = null,
		int? TransPosted = 0,
		string InWhse = null,
		int? AllShipTos = 1,
		string ShipToType = "N",
		string ShipToNum = null,
		int? ShipToSeq = null,
		int? AddMode = 0,
		string FilterString = null);
	}
}

