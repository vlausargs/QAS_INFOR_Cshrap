//PROJECT NAME: Logistics
//CLASS NAME: Rpt_InvoicePayDay.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class Rpt_InvoicePayDay : IRpt_InvoicePayDay
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_InvoicePayDay(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_InvoicePayDaySp(string PStartInvoice = null,
		string PEndInvoice = null,
		string PStartCustomer = null,
		string PEndCustomer = null,
		int? PDisplayHeader = 1,
		string pSite = null)
		{
			InvNumType _PStartInvoice = PStartInvoice;
			InvNumType _PEndInvoice = PEndInvoice;
			CustNumType _PStartCustomer = PStartCustomer;
			CustNumType _PEndCustomer = PEndCustomer;
			ListYesNoType _PDisplayHeader = PDisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_InvoicePayDaySp";
				
				appDB.AddCommandParameter(cmd, "PStartInvoice", _PStartInvoice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndInvoice", _PEndInvoice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartCustomer", _PStartCustomer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndCustomer", _PEndCustomer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDisplayHeader", _PDisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
