//PROJECT NAME: Production
//CLASS NAME: PmfSpecCostingReportCosting.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfSpecCostingReportCosting
	{
		(ICollectionLoadResponse Data, int? ReturnCode) PmfSpecCostingReportCostingSp(string mf_spec,
		                                                                              string mf_spec_ver,
		                                                                              string SiteRef);
	}
	
	public class PmfSpecCostingReportCosting : IPmfSpecCostingReportCosting
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public PmfSpecCostingReportCosting(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) PmfSpecCostingReportCostingSp(string mf_spec,
		                                                                                     string mf_spec_ver,
		                                                                                     string SiteRef)
		{
			StringType _mf_spec = mf_spec;
			StringType _mf_spec_ver = mf_spec_ver;
			SiteType _SiteRef = SiteRef;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfSpecCostingReportCostingSp";
				
				appDB.AddCommandParameter(cmd, "mf_spec", _mf_spec, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "mf_spec_ver", _mf_spec_ver, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SiteRef", _SiteRef, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
