//PROJECT NAME: Reporting
//CLASS NAME: Rpt_TaxVoucheredParametric.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_TaxVoucheredParametric : IRpt_TaxVoucheredParametric
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_TaxVoucheredParametric(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_TaxVoucheredParametricSp(int? TaxJurTaxSystem = null,
		int? ExOptszShowDetail = null,
		string TaxJurTaxJur = null,
		DateTime? ExBegInvStaxInvDate = null,
		DateTime? ExENDInvStaxInvDate = null,
		int? ExOptgoInclVchPr = null,
		int? TAXDateStartingOffSET = null,
		int? TAXDateENDingOffSET = null,
		int? DisplayHeader = null,
		string BGSessionId = null,
		int? TaskId = null,
		string pSite = null)
		{
			TaxSystemType _TaxJurTaxSystem = TaxJurTaxSystem;
			ListYesNoType _ExOptszShowDetail = ExOptszShowDetail;
			TaxJurType _TaxJurTaxJur = TaxJurTaxJur;
			DateType _ExBegInvStaxInvDate = ExBegInvStaxInvDate;
			DateType _ExENDInvStaxInvDate = ExENDInvStaxInvDate;
			ListYesNoType _ExOptgoInclVchPr = ExOptgoInclVchPr;
			DateOffsetType _TAXDateStartingOffSET = TAXDateStartingOffSET;
			DateOffsetType _TAXDateENDingOffSET = TAXDateENDingOffSET;
			ListYesNoType _DisplayHeader = DisplayHeader;
			StringType _BGSessionId = BGSessionId;
			TaskNumType _TaskId = TaskId;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_TaxVoucheredParametricSp";
				
				appDB.AddCommandParameter(cmd, "TaxJurTaxSystem", _TaxJurTaxSystem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptszShowDetail", _ExOptszShowDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxJurTaxJur", _TaxJurTaxJur, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExBegInvStaxInvDate", _ExBegInvStaxInvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExENDInvStaxInvDate", _ExENDInvStaxInvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptgoInclVchPr", _ExOptgoInclVchPr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TAXDateStartingOffSET", _TAXDateStartingOffSET, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TAXDateENDingOffSET", _TAXDateENDingOffSET, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGSessionId", _BGSessionId, ParameterDirection.Input);
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
