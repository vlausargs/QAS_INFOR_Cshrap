//PROJECT NAME: Data
//CLASS NAME: LoadPayableTransaction.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class LoadPayableTransaction : ILoadPayableTransaction
	{
		readonly IApplicationDB appDB;
		
		public LoadPayableTransaction(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) LoadPayableTransactionSp(
			string Vendor,
			string ActionCode,
			string RemittoVendor,
			decimal? PayableAmount,
			DateTime? DocumentDateTime,
			string Infobar)
		{
			VendNumType _Vendor = Vendor;
			StringType _ActionCode = ActionCode;
			VendNumType _RemittoVendor = RemittoVendor;
			AmountType _PayableAmount = PayableAmount;
			DateType _DocumentDateTime = DocumentDateTime;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadPayableTransactionSp";
				
				appDB.AddCommandParameter(cmd, "Vendor", _Vendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ActionCode", _ActionCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RemittoVendor", _RemittoVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PayableAmount", _PayableAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DocumentDateTime", _DocumentDateTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
