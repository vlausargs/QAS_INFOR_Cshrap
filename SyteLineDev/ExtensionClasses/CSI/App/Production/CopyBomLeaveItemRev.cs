//PROJECT NAME: CSIProduct
//CLASS NAME: CopyBomLeaveItemRev.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
	public interface ICopyBomLeaveItemRev
	{
		int CopyBomLeaveItemRevSp(string FromCategory,
		                          string Item,
		                          string ItemRev,
		                          string ItemRevPrev,
		                          ref string Job,
		                          ref short? Suffix,
		                          ref int? StartOper,
		                          ref int? EndOper,
		                          ref byte? ErrorFlag,
		                          ref string Infobar);
	}
	
	public class CopyBomLeaveItemRev : ICopyBomLeaveItemRev
	{
		readonly IApplicationDB appDB;
		
		public CopyBomLeaveItemRev(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int CopyBomLeaveItemRevSp(string FromCategory,
		                                 string Item,
		                                 string ItemRev,
		                                 string ItemRevPrev,
		                                 ref string Job,
		                                 ref short? Suffix,
		                                 ref int? StartOper,
		                                 ref int? EndOper,
		                                 ref byte? ErrorFlag,
		                                 ref string Infobar)
		{
			StringType _FromCategory = FromCategory;
			ItemType _Item = Item;
			RevisionType _ItemRev = ItemRev;
			RevisionType _ItemRevPrev = ItemRevPrev;
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			OperNumType _StartOper = StartOper;
			OperNumType _EndOper = EndOper;
			ListYesNoType _ErrorFlag = ErrorFlag;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CopyBomLeaveItemRevSp";
				
				appDB.AddCommandParameter(cmd, "FromCategory", _FromCategory, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemRev", _ItemRev, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemRevPrev", _ItemRevPrev, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "StartOper", _StartOper, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EndOper", _EndOper, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ErrorFlag", _ErrorFlag, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Job = _Job;
				Suffix = _Suffix;
				StartOper = _StartOper;
				EndOper = _EndOper;
				ErrorFlag = _ErrorFlag;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
