//PROJECT NAME: Reporting
//CLASS NAME: RPT_OrderCost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class RPT_OrderCost : IRPT_OrderCost
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public RPT_OrderCost(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) RPT_OrderCostSP(string ExOptacCoStat07 = null,
		int? ExMiscPrintLine = null,
		int? ExOptszShowDetail = null,
		string Begconum = null,
		string Endconum = null,
		int? Begcoline = null,
		int? Endcoline = null,
		int? Begcorelease = null,
		int? Endcorelease = null,
		string Begcustnum = null,
		string Endcustnum = null,
		DateTime? Begorderdate = null,
		DateTime? Endorderdate = null,
		int? BegorderdateOffset = null,
		int? EndorderdateOffset = null,
		int? PrintPrice = 0,
		int? PrintCost = 0,
		int? DisplayHeader = null,
		int? TaskId = null,
		string pSite = null)
		{
			StringType _ExOptacCoStat07 = ExOptacCoStat07;
			ListYesNoType _ExMiscPrintLine = ExMiscPrintLine;
			ListYesNoType _ExOptszShowDetail = ExOptszShowDetail;
			CoNumType _Begconum = Begconum;
			CoNumType _Endconum = Endconum;
			IntType _Begcoline = Begcoline;
			IntType _Endcoline = Endcoline;
			IntType _Begcorelease = Begcorelease;
			IntType _Endcorelease = Endcorelease;
			CustNumType _Begcustnum = Begcustnum;
			CustNumType _Endcustnum = Endcustnum;
			DateType _Begorderdate = Begorderdate;
			DateType _Endorderdate = Endorderdate;
			DateOffsetType _BegorderdateOffset = BegorderdateOffset;
			DateOffsetType _EndorderdateOffset = EndorderdateOffset;
			ListYesNoType _PrintPrice = PrintPrice;
			ListYesNoType _PrintCost = PrintCost;
			ListYesNoType _DisplayHeader = DisplayHeader;
			TaskNumType _TaskId = TaskId;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RPT_OrderCostSP";
				
				appDB.AddCommandParameter(cmd, "ExOptacCoStat07", _ExOptacCoStat07, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExMiscPrintLine", _ExMiscPrintLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptszShowDetail", _ExOptszShowDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Begconum", _Begconum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Endconum", _Endconum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Begcoline", _Begcoline, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Endcoline", _Endcoline, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Begcorelease", _Begcorelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Endcorelease", _Endcorelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Begcustnum", _Begcustnum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Endcustnum", _Endcustnum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Begorderdate", _Begorderdate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Endorderdate", _Endorderdate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegorderdateOffset", _BegorderdateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndorderdateOffset", _EndorderdateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintPrice", _PrintPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintCost", _PrintCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskId", _TaskId, ParameterDirection.Input);
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
