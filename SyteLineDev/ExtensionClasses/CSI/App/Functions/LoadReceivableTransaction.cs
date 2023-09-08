//PROJECT NAME: Data
//CLASS NAME: LoadReceivableTransaction.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class LoadReceivableTransaction : ILoadReceivableTransaction
	{
		readonly IApplicationDB appDB;
		
		public LoadReceivableTransaction(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? LoadReceivableTransactionSp(
			string Customer,
			string ActionCode,
			string BilltoCustomer,
			decimal? Receievablebaseamount,
			string Infobar)
		{
			CustNumType _Customer = Customer;
			StringType _ActionCode = ActionCode;
			CustNumType _BilltoCustomer = BilltoCustomer;
			AmountType _Receievablebaseamount = Receievablebaseamount;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadReceivableTransactionSp";
				
				appDB.AddCommandParameter(cmd, "Customer", _Customer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ActionCode", _ActionCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BilltoCustomer", _BilltoCustomer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Receievablebaseamount", _Receievablebaseamount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
