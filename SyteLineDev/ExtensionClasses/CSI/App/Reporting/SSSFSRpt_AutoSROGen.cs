//PROJECT NAME: Reporting
//CLASS NAME: SSSFSRpt_AutoSROGen.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class SSSFSRpt_AutoSROGen : ISSSFSRpt_AutoSROGen
	{
		IApplicationDB appDB;
		IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public SSSFSRpt_AutoSROGen(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) SSSFSRpt_AutoSROGenSp(int? iCreateSROs,
		DateTime? iThroughDate,
		string iStartSerNum,
		string iEndSerNum,
		string iStartSroType,
		string iEndSroType,
		string iStartDept,
		string iEndDept,
		string iStartWc,
		string iEndWc,
		int? iKeepOperNums,
		int? iDateOffset,
		string pSite = null,
		decimal? UserID = null)
		{
			ListYesNoType _iCreateSROs = iCreateSROs;
			DateType _iThroughDate = iThroughDate;
			SerNumType _iStartSerNum = iStartSerNum;
			SerNumType _iEndSerNum = iEndSerNum;
			FSSROTypeType _iStartSroType = iStartSroType;
			FSSROTypeType _iEndSroType = iEndSroType;
			DeptType _iStartDept = iStartDept;
			DeptType _iEndDept = iEndDept;
			WcType _iStartWc = iStartWc;
			WcType _iEndWc = iEndWc;
			ListYesNoType _iKeepOperNums = iKeepOperNums;
			IntType _iDateOffset = iDateOffset;
			SiteType _pSite = pSite;
			TokenType _UserID = UserID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSRpt_AutoSROGenSp";
				
				appDB.AddCommandParameter(cmd, "iCreateSROs", _iCreateSROs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iThroughDate", _iThroughDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iStartSerNum", _iStartSerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iEndSerNum", _iEndSerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iStartSroType", _iStartSroType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iEndSroType", _iEndSroType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iStartDept", _iStartDept, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iEndDept", _iEndDept, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iStartWc", _iStartWc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iEndWc", _iEndWc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iKeepOperNums", _iKeepOperNums, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iDateOffset", _iDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UserID", _UserID, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
