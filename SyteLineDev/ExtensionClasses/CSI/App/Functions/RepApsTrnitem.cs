//PROJECT NAME: Data
//CLASS NAME: RepApsTrnitem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class RepApsTrnitem : IRepApsTrnitem
	{
		readonly IApplicationDB appDB;
		
		public RepApsTrnitem(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) RepApsTrnitemSp(
			string TrnNum,
			int? TrnLine,
			DateTime? ProjectedDate,
			string Infobar,
			int? BulkMode = 0,
			Guid? ProcessId = null,
			string FromSite = null)
		{
			TrnNumType _TrnNum = TrnNum;
			TrnLineType _TrnLine = TrnLine;
			DateType _ProjectedDate = ProjectedDate;
			InfobarType _Infobar = Infobar;
			ListYesNoType _BulkMode = BulkMode;
			RowPointerType _ProcessId = ProcessId;
			SiteType _FromSite = FromSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RepApsTrnitemSp";
				
				appDB.AddCommandParameter(cmd, "TrnNum", _TrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnLine", _TrnLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProjectedDate", _ProjectedDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BulkMode", _BulkMode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProcessId", _ProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromSite", _FromSite, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
