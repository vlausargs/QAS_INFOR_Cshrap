//PROJECT NAME: Data
//CLASS NAME: FTConvertTransTypeAtoI.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class FTConvertTransTypeAtoI : IFTConvertTransTypeAtoI
	{
		readonly IApplicationDB appDB;
		
		public FTConvertTransTypeAtoI(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? FTConvertTransTypeAtoIFn(
			string tran_type = null)
		{
			StringType _tran_type = tran_type;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[FTConvertTransTypeAtoI](@tran_type)";
				
				appDB.AddCommandParameter(cmd, "tran_type", _tran_type, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
