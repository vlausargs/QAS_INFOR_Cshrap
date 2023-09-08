//PROJECT NAME: Production
//CLASS NAME: PmfGetItemUmCnvFact.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfGetItemUmCnvFact
	{
		(int? ReturnCode, double? CnvToStock,
		double? CnvFromStock) PmfGetItemUmCnvFactor(string Item,
		string Um,
		decimal? FillQty,
		string FillUM,
		decimal? Density,
		double? CnvToStock = null,
		double? CnvFromStock = null);
	}
	
	public class PmfGetItemUmCnvFact : IPmfGetItemUmCnvFact
	{
		readonly IApplicationDB appDB;
		
		public PmfGetItemUmCnvFact(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, double? CnvToStock,
		double? CnvFromStock) PmfGetItemUmCnvFactor(string Item,
		string Um,
		decimal? FillQty,
		string FillUM,
		decimal? Density,
		double? CnvToStock = null,
		double? CnvFromStock = null)
		{
			ItemType _Item = Item;
			UMType _Um = Um;
			DecimalType _FillQty = FillQty;
			UMType _FillUM = FillUM;
			DecimalType _Density = Density;
			FloatType _CnvToStock = CnvToStock;
			FloatType _CnvFromStock = CnvFromStock;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfGetItemUmCnvFactor";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Um", _Um, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FillQty", _FillQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FillUM", _FillUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Density", _Density, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CnvToStock", _CnvToStock, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CnvFromStock", _CnvFromStock, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CnvToStock = _CnvToStock;
				CnvFromStock = _CnvFromStock;
				
				return (Severity, CnvToStock, CnvFromStock);
			}
		}
	}
}
