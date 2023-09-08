//PROJECT NAME: Logistics
//CLASS NAME: SSSFSRpt_SROPicklistUpdTemp.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSRpt_SROPicklistUpdTemp : ISSSFSRpt_SROPicklistUpdTemp
	{
		readonly IApplicationDB appDB;
		
		public SSSFSRpt_SROPicklistUpdTemp(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
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
			int? iTransNum = null)
		{
			ListYesNoType _iZeroAvailLoc = iZeroAvailLoc;
			WhseType _iWhse = iWhse;
			ItemType _iItem = iItem;
			LocType _iLoc = iLoc;
			LotType _iLot = iLot;
			QtyUnitType _iQtyOnHand = iQtyOnHand;
			CostPrcType _ConvFactor = ConvFactor;
			FSSRONumType _iSroNum = iSroNum;
			FSSROLineType _iSroLine = iSroLine;
			FSSROOperType _iSroOper = iSroOper;
			ListYesNoType _iShowAllLoc = iShowAllLoc;
			QtyUnitType _ioQtyNeeded = ioQtyNeeded;
			ListYesNoType _oUsedLoc = oUsedLoc;
			FSSROTransNumType _iTransNum = iTransNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSRpt_SROPicklistUpdTempSp";
				
				appDB.AddCommandParameter(cmd, "iZeroAvailLoc", _iZeroAvailLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iWhse", _iWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iItem", _iItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iLoc", _iLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iLot", _iLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iQtyOnHand", _iQtyOnHand, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ConvFactor", _ConvFactor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSroNum", _iSroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSroLine", _iSroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSroOper", _iSroOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iShowAllLoc", _iShowAllLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ioQtyNeeded", _ioQtyNeeded, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oUsedLoc", _oUsedLoc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "iTransNum", _iTransNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ioQtyNeeded = _ioQtyNeeded;
				oUsedLoc = _oUsedLoc;
				
				return (Severity, ioQtyNeeded, oUsedLoc);
			}
		}
	}
}
