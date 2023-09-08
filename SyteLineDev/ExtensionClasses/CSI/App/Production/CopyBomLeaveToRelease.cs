//PROJECT NAME: CSIProduct
//CLASS NAME: CopyBomLeaveToRelease.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
	public interface ICopyBomLeaveToRelease
	{
		int CopyBomLeaveToReleaseSp(string Item_F,
		                            string Type_F,
		                            ref string PsNum,
		                            ref string Item,
		                            ref string Job,
		                            ref short? Suffix,
		                            ref DateTime? DueDate,
		                            ref int? StartOper,
		                            ref int? EndOper,
		                            ref string ItemRev,
		                            ref string Infobar);
	}
	
	public class CopyBomLeaveToRelease : ICopyBomLeaveToRelease
	{
		readonly IApplicationDB appDB;
		
		public CopyBomLeaveToRelease(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int CopyBomLeaveToReleaseSp(string Item_F,
		                                   string Type_F,
		                                   ref string PsNum,
		                                   ref string Item,
		                                   ref string Job,
		                                   ref short? Suffix,
		                                   ref DateTime? DueDate,
		                                   ref int? StartOper,
		                                   ref int? EndOper,
		                                   ref string ItemRev,
		                                   ref string Infobar)
		{
			ItemType _Item_F = Item_F;
			JobTypeType _Type_F = Type_F;
			PsNumType _PsNum = PsNum;
			ItemType _Item = Item;
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			DateType _DueDate = DueDate;
			OperNumType _StartOper = StartOper;
			OperNumType _EndOper = EndOper;
			RevisionType _ItemRev = ItemRev;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CopyBomLeaveToReleaseSp";
				
				appDB.AddCommandParameter(cmd, "Item_F", _Item_F, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Type_F", _Type_F, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PsNum", _PsNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "StartOper", _StartOper, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EndOper", _EndOper, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemRev", _ItemRev, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PsNum = _PsNum;
				Item = _Item;
				Job = _Job;
				Suffix = _Suffix;
				DueDate = _DueDate;
				StartOper = _StartOper;
				EndOper = _EndOper;
				ItemRev = _ItemRev;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
