//PROJECT NAME: Finance
//CLASS NAME: VoidPayUpdate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class VoidPayUpdate : IVoidPayUpdate
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public VoidPayUpdate(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, string Infobar) VoidPayUpdateSp(Guid? pRowPointer,
		string SessionIDChar,
		int? ProcessFlag,
		string Infobar)
		{
			RowPointerType _pRowPointer = pRowPointer;
			StringType _SessionIDChar = SessionIDChar;
			ListYesNoType _ProcessFlag = ProcessFlag;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "VoidPayUpdateSp";
				
				appDB.AddCommandParameter(cmd, "pRowPointer", _pRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SessionIDChar", _SessionIDChar, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProcessFlag", _ProcessFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
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
