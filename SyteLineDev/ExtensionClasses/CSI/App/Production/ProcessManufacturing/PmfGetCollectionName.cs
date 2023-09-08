//PROJECT NAME: Production
//CLASS NAME: PmfGetCollectionName.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfGetCollectionName : IPmfGetCollectionName
	{
		readonly IApplicationDB appDB;
		
		public PmfGetCollectionName(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string PmfGetCollectionNameFn(
			string Tablename)
		{
			StringType _Tablename = Tablename;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[PmfGetCollectionName](@Tablename)";
				
				appDB.AddCommandParameter(cmd, "Tablename", _Tablename, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
