//PROJECT NAME: Employee
//CLASS NAME: SalUpd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public interface ISalUpd
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) SalUpdSp(string ProcSel,
		string StartDept,
		string EndDept,
		string StartEmp,
		string EndEmp,
		DateTime? StartEffDate,
		DateTime? EndEffDate,
		string Infobar,
		short? StartEffDateOffset = null,
		short? EndEffDateOffset = null);
	}
	
	public class SalUpd : ISalUpd
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public SalUpd(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, string Infobar) SalUpdSp(string ProcSel,
		string StartDept,
		string EndDept,
		string StartEmp,
		string EndEmp,
		DateTime? StartEffDate,
		DateTime? EndEffDate,
		string Infobar,
		short? StartEffDateOffset = null,
		short? EndEffDateOffset = null)
		{
			LongListType _ProcSel = ProcSel;
			DeptType _StartDept = StartDept;
			DeptType _EndDept = EndDept;
			EmpNumType _StartEmp = StartEmp;
			EmpNumType _EndEmp = EndEmp;
			DateType _StartEffDate = StartEffDate;
			DateType _EndEffDate = EndEffDate;
			InfobarType _Infobar = Infobar;
			DateOffsetType _StartEffDateOffset = StartEffDateOffset;
			DateOffsetType _EndEffDateOffset = EndEffDateOffset;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SalUpdSp";
				
				appDB.AddCommandParameter(cmd, "ProcSel", _ProcSel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDept", _StartDept, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDept", _EndDept, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartEmp", _StartEmp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndEmp", _EndEmp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartEffDate", _StartEffDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndEffDate", _EndEffDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "StartEffDateOffset", _StartEffDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndEffDateOffset", _EndEffDateOffset, ParameterDirection.Input);
				
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
