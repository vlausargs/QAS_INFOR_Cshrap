//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROTransGetPostDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSSROTransGetPostDate : ISSSFSSROTransGetPostDate
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSROTransGetPostDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			DateTime? TransDate,
			DateTime? PostDate,
			string Infobar) SSSFSSROTransGetPostDateSp(
			DateTime? TransDate,
			DateTime? PostDate,
			string Infobar)
		{
			DateType _TransDate = TransDate;
			DateType _PostDate = PostDate;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSROTransGetPostDateSp";
				
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PostDate", _PostDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TransDate = _TransDate;
				PostDate = _PostDate;
				Infobar = _Infobar;
				
				return (Severity, TransDate, PostDate, Infobar);
			}
		}
	}
}
