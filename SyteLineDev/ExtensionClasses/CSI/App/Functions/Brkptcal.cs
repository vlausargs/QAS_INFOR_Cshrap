//PROJECT NAME: Data
//CLASS NAME: Brkptcal.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class Brkptcal : IBrkptcal
	{
		readonly IApplicationDB appDB;
		
		public Brkptcal(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? TcCprOnHand) BrkptcalSp(
			int? TLine,
			decimal? PUnitPrice,
			string PCurItem,
			string PCurCurrCode,
			DateTime? PCurEffectDate,
			string PBaseCode,
			string PDolPercent,
			decimal? PBrkQty,
			decimal? PBrkPrice,
			decimal? TcCprOnHand)
		{
			GenericNoType _TLine = TLine;
			CostPrcType _PUnitPrice = PUnitPrice;
			ItemType _PCurItem = PCurItem;
			CurrCodeType _PCurCurrCode = PCurCurrCode;
			Date4Type _PCurEffectDate = PCurEffectDate;
			LongListType _PBaseCode = PBaseCode;
			LongListType _PDolPercent = PDolPercent;
			QtyUnitType _PBrkQty = PBrkQty;
			CostPrcType _PBrkPrice = PBrkPrice;
			GenericDecimalType _TcCprOnHand = TcCprOnHand;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Brkptcal";
				
				appDB.AddCommandParameter(cmd, "TLine", _TLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUnitPrice", _PUnitPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCurItem", _PCurItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCurCurrCode", _PCurCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCurEffectDate", _PCurEffectDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBaseCode", _PBaseCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDolPercent", _PDolPercent, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBrkQty", _PBrkQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBrkPrice", _PBrkPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TcCprOnHand", _TcCprOnHand, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TcCprOnHand = _TcCprOnHand;
				
				return (Severity, TcCprOnHand);
			}
		}
	}
}
