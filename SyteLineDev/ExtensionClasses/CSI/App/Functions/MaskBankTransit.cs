//PROJECT NAME: Data
//CLASS NAME: MaskBankTransit.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class MaskBankTransit : IMaskBankTransit
	{
		readonly IApplicationDB appDB;
		
		public MaskBankTransit(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string MaskBankTransitFn(
			int? PTransit)
		{
			AchTransitType _PTransit = PTransit;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[MaskBankTransit](@PTransit)";
				
				appDB.AddCommandParameter(cmd, "PTransit", _PTransit, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
