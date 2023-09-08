//PROJECT NAME: Data
//CLASS NAME: Totval.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class Totval : ITotval
	{
		readonly IApplicationDB appDB;
		
		public Totval(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? RetCoPrice,
			decimal? RetShipPrice,
			string Infobar) TotvalSp(
			string LcrNum,
			string CoNum,
			string FromCurrCode,
			string ToCurrCode,
			int? NeedShipPrice,
			decimal? RetCoPrice,
			decimal? RetShipPrice,
			string Infobar)
		{
			LcrNumType _LcrNum = LcrNum;
			CoNumType _CoNum = CoNum;
			CurrCodeType _FromCurrCode = FromCurrCode;
			CurrCodeType _ToCurrCode = ToCurrCode;
			Flag _NeedShipPrice = NeedShipPrice;
			AmountType _RetCoPrice = RetCoPrice;
			AmountType _RetShipPrice = RetShipPrice;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TotvalSp";
				
				appDB.AddCommandParameter(cmd, "LcrNum", _LcrNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromCurrCode", _FromCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToCurrCode", _ToCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NeedShipPrice", _NeedShipPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RetCoPrice", _RetCoPrice, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RetShipPrice", _RetShipPrice, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				RetCoPrice = _RetCoPrice;
				RetShipPrice = _RetShipPrice;
				Infobar = _Infobar;
				
				return (Severity, RetCoPrice, RetShipPrice, Infobar);
			}
		}
	}
}
