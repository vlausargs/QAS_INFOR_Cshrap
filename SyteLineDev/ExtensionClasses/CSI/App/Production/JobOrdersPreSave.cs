//PROJECT NAME: Production
//CLASS NAME: JobOrdersPreSave.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class JobOrdersPreSave : IJobOrdersPreSave
	{
		readonly IApplicationDB appDB;
		
		
		public JobOrdersPreSave(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, DateTime? PStartDate,
		DateTime? PEndDate,
		decimal? PStartTick,
		decimal? PEndTick,
		string Infobar) JobOrdersPreSaveSp(string PJob,
		int? PSuffix,
		string PJobType,
		string PItem,
		decimal? PQtyReleased,
		int? PCoProductMix,
		string POrdType,
		string POrdNum,
		int? POrdLine,
		int? POrdRelease,
		string OldStat,
		string NewStat,
		DateTime? PStartDate,
		DateTime? PEndDate,
		decimal? PStartTick,
		decimal? PEndTick,
		string Infobar)
		{
			JobType _PJob = PJob;
			SuffixType _PSuffix = PSuffix;
			JobTypeType _PJobType = PJobType;
			ItemType _PItem = PItem;
			QtyUnitType _PQtyReleased = PQtyReleased;
			ListYesNoType _PCoProductMix = PCoProductMix;
			RefTypeIKOTType _POrdType = POrdType;
			CoProjTrnNumType _POrdNum = POrdNum;
			CoProjTaskTrnLineType _POrdLine = POrdLine;
			CoReleaseType _POrdRelease = POrdRelease;
			JobStatusType _OldStat = OldStat;
			JobStatusType _NewStat = NewStat;
			DateType _PStartDate = PStartDate;
			DateType _PEndDate = PEndDate;
			TicksType _PStartTick = PStartTick;
			TicksType _PEndTick = PEndTick;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JobOrdersPreSaveSp";
				
				appDB.AddCommandParameter(cmd, "PJob", _PJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSuffix", _PSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PJobType", _PJobType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQtyReleased", _PQtyReleased, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoProductMix", _PCoProductMix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POrdType", _POrdType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POrdNum", _POrdNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POrdLine", _POrdLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POrdRelease", _POrdRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldStat", _OldStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewStat", _NewStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartDate", _PStartDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PEndDate", _PEndDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PStartTick", _PStartTick, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PEndTick", _PEndTick, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PStartDate = _PStartDate;
				PEndDate = _PEndDate;
				PStartTick = _PStartTick;
				PEndTick = _PEndTick;
				Infobar = _Infobar;
				
				return (Severity, PStartDate, PEndDate, PStartTick, PEndTick, Infobar);
			}
		}
	}
}
