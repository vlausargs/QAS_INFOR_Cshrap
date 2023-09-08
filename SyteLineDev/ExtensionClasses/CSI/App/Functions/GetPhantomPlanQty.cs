//PROJECT NAME: Data
//CLASS NAME: GetPhantomPlanQty.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetPhantomPlanQty : IGetPhantomPlanQty
	{
		readonly IApplicationDB appDB;
		
		public GetPhantomPlanQty(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? GetPhantomPlanQtyFn(
			string PLN_Ref_Type,
			string PLN_Ref_Num,
			Guid? JobmatlRowPointer)
		{
			MrpOrderTypeType _PLN_Ref_Type = PLN_Ref_Type;
			MrpOrderType _PLN_Ref_Num = PLN_Ref_Num;
			RowPointerType _JobmatlRowPointer = JobmatlRowPointer;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetPhantomPlanQty](@PLN_Ref_Type, @PLN_Ref_Num, @JobmatlRowPointer)";
				
				appDB.AddCommandParameter(cmd, "PLN_Ref_Type", _PLN_Ref_Type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLN_Ref_Num", _PLN_Ref_Num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobmatlRowPointer", _JobmatlRowPointer, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
