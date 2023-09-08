//PROJECT NAME: Material
//CLASS NAME: GetBomSequence.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class GetBomSequence : IGetBomSequence
	{
		readonly IApplicationDB appDB;
		
		
		public GetBomSequence(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? BomSequence,
		int? Sequence,
		int? IsExistRef,
		int? AltGroupRank,
		string Infobar) GetBomSequenceSp(string Job,
		int? Suffix,
		int? OperNum,
		int? AltGroup,
		string Type,
		string ItmItem,
		int? BomSequence = null,
		int? Sequence = null,
		int? IsExistRef = null,
		int? AltGroupRank = null,
		string Infobar = null)
		{
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			OperNumType _OperNum = OperNum;
			JobmatlSequenceType _AltGroup = AltGroup;
			JobTypeType _Type = Type;
			ItemType _ItmItem = ItmItem;
			EcnBomSeqType _BomSequence = BomSequence;
			JobmatlSequenceType _Sequence = Sequence;
			ListYesNoType _IsExistRef = IsExistRef;
			JobmatlRankType _AltGroupRank = AltGroupRank;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetBomSequenceSp";
				
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AltGroup", _AltGroup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Type", _Type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItmItem", _ItmItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BomSequence", _BomSequence, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Sequence", _Sequence, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IsExistRef", _IsExistRef, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AltGroupRank", _AltGroupRank, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				BomSequence = _BomSequence;
				Sequence = _Sequence;
				IsExistRef = _IsExistRef;
				AltGroupRank = _AltGroupRank;
				Infobar = _Infobar;
				
				return (Severity, BomSequence, Sequence, IsExistRef, AltGroupRank, Infobar);
			}
		}
	}
}
