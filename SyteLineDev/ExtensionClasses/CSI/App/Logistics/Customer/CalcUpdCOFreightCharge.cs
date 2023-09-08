//PROJECT NAME: Logistics
//CLASS NAME: CalcUpdCOFreightCharge.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CalcUpdCOFreightCharge : ICalcUpdCOFreightCharge
	{
		readonly IApplicationDB appDB;
		
		
		public CalcUpdCOFreightCharge(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? COFreightChargeAmt,
		string Infobar) CalcUpdCOFreightChargeSp(string CoNum,
		string COShipMethod = null,
		decimal? COFreightChargeAmt = 0,
		string CalledByCO = null,
		string Infobar = null)
		{
			CoNumType _CoNum = CoNum;
			ShipMethodType _COShipMethod = COShipMethod;
			AmountType _COFreightChargeAmt = COFreightChargeAmt;
			StringType _CalledByCO = CalledByCO;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CalcUpdCOFreightChargeSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "COShipMethod", _COShipMethod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "COFreightChargeAmt", _COFreightChargeAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CalledByCO", _CalledByCO, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				COFreightChargeAmt = _COFreightChargeAmt;
				Infobar = _Infobar;
				
				return (Severity, COFreightChargeAmt, Infobar);
			}
		}
	}
}
