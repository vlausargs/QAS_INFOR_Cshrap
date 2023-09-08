//PROJECT NAME: Reporting
//CLASS NAME: Rpt_EstimateJobIndentedBOM.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_EstimateJobIndentedBOM
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_EstimateJobIndentedBOMSp(string JobStarting = null,
		string JobEnding = null,
		short? SuffixStarting = null,
		short? SuffixEnding = null,
		byte? PrintItemDesc = null,
		string PrintBetweenLevel = null,
		byte? PrintRefFields = null,
		byte? DisplayHeader = (byte)1,
		string pSite = null);
	}
	
	public class Rpt_EstimateJobIndentedBOM : IRpt_EstimateJobIndentedBOM
	{
		IApplicationDB appDB;
		IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_EstimateJobIndentedBOM(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_EstimateJobIndentedBOMSp(string JobStarting = null,
		string JobEnding = null,
		short? SuffixStarting = null,
		short? SuffixEnding = null,
		byte? PrintItemDesc = null,
		string PrintBetweenLevel = null,
		byte? PrintRefFields = null,
		byte? DisplayHeader = (byte)1,
		string pSite = null)
		{
			JobType _JobStarting = JobStarting;
			JobType _JobEnding = JobEnding;
			SuffixType _SuffixStarting = SuffixStarting;
			SuffixType _SuffixEnding = SuffixEnding;
			FlagNyType _PrintItemDesc = PrintItemDesc;
			InfobarType _PrintBetweenLevel = PrintBetweenLevel;
			FlagNyType _PrintRefFields = PrintRefFields;
			FlagNyType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_EstimateJobIndentedBOMSp";
				
				appDB.AddCommandParameter(cmd, "JobStarting", _JobStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobEnding", _JobEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SuffixStarting", _SuffixStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SuffixEnding", _SuffixEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintItemDesc", _PrintItemDesc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintBetweenLevel", _PrintBetweenLevel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintRefFields", _PrintRefFields, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
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
