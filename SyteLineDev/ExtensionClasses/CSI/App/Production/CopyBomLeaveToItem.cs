//PROJECT NAME: CSIProduct
//CLASS NAME: CopyBomLeaveToItem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
	public interface ICopyBomLeaveToItem
	{
		int CopyBomLeaveToItemSp(string ToCategory,
		                         string Item,
		                         string PsNum,
		                         ref string Job,
		                         ref short? Suffix,
		                         ref string Infobar);
	}
	
	public class CopyBomLeaveToItem : ICopyBomLeaveToItem
	{
		readonly IApplicationDB appDB;
		
		public CopyBomLeaveToItem(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int CopyBomLeaveToItemSp(string ToCategory,
		                                string Item,
		                                string PsNum,
		                                ref string Job,
		                                ref short? Suffix,
		                                ref string Infobar)
		{
			StringType _ToCategory = ToCategory;
			ItemType _Item = Item;
			PsNumType _PsNum = PsNum;
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CopyBomLeaveToItemSp";
				
				appDB.AddCommandParameter(cmd, "ToCategory", _ToCategory, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PsNum", _PsNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Job = _Job;
				Suffix = _Suffix;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
