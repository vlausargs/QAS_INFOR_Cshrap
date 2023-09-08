//PROJECT NAME: Material
//CLASS NAME: CalcUnitPrice1.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class CalcUnitPrice1 : ICalcUnitPrice1
	{
		readonly IApplicationDB appDB;
		
		
		public CalcUnitPrice1(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? PUnitPrice1,
		decimal? UnitCost,
		string Prodcode,
		string Pricecode,
		string PricecodeDesc,
		decimal? CurUCost) CalcUnitPrice1Sp(string PCurrCode,
		decimal? PUnitPrice1,
		string PItem = null,
		decimal? UnitCost = null,
		string Prodcode = null,
		string Pricecode = null,
		string PricecodeDesc = null,
		decimal? CurUCost = null)
		{
			CurrCodeType _PCurrCode = PCurrCode;
			CostPrcType _PUnitPrice1 = PUnitPrice1;
			ItemType _PItem = PItem;
			CostPrcType _UnitCost = UnitCost;
			ProductCodeType _Prodcode = Prodcode;
			PriceCodeType _Pricecode = Pricecode;
			DescriptionType _PricecodeDesc = PricecodeDesc;
			CostPrcType _CurUCost = CurUCost;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CalcUnitPrice1Sp";
				
				appDB.AddCommandParameter(cmd, "PCurrCode", _PCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUnitPrice1", _PUnitPrice1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitCost", _UnitCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Prodcode", _Prodcode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Pricecode", _Pricecode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PricecodeDesc", _PricecodeDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurUCost", _CurUCost, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PUnitPrice1 = _PUnitPrice1;
				UnitCost = _UnitCost;
				Prodcode = _Prodcode;
				Pricecode = _Pricecode;
				PricecodeDesc = _PricecodeDesc;
				CurUCost = _CurUCost;
				
				return (Severity, PUnitPrice1, UnitCost, Prodcode, Pricecode, PricecodeDesc, CurUCost);
			}
		}
	}
}
