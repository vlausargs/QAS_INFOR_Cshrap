//PROJECT NAME: Logistics
//CLASS NAME: SSSOPMJxPo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class SSSOPMJxPo : ISSSOPMJxPo
	{
		readonly IApplicationDB appDB;
		
		public SSSOPMJxPo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string PAction,
			string Infobar) SSSOPMJxPoSp(
			string PPoNum,
			int? PPoLine,
			int? PPoRelease,
			string PJob,
			int? PSuffix,
			int? POperNum,
			int? PSeq,
			int? PPoChangeOrd,
			decimal? PQtyMoved,
			string PPartialMethod,
			string PAction,
			string Infobar)
		{
			PoNumType _PPoNum = PPoNum;
			PoLineType _PPoLine = PPoLine;
			PoReleaseType _PPoRelease = PPoRelease;
			JobType _PJob = PJob;
			SuffixType _PSuffix = PSuffix;
			OperNumType _POperNum = POperNum;
			JobmatlSequenceType _PSeq = PSeq;
			FlagNyType _PPoChangeOrd = PPoChangeOrd;
			QtyUnitType _PQtyMoved = PQtyMoved;
			OPMPartialMethodType _PPartialMethod = PPartialMethod;
			LongListType _PAction = PAction;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSOPMJxPoSp";
				
				appDB.AddCommandParameter(cmd, "PPoNum", _PPoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPoLine", _PPoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPoRelease", _PPoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PJob", _PJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSuffix", _PSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POperNum", _POperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSeq", _PSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPoChangeOrd", _PPoChangeOrd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQtyMoved", _PQtyMoved, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPartialMethod", _PPartialMethod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAction", _PAction, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PAction = _PAction;
				Infobar = _Infobar;
				
				return (Severity, PAction, Infobar);
			}
		}
	}
}
