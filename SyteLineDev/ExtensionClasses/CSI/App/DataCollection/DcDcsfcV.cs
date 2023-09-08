//PROJECT NAME: DataCollection
//CLASS NAME: DcDcsfcV.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public class DcDcsfcV : IDcDcsfcV
	{
		readonly IApplicationDB appDB;
		
		public DcDcsfcV(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			DateTime? PPostDate,
			int? PCanOverride,
			string Infobar) DcDcsfcVSp(
			Guid? DcsfcRowPointer,
			Guid? JobtranRowPointer,
			decimal? PAHrs,
			int? PStartTime,
			int? PEndTime,
			decimal? PJobRate,
			decimal? PQtyComplete,
			decimal? PQtyScrapped,
			decimal? PQtyMoved,
			int? PCompleteOp,
			decimal? PPrRate,
			string PPayRate,
			int? PCoprodZero,
			DateTime? PPostDate,
			int? PCanOverride,
			string Infobar)
		{
			RowPointerType _DcsfcRowPointer = DcsfcRowPointer;
			RowPointerType _JobtranRowPointer = JobtranRowPointer;
			TotalHoursType _PAHrs = PAHrs;
			TimeSecondsType _PStartTime = PStartTime;
			TimeSecondsType _PEndTime = PEndTime;
			PayRateType _PJobRate = PJobRate;
			QtyUnitNoNegType _PQtyComplete = PQtyComplete;
			QtyUnitNoNegType _PQtyScrapped = PQtyScrapped;
			QtyUnitNoNegType _PQtyMoved = PQtyMoved;
			ListYesNoType _PCompleteOp = PCompleteOp;
			PayRateType _PPrRate = PPrRate;
			PayBasisType _PPayRate = PPayRate;
			ListYesNoType _PCoprodZero = PCoprodZero;
			CurrentDateType _PPostDate = PPostDate;
			ListYesNoType _PCanOverride = PCanOverride;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DcDcsfcVSp";
				
				appDB.AddCommandParameter(cmd, "DcsfcRowPointer", _DcsfcRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobtranRowPointer", _JobtranRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAHrs", _PAHrs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartTime", _PStartTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndTime", _PEndTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PJobRate", _PJobRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQtyComplete", _PQtyComplete, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQtyScrapped", _PQtyScrapped, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQtyMoved", _PQtyMoved, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCompleteOp", _PCompleteOp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPrRate", _PPrRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPayRate", _PPayRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoprodZero", _PCoprodZero, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPostDate", _PPostDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PCanOverride", _PCanOverride, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PPostDate = _PPostDate;
				PCanOverride = _PCanOverride;
				Infobar = _Infobar;
				
				return (Severity, PPostDate, PCanOverride, Infobar);
			}
		}
	}
}
