//PROJECT NAME: Production
//CLASS NAME: EcnTrack.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class EcnTrack : IEcnTrack
	{
		readonly IApplicationDB appDB;
		
		
		public EcnTrack(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? PTrackEcn,
		string Infobar) EcnTrackSp(string PJob,
		int? PSuffix,
		string PType,
		int? PTrackEcn,
		string Infobar)
		{
			JobType _PJob = PJob;
			SuffixType _PSuffix = PSuffix;
			JobTypeType _PType = PType;
			FlagNyType _PTrackEcn = PTrackEcn;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EcnTrackSp";
				
				appDB.AddCommandParameter(cmd, "PJob", _PJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSuffix", _PSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PType", _PType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTrackEcn", _PTrackEcn, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PTrackEcn = _PTrackEcn;
				Infobar = _Infobar;
				
				return (Severity, PTrackEcn, Infobar);
			}
		}
	}
}
