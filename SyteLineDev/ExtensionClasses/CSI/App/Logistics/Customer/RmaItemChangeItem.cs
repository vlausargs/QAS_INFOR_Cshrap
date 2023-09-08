//PROJECT NAME: CSICustomer
//CLASS NAME: RmaItemChangeItem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IRmaItemChangeItem
	{
		int RmaItemChangeItemSp(string PRmaNum,
		                        short? PRmaLine,
		                        string PCoNum,
		                        short? PCoLine,
		                        short? PCoRelease,
		                        string PCustNum,
		                        ref string PItem,
		                        ref string PCustItem,
		                        ref string RItemDesc,
		                        ref string RItemUM,
		                        ref byte? RItemSerTrack,
		                        ref string RItemOrigin,
		                        ref string RItemCommCode,
		                        ref decimal? RItemUnitWeight,
		                        ref string TaxCode1,
		                        ref string TaxCode1Desc,
		                        ref string TaxCode2,
		                        ref string TaxCode2Desc,
		                        ref string Infobar,
		                        ref byte? SupplQtyReq,
		                        ref double? SupplQtyConvFactor);
	}
	
	public class RmaItemChangeItem : IRmaItemChangeItem
	{
		readonly IApplicationDB appDB;
		
		public RmaItemChangeItem(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int RmaItemChangeItemSp(string PRmaNum,
		                               short? PRmaLine,
		                               string PCoNum,
		                               short? PCoLine,
		                               short? PCoRelease,
		                               string PCustNum,
		                               ref string PItem,
		                               ref string PCustItem,
		                               ref string RItemDesc,
		                               ref string RItemUM,
		                               ref byte? RItemSerTrack,
		                               ref string RItemOrigin,
		                               ref string RItemCommCode,
		                               ref decimal? RItemUnitWeight,
		                               ref string TaxCode1,
		                               ref string TaxCode1Desc,
		                               ref string TaxCode2,
		                               ref string TaxCode2Desc,
		                               ref string Infobar,
		                               ref byte? SupplQtyReq,
		                               ref double? SupplQtyConvFactor)
		{
			RmaNumType _PRmaNum = PRmaNum;
			RmaLineType _PRmaLine = PRmaLine;
			CoNumType _PCoNum = PCoNum;
			CoLineType _PCoLine = PCoLine;
			CoReleaseType _PCoRelease = PCoRelease;
			CustNumType _PCustNum = PCustNum;
			ItemType _PItem = PItem;
			ItemType _PCustItem = PCustItem;
			DescriptionType _RItemDesc = RItemDesc;
			UMType _RItemUM = RItemUM;
			ListYesNoType _RItemSerTrack = RItemSerTrack;
			EcCodeType _RItemOrigin = RItemOrigin;
			CommodityCodeType _RItemCommCode = RItemCommCode;
			ItemWeightType _RItemUnitWeight = RItemUnitWeight;
			TaxCodeType _TaxCode1 = TaxCode1;
			DescriptionType _TaxCode1Desc = TaxCode1Desc;
			TaxCodeType _TaxCode2 = TaxCode2;
			DescriptionType _TaxCode2Desc = TaxCode2Desc;
			InfobarType _Infobar = Infobar;
			FlagNyType _SupplQtyReq = SupplQtyReq;
			UMConvFactorType _SupplQtyConvFactor = SupplQtyConvFactor;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RmaItemChangeItemSp";
				
				appDB.AddCommandParameter(cmd, "PRmaNum", _PRmaNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRmaLine", _PRmaLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoNum", _PCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoLine", _PCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoRelease", _PCoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PCustItem", _PCustItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RItemDesc", _RItemDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RItemUM", _RItemUM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RItemSerTrack", _RItemSerTrack, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RItemOrigin", _RItemOrigin, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RItemCommCode", _RItemCommCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RItemUnitWeight", _RItemUnitWeight, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode1", _TaxCode1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode1Desc", _TaxCode1Desc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode2", _TaxCode2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode2Desc", _TaxCode2Desc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SupplQtyReq", _SupplQtyReq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SupplQtyConvFactor", _SupplQtyConvFactor, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PItem = _PItem;
				PCustItem = _PCustItem;
				RItemDesc = _RItemDesc;
				RItemUM = _RItemUM;
				RItemSerTrack = _RItemSerTrack;
				RItemOrigin = _RItemOrigin;
				RItemCommCode = _RItemCommCode;
				RItemUnitWeight = _RItemUnitWeight;
				TaxCode1 = _TaxCode1;
				TaxCode1Desc = _TaxCode1Desc;
				TaxCode2 = _TaxCode2;
				TaxCode2Desc = _TaxCode2Desc;
				Infobar = _Infobar;
				SupplQtyReq = _SupplQtyReq;
				SupplQtyConvFactor = _SupplQtyConvFactor;
				
				return Severity;
			}
		}
	}
}
