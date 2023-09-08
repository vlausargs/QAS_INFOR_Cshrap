//PROJECT NAME: CSIProduct
//CLASS NAME: GetMaterialSequen.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public interface IGetMaterialSequen
	{
		(int? ReturnCode, short? Sequence, string Infobar) GetMaterialSequence(string Job,
		short? Suffix,
		int? OperNum,
		string Item,
		string PoNum = null,
		short? PoLine = null,
		short? PoRelease = null,
		short? Sequence = null,
		string Infobar = null);
	}
	
	public class GetMaterialSequen : IGetMaterialSequen
	{
		readonly IApplicationDB appDB;
		
		public GetMaterialSequen(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, short? Sequence, string Infobar) GetMaterialSequence(string Job,
		short? Suffix,
		int? OperNum,
		string Item,
		string PoNum = null,
		short? PoLine = null,
		short? PoRelease = null,
		short? Sequence = null,
		string Infobar = null)
		{
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			OperNumType _OperNum = OperNum;
			ItemType _Item = Item;
			PoNumType _PoNum = PoNum;
			PoLineType _PoLine = PoLine;
			PoReleaseType _PoRelease = PoRelease;
			JobmatlSequenceType _Sequence = Sequence;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetMaterialSequence";
				
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoLine", _PoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoRelease", _PoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Sequence", _Sequence, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Sequence = _Sequence;
				Infobar = _Infobar;
				
				return (Severity, Sequence, Infobar);
			}
		}
	}
}
