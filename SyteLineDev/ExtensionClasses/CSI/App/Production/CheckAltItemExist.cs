//PROJECT NAME: CSIProduct
//CLASS NAME: CheckAltItemExist.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public interface ICheckAltItemExist
	{
		(int? ReturnCode, string Infobar) CheckAltItemExistSp(string Job,
		short? Suffix,
		int? OperNum,
		short? Sequence,
		short? AltGroup,
		string ItemItem,
		string MatlItem,
		string Infobar,
		string Type = "C");
	}
	
	public class CheckAltItemExist : ICheckAltItemExist
	{
		readonly IApplicationDB appDB;
		
		public CheckAltItemExist(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) CheckAltItemExistSp(string Job,
		short? Suffix,
		int? OperNum,
		short? Sequence,
		short? AltGroup,
		string ItemItem,
		string MatlItem,
		string Infobar,
		string Type = "C")
		{
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			OperNumType _OperNum = OperNum;
			JobmatlSequenceType _Sequence = Sequence;
			JobmatlSequenceType _AltGroup = AltGroup;
			ItemType _ItemItem = ItemItem;
			ItemType _MatlItem = MatlItem;
			InfobarType _Infobar = Infobar;
			JobTypeType _Type = Type;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CheckAltItemExistSp";
				
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Sequence", _Sequence, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AltGroup", _AltGroup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemItem", _ItemItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatlItem", _MatlItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Type", _Type, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
