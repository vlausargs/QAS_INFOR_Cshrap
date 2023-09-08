//PROJECT NAME: Data
//CLASS NAME: GetInteractionRefNumber.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetInteractionRefNumber : IGetInteractionRefNumber
	{
		readonly IApplicationDB appDB;
		
		public GetInteractionRefNumber(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string GetInteractionRefNumberFn(
			string RefType,
			Guid? RefRowPointer)
		{
			InteractionRefTypeType _RefType = RefType;
			RowPointerType _RefRowPointer = RefRowPointer;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetInteractionRefNumber](@RefType, @RefRowPointer)";
				
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefRowPointer", _RefRowPointer, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
