//PROJECT NAME: Logistics
//CLASS NAME: SSSFSAutoSROGen.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSAutoSROGen : ISSSFSAutoSROGen
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public SSSFSAutoSROGen(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) SSSFSAutoSROGenSp(int? iCreateSROs,
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
		string pSite = null)
		{
			if(bunchedLoadCollection != null)
			bunchedLoadCollection.StartBunching();
			
			try
			{
				ListYesNoType _iCreateSROs = iCreateSROs;
				DateTimeType _iThroughDate = iThroughDate;
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
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "SSSFSAutoSROGenSp";
					
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
					
					IntType returnVal = 0;
					IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
					dbParm.DbType = DbType.Int32;
					
					dtReturn = appDB.ExecuteQuery(cmd);
					
					return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
				}
			}
			finally
			{
				if(bunchedLoadCollection != null)
				bunchedLoadCollection.EndBunching();
			}
		}
	}
}
