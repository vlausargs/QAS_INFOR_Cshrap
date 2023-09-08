//PROJECT NAME: CSIProduct
//CLASS NAME: CopyBomLeaveJobSuffix.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
	public interface ICopyBomLeaveJobSuffix
	{
		int CopyBomLeaveJobSuffixSp(string FromCategory,
		                            ref string Job,
		                            ref short? Suffix,
		                            ref string PsNum,
		                            ref string Item,
		                            ref string ItemRev,
		                            ref int? StartOper,
		                            ref int? EndOper,
		                            ref string Infobar,
		                            ref byte? Rework);
	}
	
	public class CopyBomLeaveJobSuffix : ICopyBomLeaveJobSuffix
	{
		readonly IApplicationDB appDB;
		
		public CopyBomLeaveJobSuffix(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int CopyBomLeaveJobSuffixSp(string FromCategory,
		                                   ref string Job,
		                                   ref short? Suffix,
		                                   ref string PsNum,
		                                   ref string Item,
		                                   ref string ItemRev,
		                                   ref int? StartOper,
		                                   ref int? EndOper,
		                                   ref string Infobar,
		                                   ref byte? Rework)
		{
			StringType _FromCategory = FromCategory;
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			PsNumType _PsNum = PsNum;
			ItemType _Item = Item;
			RevisionType _ItemRev = ItemRev;
			OperNumType _StartOper = StartOper;
			OperNumType _EndOper = EndOper;
			Infobar _Infobar = Infobar;
			ListYesNoType _Rework = Rework;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CopyBomLeaveJobSuffixSp";
				
				appDB.AddCommandParameter(cmd, "FromCategory", _FromCategory, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PsNum", _PsNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemRev", _ItemRev, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "StartOper", _StartOper, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EndOper", _EndOper, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Rework", _Rework, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Job = _Job;
				Suffix = _Suffix;
				PsNum = _PsNum;
				Item = _Item;
				ItemRev = _ItemRev;
				StartOper = _StartOper;
				EndOper = _EndOper;
				Infobar = _Infobar;
				Rework = _Rework;
				
				return Severity;
			}
		}
	}
}
