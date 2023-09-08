//PROJECT NAME: Reporting
//CLASS NAME: Rpt_COTransactionsByLot.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_COTransactionsByLot
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_COTransactionsByLotSp(string ItemStarting = null,
		string ItemEnding = null,
		string LotStarting = null,
		string LotEnding = null,
		byte? ExOptszSortItemLot = null,
		byte? DisplayHeader = null,
		string BGSessionId = null,
		string pSite = null);
	}
	
	public class Rpt_COTransactionsByLot : IRpt_COTransactionsByLot
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_COTransactionsByLot(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_COTransactionsByLotSp(string ItemStarting = null,
		string ItemEnding = null,
		string LotStarting = null,
		string LotEnding = null,
		byte? ExOptszSortItemLot = null,
		byte? DisplayHeader = null,
		string BGSessionId = null,
		string pSite = null)
		{
			ItemType _ItemStarting = ItemStarting;
			ItemType _ItemEnding = ItemEnding;
			LotType _LotStarting = LotStarting;
			LotType _LotEnding = LotEnding;
			ListYesNoType _ExOptszSortItemLot = ExOptszSortItemLot;
			ListYesNoType _DisplayHeader = DisplayHeader;
			StringType _BGSessionId = BGSessionId;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_COTransactionsByLotSp";
				
				appDB.AddCommandParameter(cmd, "ItemStarting", _ItemStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemEnding", _ItemEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LotStarting", _LotStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LotEnding", _LotEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptszSortItemLot", _ExOptszSortItemLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
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
