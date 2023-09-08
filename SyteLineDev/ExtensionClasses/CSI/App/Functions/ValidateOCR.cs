//PROJECT NAME: Data
//CLASS NAME: ValidateOCR.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ValidateOCR : IValidateOCR
	{
		readonly IApplicationDB appDB;
		
		public ValidateOCR(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ValidateOCRSp(
			string StmDocumentID,
			string PartyId,
			decimal? Amount,
			string Modulus)
		{
			GenericKeyType _StmDocumentID = StmDocumentID;
			GenericKeyType _PartyId = PartyId;
			GenericFloatType _Amount = Amount;
			GenericCodeType _Modulus = Modulus;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidateOCRSp";
				
				appDB.AddCommandParameter(cmd, "StmDocumentID", _StmDocumentID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PartyId", _PartyId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Amount", _Amount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Modulus", _Modulus, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
