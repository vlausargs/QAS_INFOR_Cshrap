//PROJECT NAME: Finance
//CLASS NAME: ArpmtGetCustdrftPrintFlag.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.AR
{
	public class ArpmtGetCustdrftPrintFlag : IArpmtGetCustdrftPrintFlag
	{
		readonly IApplicationDB appDB;
		
		public ArpmtGetCustdrftPrintFlag(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ArpmtGetCustdrftPrintFlagFn(
			int? PDraftNum)
		{
			ArCheckNumType _PDraftNum = PDraftNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ArpmtGetCustdrftPrintFlag](@PDraftNum)";
				
				appDB.AddCommandParameter(cmd, "PDraftNum", _PDraftNum, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
