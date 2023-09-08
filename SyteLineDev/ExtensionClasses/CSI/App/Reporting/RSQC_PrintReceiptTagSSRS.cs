//PROJECT NAME: Reporting
//CLASS NAME: RSQC_PrintReceiptTagSSRS.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class RSQC_PrintReceiptTagSSRS : IRSQC_PrintReceiptTagSSRS
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public RSQC_PrintReceiptTagSSRS(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) RSQC_PrintReceiptTagSSRSsp(int? i_RcvrNum,
		DateTime? i_TransDate,
		string i_UserCode,
		decimal? i_TagQty,
		string i_Stat,
		string psite)
		{
			QCRcvrNumType _i_RcvrNum = i_RcvrNum;
			DateType _i_TransDate = i_TransDate;
			UserCodeType _i_UserCode = i_UserCode;
			QtyUnitType _i_TagQty = i_TagQty;
			QCCodeType _i_Stat = i_Stat;
			SiteType _psite = psite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_PrintReceiptTagSSRSsp";
				
				appDB.AddCommandParameter(cmd, "i_RcvrNum", _i_RcvrNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_TransDate", _i_TransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_UserCode", _i_UserCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_TagQty", _i_TagQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_Stat", _i_Stat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "psite", _psite, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
