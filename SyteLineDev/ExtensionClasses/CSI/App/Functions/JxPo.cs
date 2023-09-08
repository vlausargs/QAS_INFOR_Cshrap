//PROJECT NAME: Data
//CLASS NAME: JxPo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class JxPo : IJxPo
	{
		readonly IApplicationDB appDB;
		
		public JxPo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string PAction,
			string Infobar) JxPoSp(
			string PPoNum,
			int? PPoLine,
			int? PPoRelease,
			string PJob,
			int? PSuffix,
			int? POperNum,
			int? PSeq,
			int? PPoChangeOrd,
			string PAction,
			string Infobar,
			string ExportType)
		{
			PoNumType _PPoNum = PPoNum;
			PoLineType _PPoLine = PPoLine;
			PoReleaseType _PPoRelease = PPoRelease;
			JobType _PJob = PJob;
			SuffixType _PSuffix = PSuffix;
			OperNumType _POperNum = POperNum;
			JobmatlSequenceType _PSeq = PSeq;
			FlagNyType _PPoChangeOrd = PPoChangeOrd;
			LongListType _PAction = PAction;
			InfobarType _Infobar = Infobar;
			ListDirectIndirectNonExportType _ExportType = ExportType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JxPoSp";
				
				appDB.AddCommandParameter(cmd, "PPoNum", _PPoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPoLine", _PPoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPoRelease", _PPoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PJob", _PJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSuffix", _PSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POperNum", _POperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSeq", _PSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPoChangeOrd", _PPoChangeOrd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAction", _PAction, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ExportType", _ExportType, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PAction = _PAction;
				Infobar = _Infobar;
				
				return (Severity, PAction, Infobar);
			}
		}
	}
}
