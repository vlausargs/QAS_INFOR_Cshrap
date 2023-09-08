//PROJECT NAME: CSICustomer
//CLASS NAME: CLM_ChangeConsolidatedInvoicing.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface ICLM_ChangeConsolidatedInvoicing
	{
		DataTable CLM_ChangeConsolidatedInvoicingSp(string Process,
		                                            string StartCustomerNum,
		                                            string EndCustomerNum,
		                                            string StartOrderNum,
		                                            string EndOrderNum,
		                                            byte? ProcessCustomers,
		                                            byte? ProcessOrders,
		                                            byte? ConsolidatedInvoice,
		                                            byte? CollectionFlag,
		                                            ref string Infobar);
	}
	
	public class CLM_ChangeConsolidatedInvoicing : ICLM_ChangeConsolidatedInvoicing
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		
		public CLM_ChangeConsolidatedInvoicing(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
		}
		
		public DataTable CLM_ChangeConsolidatedInvoicingSp(string Process,
		                                                   string StartCustomerNum,
		                                                   string EndCustomerNum,
		                                                   string StartOrderNum,
		                                                   string EndOrderNum,
		                                                   byte? ProcessCustomers,
		                                                   byte? ProcessOrders,
		                                                   byte? ConsolidatedInvoice,
		                                                   byte? CollectionFlag,
		                                                   ref string Infobar)
		{
			StringType _Process = Process;
			CustNumType _StartCustomerNum = StartCustomerNum;
			CustNumType _EndCustomerNum = EndCustomerNum;
			CoNumType _StartOrderNum = StartOrderNum;
			CoNumType _EndOrderNum = EndOrderNum;
			ListYesNoType _ProcessCustomers = ProcessCustomers;
			ListYesNoType _ProcessOrders = ProcessOrders;
			ListYesNoType _ConsolidatedInvoice = ConsolidatedInvoice;
			ListYesNoType _CollectionFlag = CollectionFlag;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_ChangeConsolidatedInvoicingSp";
				
				appDB.AddCommandParameter(cmd, "Process", _Process, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartCustomerNum", _StartCustomerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndCustomerNum", _EndCustomerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartOrderNum", _StartOrderNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndOrderNum", _EndOrderNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProcessCustomers", _ProcessCustomers, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProcessOrders", _ProcessOrders, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ConsolidatedInvoice", _ConsolidatedInvoice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CollectionFlag", _CollectionFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                dtReturn = appDB.ExecuteQuery(cmd);

                Infobar = _Infobar;
				
				return dtReturn;
			}
		}
	}
}
