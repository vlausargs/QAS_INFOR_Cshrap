//PROJECT NAME: CSIVendor
//CLASS NAME: APEnd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IAPEnd
	{
		(int? ReturnCode, string Infobar) APEndSP(string PStartingVendNum = null,
		string PEndingVendNum = null,
		byte? PResetPurchasesYTD = (byte)0,
		byte? PResetDiscountsYTD = (byte)0,
		byte? PResetPaymentsYTD = (byte)0,
		byte? PResetPaymentsFiscalYTD = (byte)0,
		string Infobar = null);
	}
	
	public class APEnd : IAPEnd
	{
		readonly IApplicationDB appDB;
		
		public APEnd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) APEndSP(string PStartingVendNum = null,
		string PEndingVendNum = null,
		byte? PResetPurchasesYTD = (byte)0,
		byte? PResetDiscountsYTD = (byte)0,
		byte? PResetPaymentsYTD = (byte)0,
		byte? PResetPaymentsFiscalYTD = (byte)0,
		string Infobar = null)
		{
			VendNumType _PStartingVendNum = PStartingVendNum;
			VendNumType _PEndingVendNum = PEndingVendNum;
			ListYesNoType _PResetPurchasesYTD = PResetPurchasesYTD;
			ListYesNoType _PResetDiscountsYTD = PResetDiscountsYTD;
			ListYesNoType _PResetPaymentsYTD = PResetPaymentsYTD;
			ListYesNoType _PResetPaymentsFiscalYTD = PResetPaymentsFiscalYTD;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "APEndSP";
				
				appDB.AddCommandParameter(cmd, "PStartingVendNum", _PStartingVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingVendNum", _PEndingVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PResetPurchasesYTD", _PResetPurchasesYTD, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PResetDiscountsYTD", _PResetDiscountsYTD, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PResetPaymentsYTD", _PResetPaymentsYTD, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PResetPaymentsFiscalYTD", _PResetPaymentsFiscalYTD, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
