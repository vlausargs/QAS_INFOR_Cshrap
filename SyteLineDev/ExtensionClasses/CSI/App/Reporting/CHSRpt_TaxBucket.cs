//PROJECT NAME: CSIReport
//CLASS NAME: CHSRpt_TaxBucket.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface ICHSRpt_TaxBucket
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CHSRpt_TaxBucketSp(decimal? BookKey,
		string BookType,
		string BeginAccount,
		string EndAccount,
		string BegUnit1,
		string EndUnit1,
		string BegUnit2,
		string EndUnit2,
		string BegUnit3,
		string EndUnit3,
		string BegUnit4,
		string EndUnit4,
		DateTime? BeginDate,
		DateTime? EndDate,
		byte? PrintDayTotal,
		byte? IncludeZeroBalAccount,
		short? RptLines,
		byte? BalColIsLast,
		string pSite = null);
	}
	
	public class CHSRpt_TaxBucket : ICHSRpt_TaxBucket
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CHSRpt_TaxBucket(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CHSRpt_TaxBucketSp(decimal? BookKey,
		string BookType,
		string BeginAccount,
		string EndAccount,
		string BegUnit1,
		string EndUnit1,
		string BegUnit2,
		string EndUnit2,
		string BegUnit3,
		string EndUnit3,
		string BegUnit4,
		string EndUnit4,
		DateTime? BeginDate,
		DateTime? EndDate,
		byte? PrintDayTotal,
		byte? IncludeZeroBalAccount,
		short? RptLines,
		byte? BalColIsLast,
		string pSite = null)
		{
			SequenceType _BookKey = BookKey;
			RfDefaultType _BookType = BookType;
			AcctType _BeginAccount = BeginAccount;
			AcctType _EndAccount = EndAccount;
			UnitCode1Type _BegUnit1 = BegUnit1;
			UnitCode1Type _EndUnit1 = EndUnit1;
			UnitCode2Type _BegUnit2 = BegUnit2;
			UnitCode2Type _EndUnit2 = EndUnit2;
			UnitCode3Type _BegUnit3 = BegUnit3;
			UnitCode3Type _EndUnit3 = EndUnit3;
			UnitCode4Type _BegUnit4 = BegUnit4;
			UnitCode4Type _EndUnit4 = EndUnit4;
			DateType _BeginDate = BeginDate;
			DateType _EndDate = EndDate;
			ListYesNoType _PrintDayTotal = PrintDayTotal;
			ListYesNoType _IncludeZeroBalAccount = IncludeZeroBalAccount;
			FormPositionType _RptLines = RptLines;
			ListYesNoType _BalColIsLast = BalColIsLast;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CHSRpt_TaxBucketSp";
				
				appDB.AddCommandParameter(cmd, "BookKey", _BookKey, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BookType", _BookType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BeginAccount", _BeginAccount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndAccount", _EndAccount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegUnit1", _BegUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndUnit1", _EndUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegUnit2", _BegUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndUnit2", _EndUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegUnit3", _BegUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndUnit3", _EndUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegUnit4", _BegUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndUnit4", _EndUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BeginDate", _BeginDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDate", _EndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintDayTotal", _PrintDayTotal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludeZeroBalAccount", _IncludeZeroBalAccount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RptLines", _RptLines, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BalColIsLast", _BalColIsLast, ParameterDirection.Input);
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
