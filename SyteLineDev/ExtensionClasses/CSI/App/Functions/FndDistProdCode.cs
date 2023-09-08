//PROJECT NAME: Data
//CLASS NAME: FndDistProdCode.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class FndDistProdCode : IFndDistProdCode
	{
		readonly IApplicationDB appDB;
		
		public FndDistProdCode(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public Guid? FndDistProdCodeFn(
			string ProductCode,
			string Whse)
		{
			ProductCodeType _ProductCode = ProductCode;
			WhseType _Whse = Whse;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[FndDistProdCode](@ProductCode, @Whse)";
				
				appDB.AddCommandParameter(cmd, "ProductCode", _ProductCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<Guid?>(cmd);
				
				return Output;
			}
		}
	}
}
