//PROJECT NAME: Reporting
//CLASS NAME: Rpt_LotTraceability.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_LotTraceability : IRpt_LotTraceability
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_LotTraceability(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_LotTraceabilitySp(string PStartingItem = null,
		string PEndingItem = null,
		string PStartingLot = null,
		string PEndingLot = null,
		string PSummaryDetail = "D",
		string PSortBy = "L",
		int? PDisplayHeader = 1,
		string PMessageLanguage = null,
		string pSite = null)
		{
			ItemType _PStartingItem = PStartingItem;
			ItemType _PEndingItem = PEndingItem;
			LotType _PStartingLot = PStartingLot;
			LotType _PEndingLot = PEndingLot;
			Infobar _PSummaryDetail = PSummaryDetail;
			Infobar _PSortBy = PSortBy;
			ListYesNoType _PDisplayHeader = PDisplayHeader;
			MessageLanguageType _PMessageLanguage = PMessageLanguage;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_LotTraceabilitySp";
				
				appDB.AddCommandParameter(cmd, "PStartingItem", _PStartingItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingItem", _PEndingItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingLot", _PStartingLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingLot", _PEndingLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSummaryDetail", _PSummaryDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSortBy", _PSortBy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDisplayHeader", _PDisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PMessageLanguage", _PMessageLanguage, ParameterDirection.Input);
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
