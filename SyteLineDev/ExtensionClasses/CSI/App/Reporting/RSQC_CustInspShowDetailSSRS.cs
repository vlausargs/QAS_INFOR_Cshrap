//PROJECT NAME: Reporting
//CLASS NAME: RSQC_CustInspShowDetailSSRS.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class RSQC_CustInspShowDetailSSRS : IRSQC_CustInspShowDetailSSRS
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public RSQC_CustInspShowDetailSSRS(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) RSQC_CustInspShowDetailSSRSSp(string i_conum,
		int? i_coline,
		int? i_corel,
		string psite)
		{
			CoNumType _i_conum = i_conum;
			CoLineType _i_coline = i_coline;
			CoReleaseType _i_corel = i_corel;
			SiteType _psite = psite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_CustInspShowDetailSSRSSp";
				
				appDB.AddCommandParameter(cmd, "i_conum", _i_conum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_coline", _i_coline, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_corel", _i_corel, ParameterDirection.Input);
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
