//PROJECT NAME: Data
//CLASS NAME: RemoteDataPull.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class RemoteDataPull : IRemoteDataPull
	{
		readonly IApplicationDB appDB;
		
		public RemoteDataPull(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) RemoteDataPullSp(
			string TargetSite,
			string SourceSite,
			Guid? SessionID,
			string PreLoadSp = null,
			string Table = null,
			string Where = null,
			string Infobar = null)
		{
			SiteType _TargetSite = TargetSite;
			SiteType _SourceSite = SourceSite;
			RowPointerType _SessionID = SessionID;
			LongListType _PreLoadSp = PreLoadSp;
			LongListType _Table = Table;
			LongListType _Where = Where;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RemoteDataPullSp";
				
				appDB.AddCommandParameter(cmd, "TargetSite", _TargetSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SourceSite", _SourceSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PreLoadSp", _PreLoadSp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Table", _Table, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Where", _Where, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
