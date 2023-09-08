//PROJECT NAME: Data
//CLASS NAME: PhyinvExists.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class PhyinvExists : IPhyinvExists
	{
		readonly IApplicationDB appDB;
		
		public PhyinvExists(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PhyinvExistsFn(
			string Whse)
		{
			WhseType _Whse = Whse;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[PhyinvExists](@Whse)";
				
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
