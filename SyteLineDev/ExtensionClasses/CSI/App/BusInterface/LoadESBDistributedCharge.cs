//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBDistributedCharge.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.BusInterface
{
	public interface ILoadESBDistributedCharge
	{
		int LoadESBDistributedChargeSp(string ConfirmationRef,
		                               short? CoLine,
		                               decimal? ChargeAmt,
		                               decimal? ChargePct,
		                               string ReasonCode,
		                               ref string Infobar);
	}
	
	public class LoadESBDistributedCharge : ILoadESBDistributedCharge
	{
		readonly IApplicationDB appDB;
		
		public LoadESBDistributedCharge(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int LoadESBDistributedChargeSp(string ConfirmationRef,
		                                      short? CoLine,
		                                      decimal? ChargeAmt,
		                                      decimal? ChargePct,
		                                      string ReasonCode,
		                                      ref string Infobar)
		{
			OrderConfirmationRefType _ConfirmationRef = ConfirmationRef;
			CoLineType _CoLine = CoLine;
			AmountType _ChargeAmt = ChargeAmt;
			AmountType _ChargePct = ChargePct;
			StringType _ReasonCode = ReasonCode;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBDistributedChargeSp";
				
				appDB.AddCommandParameter(cmd, "ConfirmationRef", _ConfirmationRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChargeAmt", _ChargeAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChargePct", _ChargePct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReasonCode", _ReasonCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
