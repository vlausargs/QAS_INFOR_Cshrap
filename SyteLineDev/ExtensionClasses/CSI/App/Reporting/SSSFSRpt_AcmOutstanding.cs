//PROJECT NAME: Reporting
//CLASS NAME: SSSFSRpt_AcmOutstanding.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class SSSFSRpt_AcmOutstanding : ISSSFSRpt_AcmOutstanding
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public SSSFSRpt_AcmOutstanding(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, string Infobar) SSSFSRpt_AcmOutstandingSp(string ExOptBegCust_num = null,
		string ExOptEndCust_num = null,
		string ExOptBegRef_num = null,
		string ExOptEndRef_num = null,
		string ExOptBegInv_num = null,
		string ExOptEndInv_num = null,
		string ExOptBegAcct_num = null,
		string ExOptEndAcct_num = null,
		string ACMStatus = null,
		string Infobar = null,
		string pSite = null,
		string ReportOption = null)
		{
			CustNumType _ExOptBegCust_num = ExOptBegCust_num;
			CustNumType _ExOptEndCust_num = ExOptEndCust_num;
			FSRefNumType _ExOptBegRef_num = ExOptBegRef_num;
			FSRefNumType _ExOptEndRef_num = ExOptEndRef_num;
			InvNumType _ExOptBegInv_num = ExOptBegInv_num;
			InvNumType _ExOptEndInv_num = ExOptEndInv_num;
			AcctType _ExOptBegAcct_num = ExOptBegAcct_num;
			AcctType _ExOptEndAcct_num = ExOptEndAcct_num;
			StringType _ACMStatus = ACMStatus;
			Infobar _Infobar = Infobar;
			SiteType _pSite = pSite;
			StringType _ReportOption = ReportOption;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSRpt_AcmOutstandingSp";
				
				appDB.AddCommandParameter(cmd, "ExOptBegCust_num", _ExOptBegCust_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptEndCust_num", _ExOptEndCust_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptBegRef_num", _ExOptBegRef_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptEndRef_num", _ExOptEndRef_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptBegInv_num", _ExOptBegInv_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptEndInv_num", _ExOptEndInv_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptBegAcct_num", _ExOptBegAcct_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptEndAcct_num", _ExOptEndAcct_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ACMStatus", _ACMStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReportOption", _ReportOption, ParameterDirection.Input);
				
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
