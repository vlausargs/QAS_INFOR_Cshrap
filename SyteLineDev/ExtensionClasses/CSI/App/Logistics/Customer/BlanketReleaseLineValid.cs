//PROJECT NAME: Logistics
//CLASS NAME: BlanketReleaseLineValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class BlanketReleaseLineValid : IBlanketReleaseLineValid
	{
		readonly IApplicationDB appDB;
		
		
		public BlanketReleaseLineValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string CblItem,
		decimal? CblBlanketQtyConv,
		decimal? CblContPriceConv,
		string CblUM,
		DateTime? CblEffDate,
		DateTime? CblExpDate,
		int? CoEdiOrder,
		int? ItemPlanFlag,
		string CoWhse,
		string CoSite,
		int? ICDuePeriod,
		int? ItemDuePeriod,
		string Infobar) BlanketReleaseLineValidSp(string CoNum,
		int? CoLine,
		string CblItem,
		decimal? CblBlanketQtyConv,
		decimal? CblContPriceConv,
		string CblUM,
		DateTime? CblEffDate,
		DateTime? CblExpDate,
		int? CoEdiOrder,
		int? ItemPlanFlag,
		string CoWhse,
		string CoSite,
		int? ICDuePeriod,
		int? ItemDuePeriod,
		string Infobar)
		{
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			ItemType _CblItem = CblItem;
			QtyUnitType _CblBlanketQtyConv = CblBlanketQtyConv;
			AmountType _CblContPriceConv = CblContPriceConv;
			UMType _CblUM = CblUM;
			GenericDate _CblEffDate = CblEffDate;
			GenericDate _CblExpDate = CblExpDate;
			Flag _CoEdiOrder = CoEdiOrder;
			Flag _ItemPlanFlag = ItemPlanFlag;
			WhseType _CoWhse = CoWhse;
			SiteType _CoSite = CoSite;
			DuePeriodType _ICDuePeriod = ICDuePeriod;
			DuePeriodType _ItemDuePeriod = ItemDuePeriod;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "BlanketReleaseLineValidSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CblItem", _CblItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CblBlanketQtyConv", _CblBlanketQtyConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CblContPriceConv", _CblContPriceConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CblUM", _CblUM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CblEffDate", _CblEffDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CblExpDate", _CblExpDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoEdiOrder", _CoEdiOrder, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemPlanFlag", _ItemPlanFlag, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoWhse", _CoWhse, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoSite", _CoSite, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ICDuePeriod", _ICDuePeriod, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemDuePeriod", _ItemDuePeriod, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CblItem = _CblItem;
				CblBlanketQtyConv = _CblBlanketQtyConv;
				CblContPriceConv = _CblContPriceConv;
				CblUM = _CblUM;
				CblEffDate = _CblEffDate;
				CblExpDate = _CblExpDate;
				CoEdiOrder = _CoEdiOrder;
				ItemPlanFlag = _ItemPlanFlag;
				CoWhse = _CoWhse;
				CoSite = _CoSite;
				ICDuePeriod = _ICDuePeriod;
				ItemDuePeriod = _ItemDuePeriod;
				Infobar = _Infobar;
				
				return (Severity, CblItem, CblBlanketQtyConv, CblContPriceConv, CblUM, CblEffDate, CblExpDate, CoEdiOrder, ItemPlanFlag, CoWhse, CoSite, ICDuePeriod, ItemDuePeriod, Infobar);
			}
		}
	}
}
