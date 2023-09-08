//PROJECT NAME: Logistics
//CLASS NAME: SSSFSRSMMobileTransferCreate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSRSMMobileTransferCreate : ISSSFSRSMMobileTransferCreate
	{
		readonly IApplicationDB appDB;
		
		public SSSFSRSMMobileTransferCreate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string oTrnNum,
			int? oTrnLine,
			string Infobar) SSSFSRSMMobileTransferCreateSp(
			DateTime? iTransDate,
			string iItem,
			string iDescription,
			decimal? iQty,
			string iLot,
			string iSerNum,
			string iFromWhse,
			string iFromLoc,
			string iToWhse,
			string iToLoc,
			string oTrnNum,
			int? oTrnLine,
			string Infobar)
		{
			DateTimeType _iTransDate = iTransDate;
			ItemType _iItem = iItem;
			DescriptionType _iDescription = iDescription;
			QtyUnitType _iQty = iQty;
			LotType _iLot = iLot;
			SerNumType _iSerNum = iSerNum;
			WhseType _iFromWhse = iFromWhse;
			LocType _iFromLoc = iFromLoc;
			WhseType _iToWhse = iToWhse;
			LocType _iToLoc = iToLoc;
			TrnNumType _oTrnNum = oTrnNum;
			TrnLineType _oTrnLine = oTrnLine;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSRSMMobileTransferCreateSp";
				
				appDB.AddCommandParameter(cmd, "iTransDate", _iTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iItem", _iItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iDescription", _iDescription, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iQty", _iQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iLot", _iLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSerNum", _iSerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iFromWhse", _iFromWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iFromLoc", _iFromLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iToWhse", _iToWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iToLoc", _iToLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "oTrnNum", _oTrnNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oTrnLine", _oTrnLine, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				oTrnNum = _oTrnNum;
				oTrnLine = _oTrnLine;
				Infobar = _Infobar;
				
				return (Severity, oTrnNum, oTrnLine, Infobar);
			}
		}
	}
}
