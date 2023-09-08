//PROJECT NAME: Finance
//CLASS NAME: ArOpenType.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.AR
{
	public class ArOpenType : IArOpenType
	{
		readonly IApplicationDB appDB;
		
		public ArOpenType(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string ArOpenTypeFn(
			string PCustNum,
			int? PCheckNum)
		{
			CustNumType _PCustNum = PCustNum;
			ArCheckNumType _PCheckNum = PCheckNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ArOpenType](@PCustNum, @PCheckNum)";
				
				appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCheckNum", _PCheckNum, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
