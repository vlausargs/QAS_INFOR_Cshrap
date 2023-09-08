//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RSQC_SupReadyForReceiptsSSRS.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_RSQC_SupReadyForReceiptsSSRS : IRpt_RSQC_SupReadyForReceiptsSSRS
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_RSQC_SupReadyForReceiptsSSRS(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_RSQC_SupReadyForReceiptsSSRSSp(int? showdetail = null,
		int? displayheader = null,
		string psite = null)
		{
			ListYesNoType _showdetail = showdetail;
			ListYesNoType _displayheader = displayheader;
			SiteType _psite = psite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_RSQC_SupReadyForReceiptsSSRSSp";
				
				appDB.AddCommandParameter(cmd, "showdetail", _showdetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "displayheader", _displayheader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "psite", _psite, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
