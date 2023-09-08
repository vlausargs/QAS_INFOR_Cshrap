//PROJECT NAME: Reporting
//CLASS NAME: SSSFSRpt_PartReimb.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class SSSFSRpt_PartReimb : ISSSFSRpt_PartReimb
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public SSSFSRpt_PartReimb(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) SSSFSRpt_PartReimbSp(string _iPartnerStart,
		string _iPartnerEnd,
		string _iSroNumStart,
		string _iSroNumEnd,
		DateTime? _iTransDateStart,
		DateTime? _iTransDateEnd,
		int? _iTransDateStart_OffSET = null,
		int? _iTransDateEnd_OffSET = null,
		string _iReimbStat = null,
		string _iBatchNum = null,
		string _iReimbMethod = null,
		string pSite = null)
		{
			FSPartnerType __iPartnerStart = _iPartnerStart;
			FSPartnerType __iPartnerEnd = _iPartnerEnd;
			FSSRONumType __iSroNumStart = _iSroNumStart;
			FSSRONumType __iSroNumEnd = _iSroNumEnd;
			DateType __iTransDateStart = _iTransDateStart;
			DateType __iTransDateEnd = _iTransDateEnd;
			DateOffsetType __iTransDateStart_OffSET = _iTransDateStart_OffSET;
			DateOffsetType __iTransDateEnd_OffSET = _iTransDateEnd_OffSET;
			StringType __iReimbStat = _iReimbStat;
			FSReimbBatchIdType __iBatchNum = _iBatchNum;
			StringType __iReimbMethod = _iReimbMethod;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSRpt_PartReimbSp";
				
				appDB.AddCommandParameter(cmd, "_iPartnerStart", __iPartnerStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "_iPartnerEnd", __iPartnerEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "_iSroNumStart", __iSroNumStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "_iSroNumEnd", __iSroNumEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "_iTransDateStart", __iTransDateStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "_iTransDateEnd", __iTransDateEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "_iTransDateStart_OffSET", __iTransDateStart_OffSET, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "_iTransDateEnd_OffSET", __iTransDateEnd_OffSET, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "_iReimbStat", __iReimbStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "_iBatchNum", __iBatchNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "_iReimbMethod", __iReimbMethod, ParameterDirection.Input);
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
