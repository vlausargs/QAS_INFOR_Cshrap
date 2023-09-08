//PROJECT NAME: Data
//CLASS NAME: NextCCITransSeq.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class NextCCITransSeq : INextCCITransSeq
	{
		readonly IApplicationDB appDB;
		
		public NextCCITransSeq(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? Key,
			DateTime? SiteDate,
			string Infobar) NextCCITransSeqSp(
			decimal? Key,
			DateTime? SiteDate,
			string Infobar)
		{
			SequenceType _Key = Key;
			DateTimeType _SiteDate = SiteDate;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "NextCCITransSeqSp";
				
				appDB.AddCommandParameter(cmd, "Key", _Key, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SiteDate", _SiteDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Key = _Key;
				SiteDate = _SiteDate;
				Infobar = _Infobar;
				
				return (Severity, Key, SiteDate, Infobar);
			}
		}
	}
}
