//PROJECT NAME: Logistics
//CLASS NAME: SSSFSRSMTransferRequestCreate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSRSMTransferRequestCreate : ISSSFSRSMTransferRequestCreate
	{
		readonly IApplicationDB appDB;
		
		public SSSFSRSMTransferRequestCreate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string oTrnNum,
			int? oTrnLine,
			string Infobar) SSSFSRSMTransferRequestCreateSp(
			string iItem,
			string iDescription,
			decimal? iQty,
			string iUM,
			string iFromWhse,
			string iToWhse,
			DateTime? iDueDate,
			string oTrnNum,
			int? oTrnLine,
			string Infobar)
		{
			ItemType _iItem = iItem;
			DescriptionType _iDescription = iDescription;
			QtyUnitType _iQty = iQty;
			UMType _iUM = iUM;
			WhseType _iFromWhse = iFromWhse;
			WhseType _iToWhse = iToWhse;
			DateType _iDueDate = iDueDate;
			TrnNumType _oTrnNum = oTrnNum;
			TrnLineType _oTrnLine = oTrnLine;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSRSMTransferRequestCreateSp";
				
				appDB.AddCommandParameter(cmd, "iItem", _iItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iDescription", _iDescription, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iQty", _iQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iUM", _iUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iFromWhse", _iFromWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iToWhse", _iToWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iDueDate", _iDueDate, ParameterDirection.Input);
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
