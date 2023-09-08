//PROJECT NAME: Data
//CLASS NAME: GetEFTBankCode.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetEFTBankCode : IGetEFTBankCode
	{
		readonly IApplicationDB appDB;
		
		public GetEFTBankCode(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string GetEFTBankCodeFn(
			string FileName)
		{
			OSLocationType _FileName = FileName;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetEFTBankCode](@FileName)";
				
				appDB.AddCommandParameter(cmd, "FileName", _FileName, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
