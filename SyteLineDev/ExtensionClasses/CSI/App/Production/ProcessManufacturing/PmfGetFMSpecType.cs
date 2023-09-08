//PROJECT NAME: Production
//CLASS NAME: PmfGetFMSpecType.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfGetFMSpecType : IPmfGetFMSpecType
	{
		readonly IApplicationDB appDB;
		
		public PmfGetFMSpecType(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public Guid? PmfGetFMSpecTypeFn(
			Guid? FmRp,
			int? RevType,
			int? SpecificRev)
		{
			GuidType _FmRp = FmRp;
			IntType _RevType = RevType;
			IntType _SpecificRev = SpecificRev;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[PmfGetFMSpecType](@FmRp, @RevType, @SpecificRev)";
				
				appDB.AddCommandParameter(cmd, "FmRp", _FmRp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RevType", _RevType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SpecificRev", _SpecificRev, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<Guid?>(cmd);
				
				return Output;
			}
		}
	}
}
