//PROJECT NAME: CSIProjects
//CLASS NAME: ProfileReprintProjInv.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public interface IProfileReprintProjInv
	{
		(ICollectionLoadResponse Data, int? ReturnCode) ProfileReprintProjInvSp(string InvoiceStarting = null,
		string InvoiceEnding = null,
		DateTime? InvoiceDateStarting = null,
		DateTime? InvoiceDateEnding = null,
		string ProjectStarting = null,
		string ProjectEnding = null,
		string CustomerStarting = null,
		string CustomerEnding = null);
	}
	
	public class ProfileReprintProjInv : IProfileReprintProjInv
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public ProfileReprintProjInv(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) ProfileReprintProjInvSp(string InvoiceStarting = null,
		string InvoiceEnding = null,
		DateTime? InvoiceDateStarting = null,
		DateTime? InvoiceDateEnding = null,
		string ProjectStarting = null,
		string ProjectEnding = null,
		string CustomerStarting = null,
		string CustomerEnding = null)
		{
			InvNumType _InvoiceStarting = InvoiceStarting;
			InvNumType _InvoiceEnding = InvoiceEnding;
			DateType _InvoiceDateStarting = InvoiceDateStarting;
			DateType _InvoiceDateEnding = InvoiceDateEnding;
			ProjNumType _ProjectStarting = ProjectStarting;
			ProjNumType _ProjectEnding = ProjectEnding;
			CustNumType _CustomerStarting = CustomerStarting;
			CustNumType _CustomerEnding = CustomerEnding;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProfileReprintProjInvSp";
				
				appDB.AddCommandParameter(cmd, "InvoiceStarting", _InvoiceStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvoiceEnding", _InvoiceEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvoiceDateStarting", _InvoiceDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvoiceDateEnding", _InvoiceDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProjectStarting", _ProjectStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProjectEnding", _ProjectEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerStarting", _CustomerStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerEnding", _CustomerEnding, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
