//PROJECT NAME: Codes
//CLASS NAME: GenerateInvHdrProceduralMarkings.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public class GenerateInvHdrProceduralMarkings : IGenerateInvHdrProceduralMarkings
	{
		readonly IApplicationDB appDB;
		
		
		public GenerateInvHdrProceduralMarkings(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) GenerateInvHdrProceduralMarkingsSp(string InvNum,
		int? InvSeq,
		string CustNum,
		string TaxCode,
		string ApplyToInvNum = null,
		string Infobar = null)
		{
			InvNumType _InvNum = InvNum;
			ArInvSeqType _InvSeq = InvSeq;
			CustNumType _CustNum = CustNum;
			TaxCodeType _TaxCode = TaxCode;
			InvNumType _ApplyToInvNum = ApplyToInvNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GenerateInvHdrProceduralMarkingsSp";
				
				appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvSeq", _InvSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxCode", _TaxCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ApplyToInvNum", _ApplyToInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
