//PROJECT NAME: Reporting
//CLASS NAME: CHSRpt_OutputLedger.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class CHSRpt_OutputLedger : ICHSRpt_OutputLedger
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CHSRpt_OutputLedger(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CHSRpt_OutputLedgerSp(DateTime? BegTransDate = null,
		DateTime? EndTransDate = null,
		decimal? BegTransNum = null,
		decimal? EndTransNum = null,
		string JournalId = null,
		string pSite = null)
		{
			DateType _BegTransDate = BegTransDate;
			DateType _EndTransDate = EndTransDate;
			MatlTransNumType _BegTransNum = BegTransNum;
			MatlTransNumType _EndTransNum = EndTransNum;
			JournalIdType _JournalId = JournalId;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CHSRpt_OutputLedgerSp";
				
				appDB.AddCommandParameter(cmd, "BegTransDate", _BegTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndTransDate", _EndTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegTransNum", _BegTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndTransNum", _EndTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JournalId", _JournalId, ParameterDirection.Input);
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
