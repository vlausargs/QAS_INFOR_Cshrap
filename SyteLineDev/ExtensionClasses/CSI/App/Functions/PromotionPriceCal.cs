//PROJECT NAME: Data
//CLASS NAME: PromotionPriceCal.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class PromotionPriceCal : IPromotionPriceCal
	{
		readonly IApplicationDB appDB;
		
		public PromotionPriceCal(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? PromotionPrice,
			string Infobar) PromotionPriceCalSp(
			string PromotionCode,
			decimal? PQtyOrdered,
			string PCurrCode,
			decimal? PUnitPrice,
			decimal? PromotionPrice,
			string CoNum = null,
			int? CoLine = null,
			string Infobar = null,
			string Site = null)
		{
			PromotionCodeType _PromotionCode = PromotionCode;
			QtyUnitType _PQtyOrdered = PQtyOrdered;
			CurrCodeType _PCurrCode = PCurrCode;
			CostPrcType _PUnitPrice = PUnitPrice;
			CostPrcType _PromotionPrice = PromotionPrice;
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			InfobarType _Infobar = Infobar;
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PromotionPriceCalSp";
				
				appDB.AddCommandParameter(cmd, "PromotionCode", _PromotionCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQtyOrdered", _PQtyOrdered, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCurrCode", _PCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUnitPrice", _PUnitPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PromotionPrice", _PromotionPrice, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PromotionPrice = _PromotionPrice;
				Infobar = _Infobar;
				
				return (Severity, PromotionPrice, Infobar);
			}
		}
	}
}
