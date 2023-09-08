//PROJECT NAME: CSIChineseFinancials
//CLASS NAME: CHSCLM_LoadLedgerEntries.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.Chinese
{
	public interface ICHSCLM_LoadLedgerEntries
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CHSCLM_LoadLedgerEntriesSp(DateTime? StartDate = null,
		DateTime? EndDate = null,
		string AcctFrom = null,
		string Unit1From = null,
		string Unit2From = null,
		string Unit3From = null,
		string Unit4From = null,
		string AcctTo = null,
		string Unit1To = null,
		string Unit2To = null,
		string Unit3To = null,
		string Unit4To = null);
	}
	
	public class CHSCLM_LoadLedgerEntries : ICHSCLM_LoadLedgerEntries
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CHSCLM_LoadLedgerEntries(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CHSCLM_LoadLedgerEntriesSp(DateTime? StartDate = null,
		DateTime? EndDate = null,
		string AcctFrom = null,
		string Unit1From = null,
		string Unit2From = null,
		string Unit3From = null,
		string Unit4From = null,
		string AcctTo = null,
		string Unit1To = null,
		string Unit2To = null,
		string Unit3To = null,
		string Unit4To = null)
		{
			bunchedLoadCollection.StartBunching();
			
			try
			{
				DateType _StartDate = StartDate;
				DateType _EndDate = EndDate;
				AcctType _AcctFrom = AcctFrom;
				UnitCode1Type _Unit1From = Unit1From;
				UnitCode2Type _Unit2From = Unit2From;
				UnitCode3Type _Unit3From = Unit3From;
				UnitCode4Type _Unit4From = Unit4From;
				AcctType _AcctTo = AcctTo;
				UnitCode1Type _Unit1To = Unit1To;
				UnitCode2Type _Unit2To = Unit2To;
				UnitCode3Type _Unit3To = Unit3To;
				UnitCode4Type _Unit4To = Unit4To;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "CHSCLM_LoadLedgerEntriesSp";
					
					appDB.AddCommandParameter(cmd, "StartDate", _StartDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "EndDate", _EndDate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "AcctFrom", _AcctFrom, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Unit1From", _Unit1From, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Unit2From", _Unit2From, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Unit3From", _Unit3From, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Unit4From", _Unit4From, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "AcctTo", _AcctTo, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Unit1To", _Unit1To, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Unit2To", _Unit2To, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Unit3To", _Unit3To, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Unit4To", _Unit4To, ParameterDirection.Input);
					
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
