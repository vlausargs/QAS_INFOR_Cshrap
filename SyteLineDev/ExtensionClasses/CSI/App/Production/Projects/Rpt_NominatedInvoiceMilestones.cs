//PROJECT NAME: Production
//CLASS NAME: Rpt_NominatedInvoiceMilestones.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public class Rpt_NominatedInvoiceMilestones : IRpt_NominatedInvoiceMilestones
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_NominatedInvoiceMilestones(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_NominatedInvoiceMilestonesSp(string PProjectStarting,
		string PProjectEnding,
		string PInvoiceMilestoneStarting,
		string PInvoiceMilestoneEnding,
		int? PPeriod,
		int? PNonPostedMSOnly,
		int? PYear,
		int? PPrintCost,
		string PSite = null)
		{
			ProjNumType _PProjectStarting = PProjectStarting;
			ProjNumType _PProjectEnding = PProjectEnding;
			ProjMsNumType _PInvoiceMilestoneStarting = PInvoiceMilestoneStarting;
			ProjMsNumType _PInvoiceMilestoneEnding = PInvoiceMilestoneEnding;
			IntType _PPeriod = PPeriod;
			IntType _PNonPostedMSOnly = PNonPostedMSOnly;
			IntType _PYear = PYear;
			IntType _PPrintCost = PPrintCost;
			SiteType _PSite = PSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_NominatedInvoiceMilestonesSp";
				
				appDB.AddCommandParameter(cmd, "PProjectStarting", _PProjectStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PProjectEnding", _PProjectEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInvoiceMilestoneStarting", _PInvoiceMilestoneStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInvoiceMilestoneEnding", _PInvoiceMilestoneEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPeriod", _PPeriod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNonPostedMSOnly", _PNonPostedMSOnly, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PYear", _PYear, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPrintCost", _PPrintCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSite", _PSite, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
