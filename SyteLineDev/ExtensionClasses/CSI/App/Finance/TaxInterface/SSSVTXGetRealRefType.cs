//PROJECT NAME: Finance
//CLASS NAME: SSSVTXGetRealRefType.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.TaxInterface
{
	public class SSSVTXGetRealRefType : ISSSVTXGetRealRefType
	{
		readonly IApplicationDB appDB;
		
		public SSSVTXGetRealRefType(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string SSSVTXGetRealRefTypeFn(
			string RefType)
		{
			VTXRefTypeType _RefType = RefType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SSSVTXGetRealRefType](@RefType)";
				
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
