//PROJECT NAME: DataCollection
//CLASS NAME: DCAJobtrx.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public class DCAJobtrx : IDCAJobtrx
	{
		readonly IApplicationDB appDB;
		
		
		public DCAJobtrx(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) DCAJobtrxSp(string PEmpNum,
		DateTime? PDate,
		int? PTime,
		string PTermid,
		string PTransType,
		string PJob,
		int? PSuffix,
		int? POperNum,
		string PIndCode,
		decimal? PQtyComplete,
		decimal? PQtyScrapped,
		int? PCompleteOp,
		string PLoc,
		string PLot,
		decimal? PQtyMoved,
		string PReasonCode,
		string PWc,
		string Machine,
		string Infobar)
		{
			EmpNumType _PEmpNum = PEmpNum;
			DateType _PDate = PDate;
			TimeSecondsType _PTime = PTime;
			DcTermIdType _PTermid = PTermid;
			DcsfcTransTypeType _PTransType = PTransType;
			JobType _PJob = PJob;
			SuffixType _PSuffix = PSuffix;
			OperNumType _POperNum = POperNum;
			IndCodeType _PIndCode = PIndCode;
			QtyUnitNoNegType _PQtyComplete = PQtyComplete;
			QtyUnitNoNegType _PQtyScrapped = PQtyScrapped;
			ListYesNoType _PCompleteOp = PCompleteOp;
			LocType _PLoc = PLoc;
			LotType _PLot = PLot;
			QtyUnitNoNegType _PQtyMoved = PQtyMoved;
			ReasonCodeType _PReasonCode = PReasonCode;
			WcType _PWc = PWc;
			ApsResourceType _Machine = Machine;
			LongListType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DCAJobtrxSp";
				
				appDB.AddCommandParameter(cmd, "PEmpNum", _PEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDate", _PDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTime", _PTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTermid", _PTermid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransType", _PTransType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PJob", _PJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSuffix", _PSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POperNum", _POperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PIndCode", _PIndCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQtyComplete", _PQtyComplete, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQtyScrapped", _PQtyScrapped, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCompleteOp", _PCompleteOp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLoc", _PLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLot", _PLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQtyMoved", _PQtyMoved, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PReasonCode", _PReasonCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PWc", _PWc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Machine", _Machine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
