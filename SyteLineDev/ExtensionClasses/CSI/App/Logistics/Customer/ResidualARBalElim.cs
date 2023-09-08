//PROJECT NAME: Logistics
//CLASS NAME: ResidualARBalElim.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IResidualARBalElim
	{
		(int? ReturnCode, string Infobar) ResidualARBalElimSp(string PInvoiceNum,
		string PCustomerNum,
		decimal? PAmount,
		string ArinvdAcct,
		string ArinvdAcctUnit1,
		string ArinvdAcctUnit2,
		string ArinvdAcctUnit3,
		string ArinvdAcctUnit4,
		string Infobar = null);
	}
	
	public class ResidualARBalElim : IResidualARBalElim
	{
		readonly IApplicationDB appDB;
		
		public ResidualARBalElim(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) ResidualARBalElimSp(string PInvoiceNum,
		string PCustomerNum,
		decimal? PAmount,
		string ArinvdAcct,
		string ArinvdAcctUnit1,
		string ArinvdAcctUnit2,
		string ArinvdAcctUnit3,
		string ArinvdAcctUnit4,
		string Infobar = null)
		{
			InvNumType _PInvoiceNum = PInvoiceNum;
			CustNumType _PCustomerNum = PCustomerNum;
			AmountType _PAmount = PAmount;
			AcctType _ArinvdAcct = ArinvdAcct;
			UnitCode1Type _ArinvdAcctUnit1 = ArinvdAcctUnit1;
			UnitCode2Type _ArinvdAcctUnit2 = ArinvdAcctUnit2;
			UnitCode3Type _ArinvdAcctUnit3 = ArinvdAcctUnit3;
			UnitCode4Type _ArinvdAcctUnit4 = ArinvdAcctUnit4;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ResidualARBalElimSp";
				
				appDB.AddCommandParameter(cmd, "PInvoiceNum", _PInvoiceNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustomerNum", _PCustomerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAmount", _PAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArinvdAcct", _ArinvdAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArinvdAcctUnit1", _ArinvdAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArinvdAcctUnit2", _ArinvdAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArinvdAcctUnit3", _ArinvdAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArinvdAcctUnit4", _ArinvdAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
