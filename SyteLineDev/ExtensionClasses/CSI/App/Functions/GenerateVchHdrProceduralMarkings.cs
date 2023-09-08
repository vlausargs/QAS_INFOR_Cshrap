//PROJECT NAME: Data
//CLASS NAME: GenerateVchHdrProceduralMarkings.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GenerateVchHdrProceduralMarkings : IGenerateVchHdrProceduralMarkings
	{
		readonly IApplicationDB appDB;
		
		public GenerateVchHdrProceduralMarkings(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) GenerateVchHdrProceduralMarkingsSp(
			int? VchNum,
			int? VchSeq,
			string VendNum,
			string TaxCode,
			string Infobar = null)
		{
			VoucherType _VchNum = VchNum;
			VouchSeqType _VchSeq = VchSeq;
			VendNumType _VendNum = VendNum;
			TaxCodeType _TaxCode = TaxCode;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GenerateVchHdrProceduralMarkingsSp";
				
				appDB.AddCommandParameter(cmd, "VchNum", _VchNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VchSeq", _VchSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxCode", _TaxCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
