//PROJECT NAME: Finance
//CLASS NAME: CHSGetUnitCodeDesc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.Chinese
{
	public class CHSGetUnitCodeDesc : ICHSGetUnitCodeDesc
	{
		readonly IApplicationDB appDB;
		
		public CHSGetUnitCodeDesc(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string CHSGetUnitCodeDescFn(
			string PUnitCode,
			int? CodeNo)
		{
			StringType _PUnitCode = PUnitCode;
			IntType _CodeNo = CodeNo;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[CHSGetUnitCodeDesc](@PUnitCode, @CodeNo)";
				
				appDB.AddCommandParameter(cmd, "PUnitCode", _PUnitCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CodeNo", _CodeNo, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
