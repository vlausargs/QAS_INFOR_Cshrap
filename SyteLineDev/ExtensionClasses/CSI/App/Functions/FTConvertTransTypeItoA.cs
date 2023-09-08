//PROJECT NAME: Data
//CLASS NAME: FTConvertTransTypeItoA.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class FTConvertTransTypeItoA : IFTConvertTransTypeItoA
	{
		readonly IApplicationDB appDB;
		
		public FTConvertTransTypeItoA(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string FTConvertTransTypeItoAFn(
			string tran_type = null)
		{
			StringType _tran_type = tran_type;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[FTConvertTransTypeItoA](@tran_type)";
				
				appDB.AddCommandParameter(cmd, "tran_type", _tran_type, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
