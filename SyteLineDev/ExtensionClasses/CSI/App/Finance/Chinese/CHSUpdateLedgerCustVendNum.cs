//PROJECT NAME: CSIChineseFinancials
//CLASS NAME: CHSUpdateLedgerCustVendNum.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.Chinese
{
	public interface ICHSUpdateLedgerCustVendNum
	{
		int CHSUpdateLedgerCustVendNumSp(decimal? TransNum,
		                                 Guid? RowPointer,
		                                 string CustVendNum,
		                                 ref string Infobar);
	}
	
	public class CHSUpdateLedgerCustVendNum : ICHSUpdateLedgerCustVendNum
	{
		readonly IApplicationDB appDB;
		
		public CHSUpdateLedgerCustVendNum(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int CHSUpdateLedgerCustVendNumSp(decimal? TransNum,
		                                        Guid? RowPointer,
		                                        string CustVendNum,
		                                        ref string Infobar)
		{
			MatlTransNumType _TransNum = TransNum;
			RowPointer _RowPointer = RowPointer;
			VendNumType _CustVendNum = CustVendNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CHSUpdateLedgerCustVendNumSp";
				
				appDB.AddCommandParameter(cmd, "TransNum", _TransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustVendNum", _CustVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
