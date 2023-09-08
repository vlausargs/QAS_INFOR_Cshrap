//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSRpt_SROPicklistUpdTemp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSRpt_SROPicklistUpdTemp
	{
		(int? ReturnCode,
			decimal? ioQtyNeeded,
			int? oUsedLoc) SSSFSRpt_SROPicklistUpdTempSp(
			int? iZeroAvailLoc,
			string iWhse,
			string iItem,
			string iLoc,
			string iLot,
			decimal? iQtyOnHand,
			decimal? ConvFactor,
			string iSroNum,
			int? iSroLine,
			int? iSroOper,
			int? iShowAllLoc,
			decimal? ioQtyNeeded,
			int? oUsedLoc,
			int? iTransNum = null);
	}
}

