//PROJECT NAME: Logistics
//CLASS NAME: GetEdiImportParms.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GetEdiImportParms : IGetEdiImportParms
	{
		readonly IApplicationDB appDB;
		
		
		public GetEdiImportParms(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string SupTpCode,
		string SupIbDataDir,
		string SupIbArchiveDir,
		string SupEdiLogDir,
		string TpCode,
		string IbDataDir,
		string IbArchiveDir,
		string EdiLogDir,
		string ArchiveFileExt) GetEdiImportParmsSp(string SupTpCode,
		string SupIbDataDir,
		string SupIbArchiveDir,
		string SupEdiLogDir,
		string TpCode,
		string IbDataDir,
		string IbArchiveDir,
		string EdiLogDir,
		string ArchiveFileExt)
		{
			TPCodeType _SupTpCode = SupTpCode;
			OSLocationType _SupIbDataDir = SupIbDataDir;
			OSLocationType _SupIbArchiveDir = SupIbArchiveDir;
			OSLocationType _SupEdiLogDir = SupEdiLogDir;
			TPCodeType _TpCode = TpCode;
			OSLocationType _IbDataDir = IbDataDir;
			OSLocationType _IbArchiveDir = IbArchiveDir;
			OSLocationType _EdiLogDir = EdiLogDir;
			StringType _ArchiveFileExt = ArchiveFileExt;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetEdiImportParmsSp";
				
				appDB.AddCommandParameter(cmd, "SupTpCode", _SupTpCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SupIbDataDir", _SupIbDataDir, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SupIbArchiveDir", _SupIbArchiveDir, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SupEdiLogDir", _SupEdiLogDir, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TpCode", _TpCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IbDataDir", _IbDataDir, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IbArchiveDir", _IbArchiveDir, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EdiLogDir", _EdiLogDir, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ArchiveFileExt", _ArchiveFileExt, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				SupTpCode = _SupTpCode;
				SupIbDataDir = _SupIbDataDir;
				SupIbArchiveDir = _SupIbArchiveDir;
				SupEdiLogDir = _SupEdiLogDir;
				TpCode = _TpCode;
				IbDataDir = _IbDataDir;
				IbArchiveDir = _IbArchiveDir;
				EdiLogDir = _EdiLogDir;
				ArchiveFileExt = _ArchiveFileExt;
				
				return (Severity, SupTpCode, SupIbDataDir, SupIbArchiveDir, SupEdiLogDir, TpCode, IbDataDir, IbArchiveDir, EdiLogDir, ArchiveFileExt);
			}
		}
	}
}
