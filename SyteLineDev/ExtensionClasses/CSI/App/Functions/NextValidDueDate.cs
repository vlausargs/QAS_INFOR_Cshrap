//PROJECT NAME: Data
//CLASS NAME: NextValidDueDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class NextValidDueDate : INextValidDueDate
	{
		readonly IApplicationDB appDB;
		
		public NextValidDueDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) NextValidDueDateSp(
			string RefType,
			int? IsForward,
			DateTime? DueDate,
			string Infobar)
		{
			RefType _RefType = RefType;
			ListYesNoType _IsForward = IsForward;
			DateType _DueDate = DueDate;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "NextValidDueDateSp";
				
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IsForward", _IsForward, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
