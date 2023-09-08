//PROJECT NAME: Production
//CLASS NAME: JobSplitAdjustment.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class JobSplitAdjustment : IJobSplitAdjustment
	{
		readonly IApplicationDB appDB;
		
		
		public JobSplitAdjustment(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) JobSplitAdjustmentSp(int? Mode,
		string NewJob,
		int? NewSuffix,
		int? OperNum,
		decimal? OpQtyReceived,
		decimal? OpQtyComplete,
		decimal? OpQtyMoved,
		decimal? OpSetupHrsT,
		decimal? OpRunHrsTLbr,
		decimal? OpRunHrsTMch,
		string MatlItem,
		string MatlType,
		decimal? MatlQtyIssuedConv,
		decimal? MatlAMatlCost,
		decimal? MatlALbrCost,
		decimal? MatlAOutCost,
		decimal? MatlAFovhdCost,
		decimal? MatlAVovhdCost,
		string Infobar)
		{
			ListYesNoType _Mode = Mode;
			JobType _NewJob = NewJob;
			SuffixType _NewSuffix = NewSuffix;
			OperNumType _OperNum = OperNum;
			QtyUnitType _OpQtyReceived = OpQtyReceived;
			QtyUnitType _OpQtyComplete = OpQtyComplete;
			QtyUnitType _OpQtyMoved = OpQtyMoved;
			TotalHoursType _OpSetupHrsT = OpSetupHrsT;
			TotalHoursType _OpRunHrsTLbr = OpRunHrsTLbr;
			TotalHoursType _OpRunHrsTMch = OpRunHrsTMch;
			ItemType _MatlItem = MatlItem;
			MatlTypeType _MatlType = MatlType;
			QtyPerType _MatlQtyIssuedConv = MatlQtyIssuedConv;
			CostPrcType _MatlAMatlCost = MatlAMatlCost;
			CostPrcType _MatlALbrCost = MatlALbrCost;
			CostPrcType _MatlAOutCost = MatlAOutCost;
			CostPrcType _MatlAFovhdCost = MatlAFovhdCost;
			CostPrcType _MatlAVovhdCost = MatlAVovhdCost;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JobSplitAdjustmentSp";
				
				appDB.AddCommandParameter(cmd, "Mode", _Mode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewJob", _NewJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewSuffix", _NewSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OpQtyReceived", _OpQtyReceived, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OpQtyComplete", _OpQtyComplete, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OpQtyMoved", _OpQtyMoved, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OpSetupHrsT", _OpSetupHrsT, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OpRunHrsTLbr", _OpRunHrsTLbr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OpRunHrsTMch", _OpRunHrsTMch, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatlItem", _MatlItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatlType", _MatlType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatlQtyIssuedConv", _MatlQtyIssuedConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatlAMatlCost", _MatlAMatlCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatlALbrCost", _MatlALbrCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatlAOutCost", _MatlAOutCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatlAFovhdCost", _MatlAFovhdCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatlAVovhdCost", _MatlAVovhdCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
