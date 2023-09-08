//PROJECT NAME: Logistics
//CLASS NAME: SSSFSAPISROPlanLaborTransAdd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSAPISROPlanLaborTransAdd : ISSSFSAPISROPlanLaborTransAdd
	{
		readonly IApplicationDB appDB;
		
		public SSSFSAPISROPlanLaborTransAdd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? TransNum,
			Guid? RowPtr,
			string Infobar) SSSFSAPISROPlanLaborTransAddSp(
			string SroNum,
			int? SroLine,
			int? SroOper,
			DateTime? TransDate,
			string PartnerID,
			DateTime? StartDate,
			DateTime? EndDate,
			string WorkCode,
			decimal? HoursWorked,
			decimal? HoursToBill,
			decimal? LbrCost,
			decimal? LbrPrice,
			string Notes,
			int? PostFlag,
			int? TransNum,
			Guid? RowPtr,
			string Infobar)
		{
			FSSRONumType _SroNum = SroNum;
			FSSROLineType _SroLine = SroLine;
			FSSROOperType _SroOper = SroOper;
			DateTimeType _TransDate = TransDate;
			FSPartnerType _PartnerID = PartnerID;
			DateTimeType _StartDate = StartDate;
			DateTimeType _EndDate = EndDate;
			FSWorkCodeType _WorkCode = WorkCode;
			HourlyRateType _HoursWorked = HoursWorked;
			HourlyRateType _HoursToBill = HoursToBill;
			CostPrcType _LbrCost = LbrCost;
			CostPrcType _LbrPrice = LbrPrice;
			InfobarType _Notes = Notes;
			ListYesNoType _PostFlag = PostFlag;
			FSSROTransNumType _TransNum = TransNum;
			RowPointerType _RowPtr = RowPtr;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSAPISROPlanLaborTransAddSp";
				
				appDB.AddCommandParameter(cmd, "SroNum", _SroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroLine", _SroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroOper", _SroOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PartnerID", _PartnerID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDate", _StartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDate", _EndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WorkCode", _WorkCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "HoursWorked", _HoursWorked, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "HoursToBill", _HoursToBill, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LbrCost", _LbrCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LbrPrice", _LbrPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Notes", _Notes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PostFlag", _PostFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransNum", _TransNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RowPtr", _RowPtr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TransNum = _TransNum;
				RowPtr = _RowPtr;
				Infobar = _Infobar;
				
				return (Severity, TransNum, RowPtr, Infobar);
			}
		}
	}
}
