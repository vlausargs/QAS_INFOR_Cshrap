//PROJECT NAME: Finance
//CLASS NAME: Portal_SSSCCICoBal.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.CreditCard
{
	public interface IPortal_SSSCCICoBal
	{
		(int? ReturnCode, decimal? Balance,
		decimal? TaxAmt,
		decimal? ExchRate,
		decimal? ForAmt,
		int? CustSeq,
		string Infobar) Portal_SSSCCICoBalSp(string CoNum,
		decimal? Balance,
		decimal? TaxAmt,
		decimal? ExchRate,
		decimal? ForAmt,
		int? CustSeq,
		string Infobar,
		string AuthType = null,
		string ShipMethod = null);
	}
	
	public class Portal_SSSCCICoBal : IPortal_SSSCCICoBal
	{
		readonly IApplicationDB appDB;
		
		public Portal_SSSCCICoBal(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? Balance,
		decimal? TaxAmt,
		decimal? ExchRate,
		decimal? ForAmt,
		int? CustSeq,
		string Infobar) Portal_SSSCCICoBalSp(string CoNum,
		decimal? Balance,
		decimal? TaxAmt,
		decimal? ExchRate,
		decimal? ForAmt,
		int? CustSeq,
		string Infobar,
		string AuthType = null,
		string ShipMethod = null)
		{
			InvNumType _CoNum = CoNum;
			AmountType _Balance = Balance;
			AmountType _TaxAmt = TaxAmt;
			ExchRateType _ExchRate = ExchRate;
			AmountType _ForAmt = ForAmt;
			CustSeqType _CustSeq = CustSeq;
			Infobar _Infobar = Infobar;
			CCITransTypeType _AuthType = AuthType;
			ShipMethodType _ShipMethod = ShipMethod;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Portal_SSSCCICoBalSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Balance", _Balance, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxAmt", _TaxAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ExchRate", _ExchRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ForAmt", _ForAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AuthType", _AuthType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipMethod", _ShipMethod, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Balance = _Balance;
				TaxAmt = _TaxAmt;
				ExchRate = _ExchRate;
				ForAmt = _ForAmt;
				CustSeq = _CustSeq;
				Infobar = _Infobar;
				
				return (Severity, Balance, TaxAmt, ExchRate, ForAmt, CustSeq, Infobar);
			}
		}
	}
}
