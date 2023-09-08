//PROJECT NAME: Data
//CLASS NAME: CheckYearEndClosing.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CheckYearEndClosing : ICheckYearEndClosing
	{
		readonly IApplicationDB appDB;
		
		public CheckYearEndClosing(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) CheckYearEndClosingSp(
			DateTime? BegDate,
			DateTime? EndDate,
			int? Post,
			string Infobar)
		{
			DateType _BegDate = BegDate;
			DateType _EndDate = EndDate;
			Flag _Post = Post;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CheckYearEndClosingSp";
				
				appDB.AddCommandParameter(cmd, "BegDate", _BegDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDate", _EndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Post", _Post, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
