//PROJECT NAME: Finance
//CLASS NAME: GlCmprPDoProcess.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class GlCmprPDoProcess : IGlCmprPDoProcess
	{
		readonly IApplicationDB appDB;
		
		
		public GlCmprPDoProcess(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? RACompressed,
		string Infobar) GlCmprPDoProcessSp(Guid? ProcessId,
		string PCompressBy,
		string PCompressionLevel,
		int? PAnalyticalLedger,
		int? RACompressed,
		string Infobar)
		{
			GuidType _ProcessId = ProcessId;
			LongListType _PCompressBy = PCompressBy;
			LongListType _PCompressionLevel = PCompressionLevel;
			FlagNyType _PAnalyticalLedger = PAnalyticalLedger;
			FlagNyType _RACompressed = RACompressed;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GlCmprPDoProcessSp";
				
				appDB.AddCommandParameter(cmd, "ProcessId", _ProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCompressBy", _PCompressBy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCompressionLevel", _PCompressionLevel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAnalyticalLedger", _PAnalyticalLedger, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RACompressed", _RACompressed, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				RACompressed = _RACompressed;
				Infobar = _Infobar;
				
				return (Severity, RACompressed, Infobar);
			}
		}
	}
}
