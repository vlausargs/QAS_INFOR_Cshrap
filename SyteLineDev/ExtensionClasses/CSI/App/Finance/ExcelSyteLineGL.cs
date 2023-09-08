//PROJECT NAME: Finance
//CLASS NAME: ExcelSyteLineGL.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class ExcelSyteLineGL : IExcelSyteLineGL
	{
		readonly IApplicationDB appDB;
		
		
		public ExcelSyteLineGL(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Queryname) ExcelSyteLineGLSp(string Queryname,
		string QueryStr,
		string QAccountCode = null,
		string QPeriod = null,
		string QYear = null,
		string UnitCode = null,
		string BalType = null)
		{
			StringType _Queryname = Queryname;
			InfobarType _QueryStr = QueryStr;
			InfobarType _QAccountCode = QAccountCode;
			StringType _QPeriod = QPeriod;
			StringType _QYear = QYear;
			InfobarType _UnitCode = UnitCode;
			StringType _BalType = BalType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ExcelSyteLineGLSp";
				
				appDB.AddCommandParameter(cmd, "Queryname", _Queryname, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QueryStr", _QueryStr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QAccountCode", _QAccountCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QPeriod", _QPeriod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QYear", _QYear, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitCode", _UnitCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BalType", _BalType, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Queryname = _Queryname;
				
				return (Severity, Queryname);
			}
		}
	}
}
