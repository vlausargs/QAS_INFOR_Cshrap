//PROJECT NAME: Reporting
//CLASS NAME: Rpt_OrderBookingsSub.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_OrderBookingsSub : IRpt_OrderBookingsSub
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_OrderBookingsSub(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode,
			string Infobar) Rpt_OrderBookingsSubSp(
			string Sortby,
			DateTime? ActivityDateStarting,
			DateTime? ActivityDateEnding,
			string ProductCodeStarting,
			string ProductCodeEnding,
			string SlsmanStarting,
			string SlsmanEnding,
			string ItemStarting,
			string ItemEnding,
			string OrdernumStarting,
			string OrdernumEnding,
			string RmaNumStarting,
			string RmaNumEnding,
			int? IncludeRma,
			int? SummaryorDetail,
			int? CheckCoForRMA = null,
			string Site = null,
			string Infobar = null)
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
			ListYesNoType _CheckCoForRMA = CheckCoForRMA;
			SiteType _Site = Site;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_OrderBookingsSubSp";
				
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
				appDB.AddCommandParameter(cmd, "CheckCoForRMA", _CheckCoForRMA, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				Infobar = _Infobar;
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value, Infobar);
			}
		}
	}
}
