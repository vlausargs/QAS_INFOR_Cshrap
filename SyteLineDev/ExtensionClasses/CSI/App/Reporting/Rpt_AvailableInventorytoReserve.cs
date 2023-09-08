//PROJECT NAME: Reporting
//CLASS NAME: Rpt_AvailableInventorytoReserve.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_AvailableInventorytoReserve : IRpt_AvailableInventorytoReserve
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_AvailableInventorytoReserve(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_AvailableInventorytoReserveSp(string WhseStarting = null,
		string WhseEnding = null,
		string ItemStarting = null,
		string ItemEnding = null,
		string pSite = null,
		int? IncludeSerialNumber = null)
		{
			WhseType _WhseStarting = WhseStarting;
			WhseType _WhseEnding = WhseEnding;
			ItemType _ItemStarting = ItemStarting;
			ItemType _ItemEnding = ItemEnding;
			SiteType _pSite = pSite;
			FlagNyType _IncludeSerialNumber = IncludeSerialNumber;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_AvailableInventorytoReserveSp";
				
				appDB.AddCommandParameter(cmd, "WhseStarting", _WhseStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WhseEnding", _WhseEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemStarting", _ItemStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemEnding", _ItemEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludeSerialNumber", _IncludeSerialNumber, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
