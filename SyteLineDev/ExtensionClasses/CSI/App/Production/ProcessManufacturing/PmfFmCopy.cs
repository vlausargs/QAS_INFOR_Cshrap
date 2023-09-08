//PROJECT NAME: Production
//CLASS NAME: PmfFmCopy.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfFmCopy : IPmfFmCopy
	{
		readonly IApplicationDB appDB;
		
		public PmfFmCopy(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string InfoBar,
			int? Severity,
			Guid? ToFmRp) PmfFmCopySp(
			string InfoBar = null,
			int? Severity = 0,
			Guid? FromFmRp = null,
			Guid? ToFmRp = null,
			int? ToFmType = null,
			string ToFm = null,
			string ToFmVer = null,
			string OvrdWhse = null,
			int? ToRevision = null,
			int? CopyNotes = 0)
		{
			InfobarType _InfoBar = InfoBar;
			ShortType _Severity = Severity;
			RowPointerType _FromFmRp = FromFmRp;
			RowPointerType _ToFmRp = ToFmRp;
			ShortType _ToFmType = ToFmType;
			ProcessMfgFormulaIdType _ToFm = ToFm;
			ProcessMfgFormulaVersionType _ToFmVer = ToFmVer;
			WhseType _OvrdWhse = OvrdWhse;
			IntType _ToRevision = ToRevision;
			IntType _CopyNotes = CopyNotes;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfFmCopySp";
				
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Severity", _Severity, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FromFmRp", _FromFmRp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToFmRp", _ToFmRp, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ToFmType", _ToFmType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToFm", _ToFm, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToFmVer", _ToFmVer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OvrdWhse", _OvrdWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToRevision", _ToRevision, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CopyNotes", _CopyNotes, ParameterDirection.Input);
				
				Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				Severity = _Severity;
				ToFmRp = _ToFmRp;
				
				return (Severity, InfoBar, Severity, ToFmRp);
			}
		}
	}
}
