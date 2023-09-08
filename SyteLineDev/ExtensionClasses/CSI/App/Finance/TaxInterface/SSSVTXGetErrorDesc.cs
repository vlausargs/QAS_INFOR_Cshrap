//PROJECT NAME: Finance
//CLASS NAME: SSSVTXGetErrorDesc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.TaxInterface
{
	public class SSSVTXGetErrorDesc : ISSSVTXGetErrorDesc
	{
		readonly IApplicationDB appDB;
		
		public SSSVTXGetErrorDesc(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string SSSVTXGetErrorDescFn(
			string pClass,
			int? pCode)
		{
			StringType _pClass = pClass;
			IntType _pCode = pCode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SSSVTXGetErrorDesc](@pClass, @pCode)";
				
				appDB.AddCommandParameter(cmd, "pClass", _pClass, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCode", _pCode, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
