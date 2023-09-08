//PROJECT NAME: Data
//CLASS NAME: MaskSSN.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class MaskSSN : IMaskSSN
	{
		readonly IApplicationDB appDB;
		
		public MaskSSN(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string MaskSSNFn(
			string PSsn)
		{
			SsnType _PSsn = PSsn;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[MaskSSN](@PSsn)";
				
				appDB.AddCommandParameter(cmd, "PSsn", _PSsn, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
