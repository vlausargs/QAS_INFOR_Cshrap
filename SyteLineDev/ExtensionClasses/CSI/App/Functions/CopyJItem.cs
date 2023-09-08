//PROJECT NAME: Data
//CLASS NAME: CopyJItem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CopyJItem : ICopyJItem
	{
		readonly IApplicationDB appDB;
		
		public CopyJItem(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) CopyJItemSp(
			string FromJob,
			int? FromSuffix,
			string ToJob,
			int? ToSuffix,
			string Infobar)
		{
			JobType _FromJob = FromJob;
			SuffixType _FromSuffix = FromSuffix;
			JobType _ToJob = ToJob;
			SuffixType _ToSuffix = ToSuffix;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CopyJItemSp";
				
				appDB.AddCommandParameter(cmd, "FromJob", _FromJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromSuffix", _FromSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToJob", _ToJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToSuffix", _ToSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
