//PROJECT NAME: Data
//CLASS NAME: SetCoNumXrefType.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class SetCoNumXrefType : ISetCoNumXrefType
	{
		readonly IApplicationDB appDB;
		
		public SetCoNumXrefType(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string SetCoNumXrefTypeFn(
			string InvNum,
			string CoNum,
			int? Rma = 0)
		{
			InvNumType _InvNum = InvNum;
			CoNumType _CoNum = CoNum;
			ListYesNoType _Rma = Rma;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SetCoNumXrefType](@InvNum, @CoNum, @Rma)";
				
				appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Rma", _Rma, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
