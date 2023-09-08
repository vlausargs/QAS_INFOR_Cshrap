//PROJECT NAME: Logistics
//CLASS NAME: SSSFSRSMTransferReceiptCreate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSRSMTransferReceiptCreate : ISSSFSRSMTransferReceiptCreate
	{
		readonly IApplicationDB appDB;
		
		public SSSFSRSMTransferReceiptCreate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) SSSFSRSMTransferReceiptCreateSp(
			string iTrnNum,
			int? iTrnLine,
			string iLot,
			string iSerNum,
			string iToLoc,
			decimal? iQtyReceived,
			string Infobar)
		{
			TrnNumType _iTrnNum = iTrnNum;
			TrnLineType _iTrnLine = iTrnLine;
			LotType _iLot = iLot;
			SerNumType _iSerNum = iSerNum;
			LocType _iToLoc = iToLoc;
			QtyUnitType _iQtyReceived = iQtyReceived;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSRSMTransferReceiptCreateSp";
				
				appDB.AddCommandParameter(cmd, "iTrnNum", _iTrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iTrnLine", _iTrnLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iLot", _iLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSerNum", _iSerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iToLoc", _iToLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iQtyReceived", _iQtyReceived, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
