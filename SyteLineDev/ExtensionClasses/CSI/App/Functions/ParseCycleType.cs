//PROJECT NAME: Data
//CLASS NAME: ParseCycleType.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ParseCycleType : IParseCycleType
	{
		readonly IApplicationDB appDB;
		
		public ParseCycleType(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ParseCycleTypeFn(
			string CycleTypeIn,
			string CycleType)
		{
			CycleTypeType _CycleTypeIn = CycleTypeIn;
			CycleTypeType _CycleType = CycleType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ParseCycleType](@CycleTypeIn, @CycleType)";
				
				appDB.AddCommandParameter(cmd, "CycleTypeIn", _CycleTypeIn, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CycleType", _CycleType, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
