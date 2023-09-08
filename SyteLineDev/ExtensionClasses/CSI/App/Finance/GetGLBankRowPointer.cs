//PROJECT NAME: Finance
//CLASS NAME: GetGLBankRowPointer.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class GetGLBankRowPointer : IGetGLBankRowPointer
	{
		readonly IApplicationDB appDB;
		
		
		public GetGLBankRowPointer(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, Guid? RowPointer) GetGLBankRowPointerSp(string BankCode,
		string ReferenceNum,
		string Type,
		Guid? RowPointer)
		{
			BankCodeType _BankCode = BankCode;
			StringType _ReferenceNum = ReferenceNum;
			GlbankTypeType _Type = Type;
			RowPointerType _RowPointer = RowPointer;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetGLBankRowPointerSp";
				
				appDB.AddCommandParameter(cmd, "BankCode", _BankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReferenceNum", _ReferenceNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Type", _Type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				RowPointer = _RowPointer;
				
				return (Severity, RowPointer);
			}
		}
	}
}
