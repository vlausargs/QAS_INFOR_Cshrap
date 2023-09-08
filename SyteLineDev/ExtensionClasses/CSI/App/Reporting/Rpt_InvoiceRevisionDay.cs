//PROJECT NAME: Reporting
//CLASS NAME: Rpt_InvoiceRevisionDay.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_InvoiceRevisionDay : IRpt_InvoiceRevisionDay
	{
		IApplicationDB appDB;
		IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_InvoiceRevisionDay(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_InvoiceRevisionDaySp(string PStartInvoice = null,
		string PEndInvoice = null,
		DateTime? PStartInvDate = null,
		DateTime? PEndInvDate = null,
		string PStartCustomer = null,
		string PEndCustomer = null,
		int? PDisplayHeader = 1,
		string pSite = null)
		{
			InvNumType _PStartInvoice = PStartInvoice;
			InvNumType _PEndInvoice = PEndInvoice;
			GenericDateType _PStartInvDate = PStartInvDate;
			GenericDateType _PEndInvDate = PEndInvDate;
			CustNumType _PStartCustomer = PStartCustomer;
			CustNumType _PEndCustomer = PEndCustomer;
			ListYesNoType _PDisplayHeader = PDisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_InvoiceRevisionDaySp";
				
				appDB.AddCommandParameter(cmd, "PStartInvoice", _PStartInvoice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndInvoice", _PEndInvoice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartInvDate", _PStartInvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndInvDate", _PEndInvDate, ParameterDirection.Input);
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
