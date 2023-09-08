//PROJECT NAME: Production
//CLASS NAME: CopyBomLeaveItem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class CopyBomLeaveItem : ICopyBomLeaveItem
	{
		readonly IApplicationDB appDB;
		
		
		public CopyBomLeaveItem(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PsNum,
		string Item,
		string Job,
		int? Suffix,
		string ItemRev,
		int? StartOper,
		int? EndOper,
		string Infobar) CopyBomLeaveItemSp(string FromCategory,
		string PsNum,
		string Item,
		string Job,
		int? Suffix,
		string ItemRev,
		int? StartOper,
		int? EndOper,
		string Infobar)
		{
			StringType _FromCategory = FromCategory;
			PsNumType _PsNum = PsNum;
			ItemType _Item = Item;
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			RevisionType _ItemRev = ItemRev;
			OperNumType _StartOper = StartOper;
			OperNumType _EndOper = EndOper;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CopyBomLeaveItemSp";
				
				appDB.AddCommandParameter(cmd, "FromCategory", _FromCategory, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PsNum", _PsNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemRev", _ItemRev, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "StartOper", _StartOper, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EndOper", _EndOper, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PsNum = _PsNum;
				Item = _Item;
				Job = _Job;
				Suffix = _Suffix;
				ItemRev = _ItemRev;
				StartOper = _StartOper;
				EndOper = _EndOper;
				Infobar = _Infobar;
				
				return (Severity, PsNum, Item, Job, Suffix, ItemRev, StartOper, EndOper, Infobar);
			}
		}
	}
}
