//PROJECT NAME: Reporting
//CLASS NAME: Rpt_BarcodedItemLabels.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_BarcodedItemLabels
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_BarcodedItemLabelsSp(int? LabelSets = 2,
		byte? DisplayLot = (byte)0,
		string WarehouseStarting = null,
		string WarehouseEnding = null,
		string ItemStarting = null,
		string ItemEnding = null,
		string LotStarting = null,
		string LotEnding = null,
		string pSite = null);
	}
	
	public class Rpt_BarcodedItemLabels : IRpt_BarcodedItemLabels
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_BarcodedItemLabels(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_BarcodedItemLabelsSp(int? LabelSets = 2,
		byte? DisplayLot = (byte)0,
		string WarehouseStarting = null,
		string WarehouseEnding = null,
		string ItemStarting = null,
		string ItemEnding = null,
		string LotStarting = null,
		string LotEnding = null,
		string pSite = null)
		{
			IntType _LabelSets = LabelSets;
			ListYesNoType _DisplayLot = DisplayLot;
			WhseType _WarehouseStarting = WarehouseStarting;
			WhseType _WarehouseEnding = WarehouseEnding;
			ItemType _ItemStarting = ItemStarting;
			ItemType _ItemEnding = ItemEnding;
			LotType _LotStarting = LotStarting;
			LotType _LotEnding = LotEnding;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_BarcodedItemLabelsSp";
				
				appDB.AddCommandParameter(cmd, "LabelSets", _LabelSets, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayLot", _DisplayLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WarehouseStarting", _WarehouseStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WarehouseEnding", _WarehouseEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemStarting", _ItemStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemEnding", _ItemEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LotStarting", _LotStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LotEnding", _LotEnding, ParameterDirection.Input);
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
