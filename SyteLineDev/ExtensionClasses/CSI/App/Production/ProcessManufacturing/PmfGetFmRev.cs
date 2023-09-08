//PROJECT NAME: Production
//CLASS NAME: PmfGetFmRev.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfGetFmRev : IPmfGetFmRev
	{
		readonly IApplicationDB appDB;
		
		public PmfGetFmRev(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public Guid? PmfGetFmRevFn(
			Guid? OrigFmRp,
			int? RevType = 0,
			int? SpecificRev = null)
		{
			GuidType _OrigFmRp = OrigFmRp;
			IntType _RevType = RevType;
			IntType _SpecificRev = SpecificRev;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[PmfGetFmRev](@OrigFmRp, @RevType, @SpecificRev)";
				
				appDB.AddCommandParameter(cmd, "OrigFmRp", _OrigFmRp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RevType", _RevType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SpecificRev", _SpecificRev, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<Guid?>(cmd);
				
				return Output;
			}
		}
	}
}
