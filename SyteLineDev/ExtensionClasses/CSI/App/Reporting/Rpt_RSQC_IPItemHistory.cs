//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RSQC_IPItemHistory.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_RSQC_IPItemHistory : IRpt_RSQC_IPItemHistory
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_RSQC_IPItemHistory(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_RSQC_IPItemHistorySp(
			string begjob = null,
			string endjob = null,
			int? begsuffix = null,
			int? endsuffix = null,
			string begpsnum = null,
			string endpsnum = null,
			DateTime? begtdate = null,
			DateTime? endtdate = null,
			int? PageBetweenItems = null,
			int? DisplayHeader = null)
		{
			JobType _begjob = begjob;
			JobType _endjob = endjob;
			SuffixType _begsuffix = begsuffix;
			SuffixType _endsuffix = endsuffix;
			PsNumType _begpsnum = begpsnum;
			PsNumType _endpsnum = endpsnum;
			DateType _begtdate = begtdate;
			DateType _endtdate = endtdate;
			ListYesNoType _PageBetweenItems = PageBetweenItems;
			ListYesNoType _DisplayHeader = DisplayHeader;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_RSQC_IPItemHistorySp";
				
				appDB.AddCommandParameter(cmd, "begjob", _begjob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "endjob", _endjob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "begsuffix", _begsuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "endsuffix", _endsuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "begpsnum", _begpsnum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "endpsnum", _endpsnum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "begtdate", _begtdate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "endtdate", _endtdate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PageBetweenItems", _PageBetweenItems, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
