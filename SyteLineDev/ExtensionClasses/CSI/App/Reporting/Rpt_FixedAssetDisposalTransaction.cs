//PROJECT NAME: Reporting
//CLASS NAME: Rpt_FixedAssetDisposalTransaction.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_FixedAssetDisposalTransaction
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_FixedAssetDisposalTransactionSp(DateTime? StartingDisposeDate = null,
		DateTime? EndingDisposeDate = null,
		short? StartingDisposeDateOffset = null,
		short? EndingDisposeDateOffset = null,
		string StartingFanum = null,
		string EndingFanum = null,
		byte? DisplayHeader = null,
		string pSite = null);
	}
	
	public class Rpt_FixedAssetDisposalTransaction : IRpt_FixedAssetDisposalTransaction
	{
		IApplicationDB appDB;
		IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_FixedAssetDisposalTransaction(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_FixedAssetDisposalTransactionSp(DateTime? StartingDisposeDate = null,
		DateTime? EndingDisposeDate = null,
		short? StartingDisposeDateOffset = null,
		short? EndingDisposeDateOffset = null,
		string StartingFanum = null,
		string EndingFanum = null,
		byte? DisplayHeader = null,
		string pSite = null)
		{
			DateType _StartingDisposeDate = StartingDisposeDate;
			DateType _EndingDisposeDate = EndingDisposeDate;
			DateOffsetType _StartingDisposeDateOffset = StartingDisposeDateOffset;
			DateOffsetType _EndingDisposeDateOffset = EndingDisposeDateOffset;
			FaNumType _StartingFanum = StartingFanum;
			FaNumType _EndingFanum = EndingFanum;
			FlagNyType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_FixedAssetDisposalTransactionSp";
				
				appDB.AddCommandParameter(cmd, "StartingDisposeDate", _StartingDisposeDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingDisposeDate", _EndingDisposeDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingDisposeDateOffset", _StartingDisposeDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingDisposeDateOffset", _EndingDisposeDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingFanum", _StartingFanum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingFanum", _EndingFanum, ParameterDirection.Input);
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
