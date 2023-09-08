//PROJECT NAME: Production
//CLASS NAME: PmfGetPrimaryViewName.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfGetPrimaryViewName : IPmfGetPrimaryViewName
	{
		readonly IApplicationDB appDB;
		
		public PmfGetPrimaryViewName(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string PmfGetPrimaryViewNameFn(
			string Tablename)
		{
			StringType _Tablename = Tablename;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[PmfGetPrimaryViewName](@Tablename)";
				
				appDB.AddCommandParameter(cmd, "Tablename", _Tablename, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
