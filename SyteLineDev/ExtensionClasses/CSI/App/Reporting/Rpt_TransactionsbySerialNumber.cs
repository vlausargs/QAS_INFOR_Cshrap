//PROJECT NAME: Reporting
//CLASS NAME: Rpt_TransactionsbySerialNumber.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_TransactionsbySerialNumber : IRpt_TransactionsbySerialNumber
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_TransactionsbySerialNumber(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_TransactionsbySerialNumberSp(string BegSerNum = null,
		string EndSerNum = null,
		string BegItem = null,
		string EndItem = null,
		string BegLot = null,
		string EndLot = null,
		int? DisplayHeader = null,
		string MessageLanguage = null,
		string BGSessionId = null,
		string pSite = null)
		{
			SerNumType _BegSerNum = BegSerNum;
			SerNumType _EndSerNum = EndSerNum;
			ItemType _BegItem = BegItem;
			ItemType _EndItem = EndItem;
			LotType _BegLot = BegLot;
			LotType _EndLot = EndLot;
			ListYesNoType _DisplayHeader = DisplayHeader;
			MessageLanguageType _MessageLanguage = MessageLanguage;
			StringType _BGSessionId = BGSessionId;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_TransactionsbySerialNumberSp";
				
				appDB.AddCommandParameter(cmd, "BegSerNum", _BegSerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndSerNum", _EndSerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegItem", _BegItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndItem", _EndItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegLot", _BegLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndLot", _EndLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MessageLanguage", _MessageLanguage, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGSessionId", _BGSessionId, ParameterDirection.Input);
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
