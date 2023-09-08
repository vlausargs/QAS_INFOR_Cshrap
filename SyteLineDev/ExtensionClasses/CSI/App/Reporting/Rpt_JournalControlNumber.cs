//PROJECT NAME: Reporting
//CLASS NAME: Rpt_JournalControlNumber.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_JournalControlNumber : IRpt_JournalControlNumber
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_JournalControlNumber(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_JournalControlNumberSp(string CurId = null,
		string Type = null,
		int? ShowForeignAmounts = null,
		string PrefixStarting = null,
		string PrefixEnding = null,
		string SiteStarting = null,
		string SiteEnding = null,
		int? YearStarting = null,
		int? YearEnding = null,
		int? PeriodStarting = null,
		int? PeriodEnding = null,
		decimal? ControlNumberStarting = null,
		decimal? ControlNumberEnding = null,
		int? DisplayHeader = null,
		string pSite = null)
		{
			JournalIdType _CurId = CurId;
			StringType _Type = Type;
			FlagNyType _ShowForeignAmounts = ShowForeignAmounts;
			JourControlPrefixType _PrefixStarting = PrefixStarting;
			JourControlPrefixType _PrefixEnding = PrefixEnding;
			SiteType _SiteStarting = SiteStarting;
			SiteType _SiteEnding = SiteEnding;
			FiscalYearType _YearStarting = YearStarting;
			FiscalYearType _YearEnding = YearEnding;
			FinPeriodType _PeriodStarting = PeriodStarting;
			FinPeriodType _PeriodEnding = PeriodEnding;
			LastTranType _ControlNumberStarting = ControlNumberStarting;
			LastTranType _ControlNumberEnding = ControlNumberEnding;
			FlagNyType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_JournalControlNumberSp";
				
				appDB.AddCommandParameter(cmd, "CurId", _CurId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Type", _Type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowForeignAmounts", _ShowForeignAmounts, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrefixStarting", _PrefixStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrefixEnding", _PrefixEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SiteStarting", _SiteStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SiteEnding", _SiteEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "YearStarting", _YearStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "YearEnding", _YearEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PeriodStarting", _PeriodStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PeriodEnding", _PeriodEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlNumberStarting", _ControlNumberStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlNumberEnding", _ControlNumberEnding, ParameterDirection.Input);
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
