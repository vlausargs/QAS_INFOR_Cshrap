//PROJECT NAME: Reporting
//CLASS NAME: Rpt_OrderShippedCost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_OrderShippedCost : IRpt_OrderShippedCost
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_OrderShippedCost(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_OrderShippedCostSp(int? TranslateToDomestic = 0,
		string OrderStarting = null,
		string OrderEnding = null,
		string CustomerStarting = null,
		string CustomerEnding = null,
		string ItemStarting = null,
		string ItemEnding = null,
		DateTime? DateShippedStarting = null,
		DateTime? DateShippedEnding = null,
		int? DateShippedStartingOffset = null,
		int? DateShippedEndingOffset = null,
		int? DisplayReportHeader = 1,
		string pSite = null)
		{
			ByteType _TranslateToDomestic = TranslateToDomestic;
			HighLowCharType _OrderStarting = OrderStarting;
			HighLowCharType _OrderEnding = OrderEnding;
			HighLowCharType _CustomerStarting = CustomerStarting;
			HighLowCharType _CustomerEnding = CustomerEnding;
			HighLowCharType _ItemStarting = ItemStarting;
			HighLowCharType _ItemEnding = ItemEnding;
			CurrentDateType _DateShippedStarting = DateShippedStarting;
			CurrentDateType _DateShippedEnding = DateShippedEnding;
			DateOffsetType _DateShippedStartingOffset = DateShippedStartingOffset;
			DateOffsetType _DateShippedEndingOffset = DateShippedEndingOffset;
			ListYesNoType _DisplayReportHeader = DisplayReportHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_OrderShippedCostSp";
				
				appDB.AddCommandParameter(cmd, "TranslateToDomestic", _TranslateToDomestic, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderStarting", _OrderStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderEnding", _OrderEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerStarting", _CustomerStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerEnding", _CustomerEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemStarting", _ItemStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemEnding", _ItemEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateShippedStarting", _DateShippedStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateShippedEnding", _DateShippedEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateShippedStartingOffset", _DateShippedStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateShippedEndingOffset", _DateShippedEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayReportHeader", _DisplayReportHeader, ParameterDirection.Input);
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
