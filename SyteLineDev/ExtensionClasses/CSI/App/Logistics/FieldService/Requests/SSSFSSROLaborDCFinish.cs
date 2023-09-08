//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROLaborDCFinish.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSSROLaborDCFinish : ISSSFSSROLaborDCFinish
	{
		readonly IApplicationDB appDB;
		
		
		public SSSFSSROLaborDCFinish(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) SSSFSSROLaborDCFinishSp(string PartnerId,
		string SroNum,
		int? SroLine,
		int? SroOper,
		string WorkCode,
		decimal? HrsWorked,
		decimal? HrsToBill,
		DateTime? EndDate,
		string NoteContent,
		string Infobar = null,
		string BillCode = null,
		decimal? UnitCost = null,
		decimal? UnitRate = null,
		int? LogTran = 0,
		Guid? DcRowPointer = null)
		{
			FSPartnerType _PartnerId = PartnerId;
			FSSRONumType _SroNum = SroNum;
			FSSROLineType _SroLine = SroLine;
			FSSROOperType _SroOper = SroOper;
			FSWorkCodeType _WorkCode = WorkCode;
			QtyUnitType _HrsWorked = HrsWorked;
			QtyUnitType _HrsToBill = HrsToBill;
			DateType _EndDate = EndDate;
			StringType _NoteContent = NoteContent;
			Infobar _Infobar = Infobar;
			FSSROBillCodeType _BillCode = BillCode;
			CostPrcType _UnitCost = UnitCost;
			CostPrcType _UnitRate = UnitRate;
			IntType _LogTran = LogTran;
			RowPointerType _DcRowPointer = DcRowPointer;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSROLaborDCFinishSp";
				
				appDB.AddCommandParameter(cmd, "PartnerId", _PartnerId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroNum", _SroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroLine", _SroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroOper", _SroOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WorkCode", _WorkCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "HrsWorked", _HrsWorked, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "HrsToBill", _HrsToBill, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDate", _EndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NoteContent", _NoteContent, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BillCode", _BillCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitCost", _UnitCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitRate", _UnitRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LogTran", _LogTran, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DcRowPointer", _DcRowPointer, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
