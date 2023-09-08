//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ItemSalespersonSalesAnalysis.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_ItemSalespersonSalesAnalysis
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ItemSalespersonSalesAnalysisSP(string ExBegSlsman = null,
		string ExEndSlsman = null,
		DateTime? ExOptacAsOfDate = null,
		short? ExOptacAsOfDateOffset = null,
		byte? ExOptprPageItems = null,
		byte? DisplayHeader = null,
		int? TaskId = null,
		string pSite = null);
	}
	
	public class Rpt_ItemSalespersonSalesAnalysis : IRpt_ItemSalespersonSalesAnalysis
	{
		IApplicationDB appDB;
		IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ItemSalespersonSalesAnalysis(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ItemSalespersonSalesAnalysisSP(string ExBegSlsman = null,
		string ExEndSlsman = null,
		DateTime? ExOptacAsOfDate = null,
		short? ExOptacAsOfDateOffset = null,
		byte? ExOptprPageItems = null,
		byte? DisplayHeader = null,
		int? TaskId = null,
		string pSite = null)
		{
			SlsmanType _ExBegSlsman = ExBegSlsman;
			SlsmanType _ExEndSlsman = ExEndSlsman;
			DateType _ExOptacAsOfDate = ExOptacAsOfDate;
			DateOffsetType _ExOptacAsOfDateOffset = ExOptacAsOfDateOffset;
			ListYesNoType _ExOptprPageItems = ExOptprPageItems;
			ListYesNoType _DisplayHeader = DisplayHeader;
			TaskNumType _TaskId = TaskId;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ItemSalespersonSalesAnalysisSP";
				
				appDB.AddCommandParameter(cmd, "ExBegSlsman", _ExBegSlsman, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExEndSlsman", _ExEndSlsman, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptacAsOfDate", _ExOptacAsOfDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptacAsOfDateOffset", _ExOptacAsOfDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptprPageItems", _ExOptprPageItems, ParameterDirection.Input);
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
