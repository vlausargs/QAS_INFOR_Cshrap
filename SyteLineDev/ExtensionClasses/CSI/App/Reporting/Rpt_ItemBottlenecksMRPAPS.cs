//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ItemBottlenecksMRPAPS.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_ItemBottlenecksMRPAPS : IRpt_ItemBottlenecksMRPAPS
	{
		IApplicationDB appDB;
		IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ItemBottlenecksMRPAPS(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ItemBottlenecksMRPAPSSp(string SourceType = null,
		int? ListDelayedDemands = null,
		string PlannerCodeStarting = null,
		string PlannerCodeEnding = null,
		string ItemStarting = null,
		string ItemEnding = null,
		int? DisplayHeader = null,
		int? ALTNO = null,
		string pSite = null,
		DateTime? StartDate = null,
		DateTime? EndDate = null,
		string BuyerStart = null,
		string BuyerEnd = null)
		{
			InfobarType _SourceType = SourceType;
			ListYesNoType _ListDelayedDemands = ListDelayedDemands;
			UserCodeType _PlannerCodeStarting = PlannerCodeStarting;
			UserCodeType _PlannerCodeEnding = PlannerCodeEnding;
			ItemType _ItemStarting = ItemStarting;
			ItemType _ItemEnding = ItemEnding;
			FlagNyType _DisplayHeader = DisplayHeader;
			ApsAltNoType _ALTNO = ALTNO;
			SiteType _pSite = pSite;
			DateType _StartDate = StartDate;
			DateType _EndDate = EndDate;
			NameType _BuyerStart = BuyerStart;
			NameType _BuyerEnd = BuyerEnd;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ItemBottlenecksMRPAPSSp";
				
				appDB.AddCommandParameter(cmd, "SourceType", _SourceType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ListDelayedDemands", _ListDelayedDemands, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PlannerCodeStarting", _PlannerCodeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PlannerCodeEnding", _PlannerCodeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemStarting", _ItemStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemEnding", _ItemEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ALTNO", _ALTNO, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDate", _StartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDate", _EndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BuyerStart", _BuyerStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BuyerEnd", _BuyerEnd, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
