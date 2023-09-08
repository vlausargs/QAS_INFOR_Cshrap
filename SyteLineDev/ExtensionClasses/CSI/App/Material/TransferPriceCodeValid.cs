//PROJECT NAME: Material
//CLASS NAME: TransferPriceCodeValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface ITransferPriceCodeValid
	{
		(int? ReturnCode, string PricecodeDesc, decimal? UnitPrice, decimal? ExtPrice, string Infobar) TransferPriceCodeValidSp(string TrnNum,
		                                                                                                                        string Pricecode,
		                                                                                                                        string Item,
		                                                                                                                        decimal? QtyReq,
		                                                                                                                        string PricecodeDesc,
		                                                                                                                        decimal? UnitPrice,
		                                                                                                                        decimal? ExtPrice,
		                                                                                                                        string Infobar);
	}
	
	public class TransferPriceCodeValid : ITransferPriceCodeValid
	{
		readonly IApplicationDB appDB;
		
		public TransferPriceCodeValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PricecodeDesc, decimal? UnitPrice, decimal? ExtPrice, string Infobar) TransferPriceCodeValidSp(string TrnNum,
		                                                                                                                               string Pricecode,
		                                                                                                                               string Item,
		                                                                                                                               decimal? QtyReq,
		                                                                                                                               string PricecodeDesc,
		                                                                                                                               decimal? UnitPrice,
		                                                                                                                               decimal? ExtPrice,
		                                                                                                                               string Infobar)
		{
			TrnNumType _TrnNum = TrnNum;
			PriceCodeType _Pricecode = Pricecode;
			ItemType _Item = Item;
			QtyUnitType _QtyReq = QtyReq;
			DescriptionType _PricecodeDesc = PricecodeDesc;
			CostPrcType _UnitPrice = UnitPrice;
			CostPrcType _ExtPrice = ExtPrice;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TransferPriceCodeValidSp";
				
				appDB.AddCommandParameter(cmd, "TrnNum", _TrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Pricecode", _Pricecode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyReq", _QtyReq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PricecodeDesc", _PricecodeDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitPrice", _UnitPrice, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ExtPrice", _ExtPrice, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PricecodeDesc = _PricecodeDesc;
				UnitPrice = _UnitPrice;
				ExtPrice = _ExtPrice;
				Infobar = _Infobar;
				
				return (Severity, PricecodeDesc, UnitPrice, ExtPrice, Infobar);
			}
		}
	}
}
