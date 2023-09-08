//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBReceivableTransaction.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.BusInterface
{
	public interface ILoadESBReceivableTransaction
	{
		int LoadESBReceivableTransactionSp(string Customer,
		                                   string ActionCode,
		                                   string BilltoCustomer,
		                                   decimal? Receievablebaseamount,
		                                   string Infobar);
	}
	
	public class LoadESBReceivableTransaction : ILoadESBReceivableTransaction
	{
		readonly IApplicationDB appDB;
		
		public LoadESBReceivableTransaction(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int LoadESBReceivableTransactionSp(string Customer,
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
				cmd.CommandText = "LoadESBReceivableTransactionSp";
				
				appDB.AddCommandParameter(cmd, "Customer", _Customer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ActionCode", _ActionCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BilltoCustomer", _BilltoCustomer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Receievablebaseamount", _Receievablebaseamount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return Severity;
			}
		}
	}
}
