//PROJECT NAME: Reporting
//CLASS NAME: Rpt_EstimatesByProfit.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_EstimatesByProfit
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_EstimatesByProfitSp(string EstimateStatus = "WQPH",
		byte? PrintCost = (byte)1,
		string OrderStarting = null,
		string OrderEnding = null,
		string CustomerStarting = null,
		string CustomerEnding = null,
		DateTime? QuoteDateStarting = null,
		DateTime? QuoteDateEnding = null,
		short? QuoteDateStartingOffset = null,
		short? QuoteDateEndingOffset = null,
		DateTime? ExpireDateStarting = null,
		DateTime? ExpireDateEnding = null,
		short? ExpireDateStartingOffset = null,
		short? ExpireDateEndingOffset = null,
		byte? CoShowInternal = (byte)1,
		byte? CoShowExternal = (byte)1,
		byte? DisplayHeader = (byte)1,
		string StartProspect = null,
		string EndProspect = null,
		string pSite = null);
	}
	
	public class Rpt_EstimatesByProfit : IRpt_EstimatesByProfit
	{
		IApplicationDB appDB;
		IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_EstimatesByProfit(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_EstimatesByProfitSp(string EstimateStatus = "WQPH",
		byte? PrintCost = (byte)1,
		string OrderStarting = null,
		string OrderEnding = null,
		string CustomerStarting = null,
		string CustomerEnding = null,
		DateTime? QuoteDateStarting = null,
		DateTime? QuoteDateEnding = null,
		short? QuoteDateStartingOffset = null,
		short? QuoteDateEndingOffset = null,
		DateTime? ExpireDateStarting = null,
		DateTime? ExpireDateEnding = null,
		short? ExpireDateStartingOffset = null,
		short? ExpireDateEndingOffset = null,
		byte? CoShowInternal = (byte)1,
		byte? CoShowExternal = (byte)1,
		byte? DisplayHeader = (byte)1,
		string StartProspect = null,
		string EndProspect = null,
		string pSite = null)
		{
			StringType _EstimateStatus = EstimateStatus;
			ListYesNoType _PrintCost = PrintCost;
			CoNumType _OrderStarting = OrderStarting;
			CoNumType _OrderEnding = OrderEnding;
			CustNumType _CustomerStarting = CustomerStarting;
			CustNumType _CustomerEnding = CustomerEnding;
			GenericDateType _QuoteDateStarting = QuoteDateStarting;
			GenericDateType _QuoteDateEnding = QuoteDateEnding;
			DateOffsetType _QuoteDateStartingOffset = QuoteDateStartingOffset;
			DateOffsetType _QuoteDateEndingOffset = QuoteDateEndingOffset;
			GenericDateType _ExpireDateStarting = ExpireDateStarting;
			GenericDateType _ExpireDateEnding = ExpireDateEnding;
			DateOffsetType _ExpireDateStartingOffset = ExpireDateStartingOffset;
			DateOffsetType _ExpireDateEndingOffset = ExpireDateEndingOffset;
			FlagNyType _CoShowInternal = CoShowInternal;
			FlagNyType _CoShowExternal = CoShowExternal;
			ListYesNoType _DisplayHeader = DisplayHeader;
			ProspectIDType _StartProspect = StartProspect;
			ProspectIDType _EndProspect = EndProspect;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_EstimatesByProfitSp";
				
				appDB.AddCommandParameter(cmd, "EstimateStatus", _EstimateStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintCost", _PrintCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderStarting", _OrderStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderEnding", _OrderEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerStarting", _CustomerStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerEnding", _CustomerEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QuoteDateStarting", _QuoteDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QuoteDateEnding", _QuoteDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QuoteDateStartingOffset", _QuoteDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QuoteDateEndingOffset", _QuoteDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExpireDateStarting", _ExpireDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExpireDateEnding", _ExpireDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExpireDateStartingOffset", _ExpireDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExpireDateEndingOffset", _ExpireDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoShowInternal", _CoShowInternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoShowExternal", _CoShowExternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartProspect", _StartProspect, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndProspect", _EndProspect, ParameterDirection.Input);
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
