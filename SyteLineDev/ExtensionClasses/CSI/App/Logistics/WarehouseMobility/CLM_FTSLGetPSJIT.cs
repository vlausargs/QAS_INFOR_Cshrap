//PROJECT NAME: Logistics
//CLASS NAME: CLM_FTSLGetPSJIT.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class CLM_FTSLGetPSJIT : ICLM_FTSLGetPSJIT
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_FTSLGetPSJIT(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_FTSLGetPSJITSp(int? TT_Implemented = 0,
		string Wc = null,
		string Facility = null,
		string EmpNum = null,
		int? Page = 1,
		int? IsAcitveTransaction = 0,
		DateTime? PunchDateTime = null,
		string FilterString = null,
		string OrderByString = null,
		string ERPQueryResponseString = null)
		{
			CustSeqType _TT_Implemented = TT_Implemented;
			CoNumType _Wc = Wc;
			CoNumType _Facility = Facility;
			CoNumType _EmpNum = EmpNum;
			CustSeqType _Page = Page;
			ListYesNoType _IsAcitveTransaction = IsAcitveTransaction;
			DateTimeType _PunchDateTime = PunchDateTime;
			LongListType _FilterString = FilterString;
			LongListType _OrderByString = OrderByString;
			XMLStringType _ERPQueryResponseString = ERPQueryResponseString;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_FTSLGetPSJITSp";
				
				appDB.AddCommandParameter(cmd, "TT_Implemented", _TT_Implemented, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Wc", _Wc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Facility", _Facility, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmpNum", _EmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Page", _Page, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IsAcitveTransaction", _IsAcitveTransaction, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PunchDateTime", _PunchDateTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FilterString", _FilterString, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderByString", _OrderByString, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ERPQueryResponseString", _ERPQueryResponseString, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
