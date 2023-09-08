//PROJECT NAME: DataCollection
//CLASS NAME: DccoPostLoop.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public class DccoPostLoop : IDccoPostLoop
	{
		readonly IApplicationDB appDB;
		
		public DccoPostLoop(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) DccoPostLoopSp(
			DateTime? PostDate,
			string Infobar)
		{
			DateType _PostDate = PostDate;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DccoPostLoopSp";
				
				appDB.AddCommandParameter(cmd, "PostDate", _PostDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
