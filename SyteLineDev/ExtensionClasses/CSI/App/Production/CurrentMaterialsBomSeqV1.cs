//PROJECT NAME: Production
//CLASS NAME: CurrentMaterialsBomSeqV1.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class CurrentMaterialsBomSeqV1 : ICurrentMaterialsBomSeqV1
	{
		readonly IApplicationDB appDB;
		
		
		public CurrentMaterialsBomSeqV1(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? BomSeq,
		string Infobar) CurrentMaterialsBomSeqV1Sp(string Job,
		int? Suffix,
		int? OperNum,
		int? Sequence,
		string ItmItem,
		int? BomSeq,
		int? AltGroup,
		string Infobar)
		{
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			OperNumType _OperNum = OperNum;
			JobmatlSequenceType _Sequence = Sequence;
			ItemType _ItmItem = ItmItem;
			EcnBomSeqType _BomSeq = BomSeq;
			JobmatlSequenceType _AltGroup = AltGroup;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CurrentMaterialsBomSeqV1Sp";
				
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Sequence", _Sequence, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItmItem", _ItmItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BomSeq", _BomSeq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AltGroup", _AltGroup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				BomSeq = _BomSeq;
				Infobar = _Infobar;
				
				return (Severity, BomSeq, Infobar);
			}
		}
	}
}
