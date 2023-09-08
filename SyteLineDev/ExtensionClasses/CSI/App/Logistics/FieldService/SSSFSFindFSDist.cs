//PROJECT NAME: Logistics
//CLASS NAME: SSSFSFindFSDist.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSFindFSDist : ISSSFSFindFSDist
	{
		readonly IApplicationDB appDB;
		
		public SSSFSFindFSDist(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public Guid? SSSFSFindFSDistFn(
			string ProductCode,
			string Whse)
		{
			ProductCodeType _ProductCode = ProductCode;
			WhseType _Whse = Whse;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SSSFSFindFSDist](@ProductCode, @Whse)";
				
				appDB.AddCommandParameter(cmd, "ProductCode", _ProductCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<Guid?>(cmd);
				
				return Output;
			}
		}
	}
}
