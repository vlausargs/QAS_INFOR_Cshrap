//PROJECT NAME: CSICustomer
//CLASS NAME: CLM_ECSupplimentaryStatisticalDeclaration.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface ICLM_ECSupplimentaryStatisticalDeclaration
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ECSupplimentaryStatisticalDeclarationSp(DateTime? PeriodStarting,
		DateTime? PeriodEnding,
		string ExOptdfEcSsdOpt,
		byte? ExOptszSummaryOrDetail,
		byte? ExOptdfEcSsdTrade,
		byte? ExOptdfEcSsdNotc,
		byte? ExOptdfElOutput,
		string TElOut,
		string CommCodeStarting,
		string CommCodeEnding,
		string ECCodeStarting,
		string ECCodeEnding,
		short? PeriodStartingOffset,
		short? PeriodEndingOffset,
		byte? ExOptszPreviewOrPrint,
		byte? PrintFlag,
		string ExPrintPeriod,
		byte? ReportingLevel,
		string BGSessionId,
		string pSite = null);
	}
	
	public class CLM_ECSupplimentaryStatisticalDeclaration : ICLM_ECSupplimentaryStatisticalDeclaration
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_ECSupplimentaryStatisticalDeclaration(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_ECSupplimentaryStatisticalDeclarationSp(DateTime? PeriodStarting,
		DateTime? PeriodEnding,
		string ExOptdfEcSsdOpt,
		byte? ExOptszSummaryOrDetail,
		byte? ExOptdfEcSsdTrade,
		byte? ExOptdfEcSsdNotc,
		byte? ExOptdfElOutput,
		string TElOut,
		string CommCodeStarting,
		string CommCodeEnding,
		string ECCodeStarting,
		string ECCodeEnding,
		short? PeriodStartingOffset,
		short? PeriodEndingOffset,
		byte? ExOptszPreviewOrPrint,
		byte? PrintFlag,
		string ExPrintPeriod,
		byte? ReportingLevel,
		string BGSessionId,
		string pSite = null)
		{
			DateType _PeriodStarting = PeriodStarting;
			DateType _PeriodEnding = PeriodEnding;
			StringType _ExOptdfEcSsdOpt = ExOptdfEcSsdOpt;
			ListYesNoType _ExOptszSummaryOrDetail = ExOptszSummaryOrDetail;
			ListYesNoType _ExOptdfEcSsdTrade = ExOptdfEcSsdTrade;
			ListYesNoType _ExOptdfEcSsdNotc = ExOptdfEcSsdNotc;
			ListYesNoType _ExOptdfElOutput = ExOptdfElOutput;
			InfobarType _TElOut = TElOut;
			CommodityCodeType _CommCodeStarting = CommCodeStarting;
			CommodityCodeType _CommCodeEnding = CommCodeEnding;
			EcCodeType _ECCodeStarting = ECCodeStarting;
			EcCodeType _ECCodeEnding = ECCodeEnding;
			DateOffsetType _PeriodStartingOffset = PeriodStartingOffset;
			DateOffsetType _PeriodEndingOffset = PeriodEndingOffset;
			ListYesNoType _ExOptszPreviewOrPrint = ExOptszPreviewOrPrint;
			ByteType _PrintFlag = PrintFlag;
			StringType _ExPrintPeriod = ExPrintPeriod;
			ByteType _ReportingLevel = ReportingLevel;
			StringType _BGSessionId = BGSessionId;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_ECSupplimentaryStatisticalDeclarationSp";
				
				appDB.AddCommandParameter(cmd, "PeriodStarting", _PeriodStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PeriodEnding", _PeriodEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptdfEcSsdOpt", _ExOptdfEcSsdOpt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptszSummaryOrDetail", _ExOptszSummaryOrDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptdfEcSsdTrade", _ExOptdfEcSsdTrade, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptdfEcSsdNotc", _ExOptdfEcSsdNotc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptdfElOutput", _ExOptdfElOutput, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TElOut", _TElOut, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CommCodeStarting", _CommCodeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CommCodeEnding", _CommCodeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ECCodeStarting", _ECCodeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ECCodeEnding", _ECCodeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PeriodStartingOffset", _PeriodStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PeriodEndingOffset", _PeriodEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptszPreviewOrPrint", _ExOptszPreviewOrPrint, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintFlag", _PrintFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExPrintPeriod", _ExPrintPeriod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReportingLevel", _ReportingLevel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGSessionId", _BGSessionId, ParameterDirection.Input);
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
