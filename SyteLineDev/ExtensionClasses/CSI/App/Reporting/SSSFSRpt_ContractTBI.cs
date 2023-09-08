//PROJECT NAME: Reporting
//CLASS NAME: SSSFSRpt_ContractTBI.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class SSSFSRpt_ContractTBI : ISSSFSRpt_ContractTBI
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public SSSFSRpt_ContractTBI(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) SSSFSRpt_ContractTBISp(string ExOptBegCon_num = null,
		string ExOptEndCon_num = null,
		int? ExOptBegCon_line = null,
		int? ExOptEndCon_line = null,
		string ExOptBegcust_num = null,
		string ExOptENDcust_num = null,
		string ExOptBegserv_type = null,
		string ExOptENDserv_type = null,
		DateTime? ExOptRenew_date = null,
		int? Renew_dateOffSET = null,
		int? ExOptConIntNotes = 1,
		int? ExOptConExtNotes = 1,
		int? ExOptCustIntNotes = 1,
		int? ExOptCustExtNotes = 1,
		int? ExOptCustPage = 1,
		string ExOptBillFreq = "ASQBMO",
		int? ExOptContLineIntNotes = 1,
		int? ExOptContLineExtNotes = 1,
		string pSite = null)
		{
			FSContractType _ExOptBegCon_num = ExOptBegCon_num;
			FSContractType _ExOptEndCon_num = ExOptEndCon_num;
			FSContLineType _ExOptBegCon_line = ExOptBegCon_line;
			FSContLineType _ExOptEndCon_line = ExOptEndCon_line;
			CustNumType _ExOptBegcust_num = ExOptBegcust_num;
			CustNumType _ExOptENDcust_num = ExOptENDcust_num;
			FSContServTypeType _ExOptBegserv_type = ExOptBegserv_type;
			FSContServTypeType _ExOptENDserv_type = ExOptENDserv_type;
			DateType _ExOptRenew_date = ExOptRenew_date;
			DateOffsetType _Renew_dateOffSET = Renew_dateOffSET;
			ListYesNoType _ExOptConIntNotes = ExOptConIntNotes;
			ListYesNoType _ExOptConExtNotes = ExOptConExtNotes;
			ListYesNoType _ExOptCustIntNotes = ExOptCustIntNotes;
			ListYesNoType _ExOptCustExtNotes = ExOptCustExtNotes;
			ListYesNoType _ExOptCustPage = ExOptCustPage;
			InfobarType _ExOptBillFreq = ExOptBillFreq;
			ListYesNoType _ExOptContLineIntNotes = ExOptContLineIntNotes;
			ListYesNoType _ExOptContLineExtNotes = ExOptContLineExtNotes;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSRpt_ContractTBISp";
				
				appDB.AddCommandParameter(cmd, "ExOptBegCon_num", _ExOptBegCon_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptEndCon_num", _ExOptEndCon_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptBegCon_line", _ExOptBegCon_line, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptEndCon_line", _ExOptEndCon_line, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptBegcust_num", _ExOptBegcust_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptENDcust_num", _ExOptENDcust_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptBegserv_type", _ExOptBegserv_type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptENDserv_type", _ExOptENDserv_type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptRenew_date", _ExOptRenew_date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Renew_dateOffSET", _Renew_dateOffSET, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptConIntNotes", _ExOptConIntNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptConExtNotes", _ExOptConExtNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptCustIntNotes", _ExOptCustIntNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptCustExtNotes", _ExOptCustExtNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptCustPage", _ExOptCustPage, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptBillFreq", _ExOptBillFreq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptContLineIntNotes", _ExOptContLineIntNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptContLineExtNotes", _ExOptContLineExtNotes, ParameterDirection.Input);
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
