//PROJECT NAME: Logistics
//CLASS NAME: SSSFSAPISROPlanMiscTransAdd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSAPISROPlanMiscTransAdd : ISSSFSAPISROPlanMiscTransAdd
	{
		readonly IApplicationDB appDB;
		
		public SSSFSAPISROPlanMiscTransAdd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? TransNum,
			Guid? RowPtr,
			string InfoBar) SSSFSAPISROPlanMiscTransAddSp(
			string SroNum,
			int? SroLine,
			int? SroOper,
			DateTime? TransDate,
			string PartnerID,
			string Dept,
			string Whse,
			decimal? CostConv,
			decimal? PriceConv,
			string MiscCode,
			string PayType,
			decimal? QtyConv,
			string Notes,
			int? TransNum,
			Guid? RowPtr,
			string InfoBar)
		{
			FSSRONumType _SroNum = SroNum;
			FSSROLineType _SroLine = SroLine;
			FSSROOperType _SroOper = SroOper;
			DateTimeType _TransDate = TransDate;
			FSPartnerType _PartnerID = PartnerID;
			DeptType _Dept = Dept;
			WhseType _Whse = Whse;
			CostPrcType _CostConv = CostConv;
			CostPrcType _PriceConv = PriceConv;
			FSMiscCodeType _MiscCode = MiscCode;
			FSPayTypeType _PayType = PayType;
			QtyUnitType _QtyConv = QtyConv;
			InfobarType _Notes = Notes;
			FSSROTransNumType _TransNum = TransNum;
			RowPointerType _RowPtr = RowPtr;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSAPISROPlanMiscTransAddSp";
				
				appDB.AddCommandParameter(cmd, "SroNum", _SroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroLine", _SroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroOper", _SroOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PartnerID", _PartnerID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Dept", _Dept, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CostConv", _CostConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PriceConv", _PriceConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MiscCode", _MiscCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PayType", _PayType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyConv", _QtyConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Notes", _Notes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransNum", _TransNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RowPtr", _RowPtr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TransNum = _TransNum;
				RowPtr = _RowPtr;
				InfoBar = _InfoBar;
				
				return (Severity, TransNum, RowPtr, InfoBar);
			}
		}
	}
}
