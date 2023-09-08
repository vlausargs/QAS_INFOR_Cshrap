//PROJECT NAME: Logistics
//CLASS NAME: SSSFSAPISROPlanMatlTransAdd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSAPISROPlanMatlTransAdd : ISSSFSAPISROPlanMatlTransAdd
	{
		readonly IApplicationDB appDB;
		
		public SSSFSAPISROPlanMatlTransAdd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? TransNum,
			Guid? RowPtr,
			string InfoBar) SSSFSAPISROPlanMatlTransAddSp(
			string SroNum,
			int? SroLine,
			int? SroOper,
			DateTime? TransDate,
			string TransType,
			string Item,
			string Whse,
			string Lot,
			string Loc,
			string PartnerID,
			decimal? QtyConv,
			string UM,
			decimal? CostConv,
			decimal? PriceConv,
			string SerNum,
			string Notes,
			string Desc,
			int? PostFlag,
			string ReasonCode,
			int? TransNum,
			Guid? RowPtr,
			string InfoBar)
		{
			FSSRONumType _SroNum = SroNum;
			FSSROLineType _SroLine = SroLine;
			FSSROOperType _SroOper = SroOper;
			DateTimeType _TransDate = TransDate;
			FSSROMatlTransTypeType _TransType = TransType;
			ItemType _Item = Item;
			WhseType _Whse = Whse;
			LotType _Lot = Lot;
			LocType _Loc = Loc;
			FSPartnerType _PartnerID = PartnerID;
			QtyUnitType _QtyConv = QtyConv;
			UMType _UM = UM;
			CostPrcType _CostConv = CostConv;
			CostPrcType _PriceConv = PriceConv;
			SerNumType _SerNum = SerNum;
			InfobarType _Notes = Notes;
			DescriptionType _Desc = Desc;
			ListYesNoType _PostFlag = PostFlag;
			ReasonCodeType _ReasonCode = ReasonCode;
			FSSROTransNumType _TransNum = TransNum;
			RowPointerType _RowPtr = RowPtr;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSAPISROPlanMatlTransAddSp";
				
				appDB.AddCommandParameter(cmd, "SroNum", _SroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroLine", _SroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroOper", _SroOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransType", _TransType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PartnerID", _PartnerID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyConv", _QtyConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CostConv", _CostConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PriceConv", _PriceConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerNum", _SerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Notes", _Notes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Desc", _Desc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PostFlag", _PostFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReasonCode", _ReasonCode, ParameterDirection.Input);
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
