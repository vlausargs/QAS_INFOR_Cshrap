//PROJECT NAME: Production
//CLASS NAME: PmfRptFmAdd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfRptFmAdd
	{
		(int? ReturnCode, string InfoBar) PmfRptFmAddSp(string InfoBar = null,
		Guid? SessionId = null,
		int? Seq = null,
		Guid? FmRp = null,
		string Fm = null,
		string FmVer = null);
	}
	
	public class PmfRptFmAdd : IPmfRptFmAdd
	{
		readonly IApplicationDB appDB;
		
		public PmfRptFmAdd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string InfoBar) PmfRptFmAddSp(string InfoBar = null,
		Guid? SessionId = null,
		int? Seq = null,
		Guid? FmRp = null,
		string Fm = null,
		string FmVer = null)
		{
			InfobarType _InfoBar = InfoBar;
			GuidType _SessionId = SessionId;
			IntType _Seq = Seq;
			RowPointerType _FmRp = FmRp;
			ProcessMfgFormulaIdType _Fm = Fm;
			ProcessMfgFormulaVersionType _FmVer = FmVer;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfRptFmAddSp";
				
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SessionId", _SessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Seq", _Seq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FmRp", _FmRp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Fm", _Fm, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FmVer", _FmVer, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return (Severity, InfoBar);
			}
		}
	}
}
