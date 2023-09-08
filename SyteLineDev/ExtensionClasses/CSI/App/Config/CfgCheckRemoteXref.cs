//PROJECT NAME: Config
//CLASS NAME: CfgCheckRemoteXref.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Config
{
	public class CfgCheckRemoteXref : ICfgCheckRemoteXref
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CfgCheckRemoteXref(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode,
			int? pReturnVal,
			string Infobar) CfgCheckRemoteXrefSp(
			string pRefNum,
			int? pLineSuf,
			int? pReturnVal,
			string Infobar)
		{
			JobPoProjReqTrnNumType _pRefNum = pRefNum;
			SuffixPoLineProjTaskReqTrnLineType _pLineSuf = pLineSuf;
			IntType _pReturnVal = pReturnVal;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CfgCheckRemoteXrefSp";
				
				appDB.AddCommandParameter(cmd, "pRefNum", _pRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pLineSuf", _pLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pReturnVal", _pReturnVal, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				pReturnVal = _pReturnVal;
				Infobar = _Infobar;
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value, pReturnVal, Infobar);
			}
		}
	}
}
