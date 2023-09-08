//PROJECT NAME: CSIProduct
//CLASS NAME: CheckAltItemInAltGrp.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
	public interface ICheckAltItemInAltGrp
	{
		int CheckAltItemInAltGrpSp(string Job,
		                           short? Suffix,
		                           int? OperNum,
		                           short? Sequence,
		                           short? AltGroup,
		                           string ItemItem,
		                           string MatlItem,
		                           ref string Infobar);
	}
	
	public class CheckAltItemInAltGrp : ICheckAltItemInAltGrp
	{
		readonly IApplicationDB appDB;
		
		public CheckAltItemInAltGrp(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int CheckAltItemInAltGrpSp(string Job,
		                                  short? Suffix,
		                                  int? OperNum,
		                                  short? Sequence,
		                                  short? AltGroup,
		                                  string ItemItem,
		                                  string MatlItem,
		                                  ref string Infobar)
		{
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			OperNumType _OperNum = OperNum;
			JobmatlSequenceType _Sequence = Sequence;
			JobmatlSequenceType _AltGroup = AltGroup;
			ItemType _ItemItem = ItemItem;
			ItemType _MatlItem = MatlItem;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CheckAltItemInAltGrpSp";
				
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Sequence", _Sequence, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AltGroup", _AltGroup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemItem", _ItemItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatlItem", _MatlItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
