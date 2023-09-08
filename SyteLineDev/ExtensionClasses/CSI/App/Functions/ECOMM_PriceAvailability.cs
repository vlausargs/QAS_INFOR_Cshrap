//PROJECT NAME: Data
//CLASS NAME: ECOMM_PriceAvailability.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ECOMM_PriceAvailability : IECOMM_PriceAvailability
	{
		readonly IApplicationDB appDB;
		
		public ECOMM_PriceAvailability(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? QuantityAvailable,
			decimal? Price,
			string Infobar) ECOMM_PriceAvailabilitySp(
			string CustomerNumber,
			int? ShipToNumber,
			int? DefaultWhseOnly,
			string Item,
			decimal? OrderQty,
			int? CalculatePrices,
			string UnitOfMeasure,
			string Warehouse,
			decimal? QuantityAvailable,
			decimal? Price,
			string Infobar)
		{
			CustNumType _CustomerNumber = CustomerNumber;
			CustSeqType _ShipToNumber = ShipToNumber;
			ListYesNoType _DefaultWhseOnly = DefaultWhseOnly;
			ItemType _Item = Item;
			QtyUnitType _OrderQty = OrderQty;
			ListYesNoType _CalculatePrices = CalculatePrices;
			UMType _UnitOfMeasure = UnitOfMeasure;
			WhseType _Warehouse = Warehouse;
			QtyUnitType _QuantityAvailable = QuantityAvailable;
			CostPrcType _Price = Price;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ECOMM_PriceAvailabilitySp";
				
				appDB.AddCommandParameter(cmd, "CustomerNumber", _CustomerNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipToNumber", _ShipToNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DefaultWhseOnly", _DefaultWhseOnly, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderQty", _OrderQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CalculatePrices", _CalculatePrices, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitOfMeasure", _UnitOfMeasure, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Warehouse", _Warehouse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QuantityAvailable", _QuantityAvailable, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Price", _Price, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				QuantityAvailable = _QuantityAvailable;
				Price = _Price;
				Infobar = _Infobar;
				
				return (Severity, QuantityAvailable, Price, Infobar);
			}
		}
	}
}
