//PROJECT NAME: Reporting
//CLASS NAME: Rpt_OrderBookings.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_OrderBookings : IRpt_OrderBookings
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_OrderBookings(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_OrderBookingsSp(string Sortby = null,
		DateTime? ActivityDateStarting = null,
		DateTime? ActivityDateEnding = null,
		string ProductCodeStarting = null,
		string ProductCodeEnding = null,
		string SlsmanStarting = null,
		string SlsmanEnding = null,
		string ItemStarting = null,
		string ItemEnding = null,
		string OrdernumStarting = null,
		string OrdernumEnding = null,
		string RmaNumStarting = null,
		string RmaNumEnding = null,
		int? IncludeRma = null,
		int? SummaryorDetail = null,
		int? ActivityDateStartingOffset = null,
		int? ActivityDateEndingOffset = null,
		int? DisplayHeader = null,
		string pSite = null)
		{
			StringType _Sortby = Sortby;
			DateType _ActivityDateStarting = ActivityDateStarting;
			DateType _ActivityDateEnding = ActivityDateEnding;
			ProductCodeType _ProductCodeStarting = ProductCodeStarting;
			ProductCodeType _ProductCodeEnding = ProductCodeEnding;
			SlsmanType _SlsmanStarting = SlsmanStarting;
			SlsmanType _SlsmanEnding = SlsmanEnding;
			ItemType _ItemStarting = ItemStarting;
			ItemType _ItemEnding = ItemEnding;
			CoNumType _OrdernumStarting = OrdernumStarting;
			CoNumType _OrdernumEnding = OrdernumEnding;
			RmaNumType _RmaNumStarting = RmaNumStarting;
			RmaNumType _RmaNumEnding = RmaNumEnding;
			ListYesNoType _IncludeRma = IncludeRma;
			ListYesNoType _SummaryorDetail = SummaryorDetail;
			DateOffsetType _ActivityDateStartingOffset = ActivityDateStartingOffset;
			DateOffsetType _ActivityDateEndingOffset = ActivityDateEndingOffset;
			FlagNyType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_OrderBookingsSp";
				
				appDB.AddCommandParameter(cmd, "Sortby", _Sortby, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ActivityDateStarting", _ActivityDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ActivityDateEnding", _ActivityDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProductCodeStarting", _ProductCodeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProductCodeEnding", _ProductCodeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SlsmanStarting", _SlsmanStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SlsmanEnding", _SlsmanEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemStarting", _ItemStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemEnding", _ItemEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrdernumStarting", _OrdernumStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrdernumEnding", _OrdernumEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RmaNumStarting", _RmaNumStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RmaNumEnding", _RmaNumEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludeRma", _IncludeRma, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SummaryorDetail", _SummaryorDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ActivityDateStartingOffset", _ActivityDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ActivityDateEndingOffset", _ActivityDateEndingOffset, ParameterDirection.Input);
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
