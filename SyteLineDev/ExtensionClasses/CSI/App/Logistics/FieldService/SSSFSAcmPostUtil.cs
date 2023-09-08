//PROJECT NAME: Logistics
//CLASS NAME: SSSFSAcmPostUtil.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSAcmPostUtil
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSFSAcmPostUtilSp(byte? Commit,
		string StartCustNum,
		string EndCustNum,
		string StartRefNum,
		string EndRefNum,
		string StartInvNum,
		string EndInvNum,
		string StartAmortAcct,
		string EndAmortAcct,
		string StartOffsetAcct,
		string EndOffsetAcct,
		byte? Period,
		short? FiscalYear,
		DateTime? PostDate,
		byte? UpdateStatus,
		byte? PostAllPeriods = (byte)0,
		string FilterString = null);
	}
	
	public class SSSFSAcmPostUtil : ISSSFSAcmPostUtil
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public SSSFSAcmPostUtil(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) SSSFSAcmPostUtilSp(byte? Commit,
		string StartCustNum,
		string EndCustNum,
		string StartRefNum,
		string EndRefNum,
		string StartInvNum,
		string EndInvNum,
		string StartAmortAcct,
		string EndAmortAcct,
		string StartOffsetAcct,
		string EndOffsetAcct,
		byte? Period,
		short? FiscalYear,
		DateTime? PostDate,
		byte? UpdateStatus,
		byte? PostAllPeriods = (byte)0,
		string FilterString = null)
		{
			bunchedLoadCollection.StartBunching();
			
			try
			{
				ListYesNoType _Commit = Commit;
				CustNumType _StartCustNum = StartCustNum;
				CustNumType _EndCustNum = EndCustNum;
				FSRefNumType _StartRefNum = StartRefNum;
				FSRefNumType _EndRefNum = EndRefNum;
				InvNumType _StartInvNum = StartInvNum;
				InvNumType _EndInvNum = EndInvNum;
				AcctType _StartAmortAcct = StartAmortAcct;
				AcctType _EndAmortAcct = EndAmortAcct;
				AcctType _StartOffsetAcct = StartOffsetAcct;
				AcctType _EndOffsetAcct = EndOffsetAcct;
				FinPeriodType _Period = Period;
				FiscalYearType _FiscalYear = FiscalYear;
				DateType _PostDate = PostDate;
				ListYesNoType _UpdateStatus = UpdateStatus;
				ListYesNoType _PostAllPeriods = PostAllPeriods;
				LongListType _FilterString = FilterString;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "SSSFSAcmPostUtilSp";
					
					appDB.AddCommandParameter(cmd, "Commit", _Commit, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "StartCustNum", _StartCustNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "EndCustNum", _EndCustNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "StartRefNum", _StartRefNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "EndRefNum", _EndRefNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "StartInvNum", _StartInvNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "EndInvNum", _EndInvNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "StartAmortAcct", _StartAmortAcct, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "EndAmortAcct", _EndAmortAcct, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "StartOffsetAcct", _StartOffsetAcct, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "EndOffsetAcct", _EndOffsetAcct, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Period", _Period, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "FiscalYear", _FiscalYear, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PostDate", _PostDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "UpdateStatus", _UpdateStatus, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PostAllPeriods", _PostAllPeriods, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "FilterString", _FilterString, ParameterDirection.Input);
					
					IntType returnVal = 0;
					IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
					dbParm.DbType = DbType.Int32;

                    dtReturn = appDB.ExecuteQuery(cmd);

                    return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
				}
			}
			finally
			{
				bunchedLoadCollection.EndBunching();
			}
		}
	}
}
