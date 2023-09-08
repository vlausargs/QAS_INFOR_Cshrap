//PROJECT NAME: Finance
//CLASS NAME: CLM_FinStmtPreview.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public interface ICLM_FinStmtPreview
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_FinStmtPreviewSp(string pSource1,
		string pRange1,
		short? pFiscalYear1,
		byte? pCurPeriod1,
		string pSource2,
		string pRange2,
		short? pFiscalYear2,
		byte? pCurPeriod2,
		DateTime? pCurPerStart1,
		DateTime? pCurPerEnd1,
		DateTime? pCurPerStart2,
		DateTime? pCurPerEnd2,
		string pReportID,
		string FilterString = null);
	}
	
	public class CLM_FinStmtPreview : ICLM_FinStmtPreview
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_FinStmtPreview(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_FinStmtPreviewSp(string pSource1,
		string pRange1,
		short? pFiscalYear1,
		byte? pCurPeriod1,
		string pSource2,
		string pRange2,
		short? pFiscalYear2,
		byte? pCurPeriod2,
		DateTime? pCurPerStart1,
		DateTime? pCurPerEnd1,
		DateTime? pCurPerStart2,
		DateTime? pCurPerEnd2,
		string pReportID,
		string FilterString = null)
		{
			bunchedLoadCollection.StartBunching();
			
			try
			{
				GlrpthcSourceType _pSource1 = pSource1;
				GlrpthcRangeType _pRange1 = pRange1;
				FiscalYearType _pFiscalYear1 = pFiscalYear1;
				FinPeriodType _pCurPeriod1 = pCurPeriod1;
				GlrpthcSourceType _pSource2 = pSource2;
				GlrpthcRangeType _pRange2 = pRange2;
				FiscalYearType _pFiscalYear2 = pFiscalYear2;
				FinPeriodType _pCurPeriod2 = pCurPeriod2;
				DateType _pCurPerStart1 = pCurPerStart1;
				DateType _pCurPerEnd1 = pCurPerEnd1;
				DateType _pCurPerStart2 = pCurPerStart2;
				DateType _pCurPerEnd2 = pCurPerEnd2;
				RptIdType _pReportID = pReportID;
				LongListType _FilterString = FilterString;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "CLM_FinStmtPreviewSp";
					
					appDB.AddCommandParameter(cmd, "pSource1", _pSource1, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "pRange1", _pRange1, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "pFiscalYear1", _pFiscalYear1, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "pCurPeriod1", _pCurPeriod1, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "pSource2", _pSource2, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "pRange2", _pRange2, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "pFiscalYear2", _pFiscalYear2, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "pCurPeriod2", _pCurPeriod2, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "pCurPerStart1", _pCurPerStart1, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "pCurPerEnd1", _pCurPerEnd1, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "pCurPerStart2", _pCurPerStart2, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "pCurPerEnd2", _pCurPerEnd2, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "pReportID", _pReportID, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "FilterString", _FilterString, ParameterDirection.Input);
					
					IntType returnVal = 0;
					IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
					dbParm.DbType = DbType.Int32;

                    dtReturn = appDB.ExecuteQuery(cmd);

                    return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
				}
			}
			finally
			{
				bunchedLoadCollection.EndBunching();
			}
		}
	}
}
