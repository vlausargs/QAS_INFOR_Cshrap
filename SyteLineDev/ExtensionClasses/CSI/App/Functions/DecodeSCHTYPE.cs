//PROJECT NAME: Data
//CLASS NAME: DecodeSCHTYPE.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class DecodeSCHTYPE : IDecodeSCHTYPE
	{
		readonly IApplicationDB appDB;
		
		public DecodeSCHTYPE(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string DecodeSCHTYPEFn(
			int? SCHTYPE)
		{
			IntType _SCHTYPE = SCHTYPE;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[DecodeSCHTYPE](@SCHTYPE)";
				
				appDB.AddCommandParameter(cmd, "SCHTYPE", _SCHTYPE, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
