//PROJECT NAME: Data
//CLASS NAME: PRIOR_TO_FEATURE_RS9071_GenerateArpmtd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class PRIOR_TO_FEATURE_RS9071_GenerateArpmtd : IPRIOR_TO_FEATURE_RS9071_GenerateArpmtd
	{
		readonly IApplicationDB appDB;
		
		public PRIOR_TO_FEATURE_RS9071_GenerateArpmtd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? PCreated,
			int? PUpdated,
			int? PDeleted,
			string Infobar) PRIOR_TO_FEATURE_RS9071_GenerateArpmtdSp(
			Guid? PArpmtRowid,
			int? PCreated,
			int? PUpdated,
			int? PDeleted,
			string Infobar,
			Guid? PProcessId)
		{
			RowPointerType _PArpmtRowid = PArpmtRowid;
			GenericNoType _PCreated = PCreated;
			GenericNoType _PUpdated = PUpdated;
			GenericNoType _PDeleted = PDeleted;
			InfobarType _Infobar = Infobar;
			RowPointerType _PProcessId = PProcessId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PRIOR_TO_FEATURE_RS9071_GenerateArpmtdSp";
				
				appDB.AddCommandParameter(cmd, "PArpmtRowid", _PArpmtRowid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCreated", _PCreated, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PUpdated", _PUpdated, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PDeleted", _PDeleted, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PProcessId", _PProcessId, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PCreated = _PCreated;
				PUpdated = _PUpdated;
				PDeleted = _PDeleted;
				Infobar = _Infobar;
				
				return (Severity, PCreated, PUpdated, PDeleted, Infobar);
			}
		}
	}
}
