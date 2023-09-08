//PROJECT NAME: Logistics
//CLASS NAME: MaterialDistributionCustUpd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class MaterialDistributionCustUpd : IMaterialDistributionCustUpd
	{
		readonly IApplicationDB appDB;
		
		
		public MaterialDistributionCustUpd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? MaterialDistributionCustUpdSp(Guid? ConnectionId,
		string VchType,
		string PoNum,
		int? PoLine,
		int? PoRelease,
		string GrnNum,
		int? GrnLine,
		string Item,
		string ItemDescription,
		string TransNat,
		string TransNat2,
		string UM,
		string TermsCode,
		decimal? QtuQtyReceived,
		decimal? QtuQtyVoucher,
		decimal? CprItemCost,
		decimal? CprItemCostConv,
		decimal? CprPlanCostConv,
		DateTime? PoRecordDate)
		{
			RowPointerType _ConnectionId = ConnectionId;
			TTVoucherType _VchType = VchType;
			PoNumType _PoNum = PoNum;
			PoLineType _PoLine = PoLine;
			PoReleaseType _PoRelease = PoRelease;
			GrnNumType _GrnNum = GrnNum;
			GrnLineType _GrnLine = GrnLine;
			ItemType _Item = Item;
			DescriptionType _ItemDescription = ItemDescription;
			TransNatType _TransNat = TransNat;
			TransNat2Type _TransNat2 = TransNat2;
			UMType _UM = UM;
			TermsCodeType _TermsCode = TermsCode;
			QtyUnitNoNegType _QtuQtyReceived = QtuQtyReceived;
			QtyUnitNoNegType _QtuQtyVoucher = QtuQtyVoucher;
			CostPrcType _CprItemCost = CprItemCost;
			CostPrcType _CprItemCostConv = CprItemCostConv;
			CostPrcType _CprPlanCostConv = CprPlanCostConv;
			DateType _PoRecordDate = PoRecordDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MaterialDistributionCustUpdSp";
				
				appDB.AddCommandParameter(cmd, "ConnectionId", _ConnectionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VchType", _VchType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoLine", _PoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoRelease", _PoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GrnNum", _GrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GrnLine", _GrnLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemDescription", _ItemDescription, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransNat", _TransNat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransNat2", _TransNat2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TermsCode", _TermsCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtuQtyReceived", _QtuQtyReceived, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtuQtyVoucher", _QtuQtyVoucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CprItemCost", _CprItemCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CprItemCostConv", _CprItemCostConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CprPlanCostConv", _CprPlanCostConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoRecordDate", _PoRecordDate, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
