//PROJECT NAME: Production
//CLASS NAME: PmfGetCollectionNameBase.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfGetCollectionNameBase : IPmfGetCollectionNameBase
	{
		readonly IApplicationDB appDB;
		
		public PmfGetCollectionNameBase(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string PmfGetCollectionNameBaseFn(
			string Tablename)
		{
			StringType _Tablename = Tablename;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[PmfGetCollectionNameBase](@Tablename)";
				
				appDB.AddCommandParameter(cmd, "Tablename", _Tablename, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
