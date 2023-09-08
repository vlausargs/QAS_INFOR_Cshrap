//PROJECT NAME: DataCollection
//CLASS NAME: DcJmcValidateEmpNum.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public class DcJmcValidateEmpNum : IDcJmcValidateEmpNum
	{
		readonly IApplicationDB appDB;
		
		
		public DcJmcValidateEmpNum(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string EmpNum,
		string EmpName,
		string Infobar) DcJmcValidateEmpNumSp(int? Connected,
		string EmpNum,
		string EmpName,
		string Infobar)
		{
			ListYesNoType _Connected = Connected;
			EmpNumType _EmpNum = EmpNum;
			EmpNameType _EmpName = EmpName;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DcJmcValidateEmpNumSp";
				
				appDB.AddCommandParameter(cmd, "Connected", _Connected, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmpNum", _EmpNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EmpName", _EmpName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				EmpNum = _EmpNum;
				EmpName = _EmpName;
				Infobar = _Infobar;
				
				return (Severity, EmpNum, EmpName, Infobar);
			}
		}
	}
}
