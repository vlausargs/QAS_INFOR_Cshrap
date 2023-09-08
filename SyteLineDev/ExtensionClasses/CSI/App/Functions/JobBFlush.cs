//PROJECT NAME: Data
//CLASS NAME: JobBFlush.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class JobBFlush : IJobBFlush
	{
		readonly IApplicationDB appDB;
		
		public JobBFlush(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			DateTime? TDate,
			string CurWhse,
			decimal? TRouteQtyComplete,
			decimal? TRouteQtyScrapped,
			string TTransClass,
			string TEmpNum,
			decimal? TJobtranTransNum,
			string Infobar) JobBFlushSp(
			Guid? PJobRouteRp,
			string PJob,
			int? PSuffix,
			int? POper,
			decimal? PPhantomMulti,
			string PPhantomUnits,
			decimal? PPhantomScrap,
			string PBflushSetup,
			DateTime? TDate,
			string CurWhse,
			decimal? TRouteQtyComplete,
			decimal? TRouteQtyScrapped,
			string TTransClass,
			string TEmpNum,
			decimal? TJobtranTransNum,
			string Infobar)
		{
			RowPointerType _PJobRouteRp = PJobRouteRp;
			JobType _PJob = PJob;
			SuffixType _PSuffix = PSuffix;
			OperNumType _POper = POper;
			QtyPerType _PPhantomMulti = PPhantomMulti;
			LongListType _PPhantomUnits = PPhantomUnits;
			ScrapFactorType _PPhantomScrap = PPhantomScrap;
			LongListType _PBflushSetup = PBflushSetup;
			CurrentDateType _TDate = TDate;
			WhseType _CurWhse = CurWhse;
			QtyUnitType _TRouteQtyComplete = TRouteQtyComplete;
			QtyUnitType _TRouteQtyScrapped = TRouteQtyScrapped;
			JobtranClassType _TTransClass = TTransClass;
			EmpNumType _TEmpNum = TEmpNum;
			HugeTransNumType _TJobtranTransNum = TJobtranTransNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JobBFlushSp";
				
				appDB.AddCommandParameter(cmd, "PJobRouteRp", _PJobRouteRp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PJob", _PJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSuffix", _PSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POper", _POper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPhantomMulti", _PPhantomMulti, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPhantomUnits", _PPhantomUnits, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPhantomScrap", _PPhantomScrap, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBflushSetup", _PBflushSetup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TDate", _TDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurWhse", _CurWhse, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TRouteQtyComplete", _TRouteQtyComplete, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TRouteQtyScrapped", _TRouteQtyScrapped, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TTransClass", _TTransClass, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TEmpNum", _TEmpNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TJobtranTransNum", _TJobtranTransNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TDate = _TDate;
				CurWhse = _CurWhse;
				TRouteQtyComplete = _TRouteQtyComplete;
				TRouteQtyScrapped = _TRouteQtyScrapped;
				TTransClass = _TTransClass;
				TEmpNum = _TEmpNum;
				TJobtranTransNum = _TJobtranTransNum;
				Infobar = _Infobar;
				
				return (Severity, TDate, CurWhse, TRouteQtyComplete, TRouteQtyScrapped, TTransClass, TEmpNum, TJobtranTransNum, Infobar);
			}
		}
	}
}
