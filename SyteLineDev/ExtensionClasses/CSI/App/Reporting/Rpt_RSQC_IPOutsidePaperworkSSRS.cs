//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RSQC_IPOutsidePaperworkSSRS.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_RSQC_IPOutsidePaperworkSSRS : IRpt_RSQC_IPOutsidePaperworkSSRS
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_RSQC_IPOutsidePaperworkSSRS(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_RSQC_IPOutsidePaperworkSSRSSp(string begjob = null,
		int? begsuff = null,
		int? begoper = null,
		string psite = null)
		{
			JobType _begjob = begjob;
			SuffixType _begsuff = begsuff;
			OperNumType _begoper = begoper;
			SiteType _psite = psite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_RSQC_IPOutsidePaperworkSSRSSp";
				
				appDB.AddCommandParameter(cmd, "begjob", _begjob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "begsuff", _begsuff, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "begoper", _begoper, ParameterDirection.Input);
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
