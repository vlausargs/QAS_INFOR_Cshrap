//PROJECT NAME: BusInterface
//CLASS NAME: LoadESBPayableTransaction.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBPayableTransaction : ILoadESBPayableTransaction
	{
		readonly IApplicationDB appDB;
		
		
		public LoadESBPayableTransaction(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) LoadESBPayableTransactionSp(string Vendor,
		string ActionCode,
		string RemittoVendor,
		decimal? PayableAmount,
		string VendorCurrCode,
		DateTime? DocumentDateTime,
		string Infobar)
		{
			VendNumType _Vendor = Vendor;
			StringType _ActionCode = ActionCode;
			VendNumType _RemittoVendor = RemittoVendor;
			AmountType _PayableAmount = PayableAmount;
			CurrCodeType _VendorCurrCode = VendorCurrCode;
			DateType _DocumentDateTime = DocumentDateTime;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBPayableTransactionSp";
				
				appDB.AddCommandParameter(cmd, "Vendor", _Vendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ActionCode", _ActionCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RemittoVendor", _RemittoVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PayableAmount", _PayableAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendorCurrCode", _VendorCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DocumentDateTime", _DocumentDateTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
