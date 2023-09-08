//PROJECT NAME: Codes
//CLASS NAME: GenerateInvDistProceduralMarkings.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public class GenerateInvDistProceduralMarkings : IGenerateInvDistProceduralMarkings
	{
		readonly IApplicationDB appDB;
		
		
		public GenerateInvDistProceduralMarkings(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) GenerateInvDistProceduralMarkingsSp(string InvNum,
		int? InvSeq,
		string Infobar = null)
		{
			InvNumType _InvNum = InvNum;
			ArInvSeqType _InvSeq = InvSeq;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GenerateInvDistProceduralMarkingsSp";
				
				appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvSeq", _InvSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
