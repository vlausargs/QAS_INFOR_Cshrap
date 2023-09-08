//PROJECT NAME: CSICustomer
//CLASS NAME: CpDo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface ICpDo
	{
		int CpDoSp(string FromDoNum,
		           string CopyLines,
		           int? StartLineNum,
		           int? EndLineNum,
		           ref string ToDoNum,
		           string CopyOption,
		           ref string Infobar);
	}
	
	public class CpDo : ICpDo
	{
		readonly IApplicationDB appDB;
		
		public CpDo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int CpDoSp(string FromDoNum,
		                  string CopyLines,
		                  int? StartLineNum,
		                  int? EndLineNum,
		                  ref string ToDoNum,
		                  string CopyOption,
		                  ref string Infobar)
		{
			DoNumType _FromDoNum = FromDoNum;
			StringType _CopyLines = CopyLines;
			DoLineType _StartLineNum = StartLineNum;
			DoLineType _EndLineNum = EndLineNum;
			DoNumType _ToDoNum = ToDoNum;
			StringType _CopyOption = CopyOption;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CpDoSp";
				
				appDB.AddCommandParameter(cmd, "FromDoNum", _FromDoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CopyLines", _CopyLines, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartLineNum", _StartLineNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndLineNum", _EndLineNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToDoNum", _ToDoNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CopyOption", _CopyOption, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ToDoNum = _ToDoNum;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
