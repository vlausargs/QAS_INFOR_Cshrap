//PROJECT NAME: Logistics
//CLASS NAME: CLM_FTSLEmployeeLabel.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class CLM_FTSLEmployeeLabel : ICLM_FTSLEmployeeLabel
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_FTSLEmployeeLabel(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, string Infobar) CLM_FTSLEmployeeLabelSp(string FromEmp,
		string ToEmp,
		int? FromRange,
		int? ToRange,
		string Infobar)
		{
			EmpNumType _FromEmp = FromEmp;
			EmpNumType _ToEmp = ToEmp;
			CustSeqType _FromRange = FromRange;
			CustSeqType _ToRange = ToRange;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_FTSLEmployeeLabelSp";
				
				appDB.AddCommandParameter(cmd, "FromEmp", _FromEmp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToEmp", _ToEmp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromRange", _FromRange, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToRange", _ToRange, ParameterDirection.Input);
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
