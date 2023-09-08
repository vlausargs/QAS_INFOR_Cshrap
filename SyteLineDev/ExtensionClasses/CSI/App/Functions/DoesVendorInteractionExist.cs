//PROJECT NAME: Data
//CLASS NAME: DoesVendorInteractionExist.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class DoesVendorInteractionExist : IDoesVendorInteractionExist
	{
		readonly IApplicationDB appDB;
		
		public DoesVendorInteractionExist(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? DoesVendorInteractionExistFn(
			string VendNum,
			Guid? RefRowPointer,
			string RefType,
			string Type)
		{
			VendNumType _VendNum = VendNum;
			RowPointerType _RefRowPointer = RefRowPointer;
			InteractionRefTypeType _RefType = RefType;
			InteractionTypeType _Type = Type;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[DoesVendorInteractionExist](@VendNum, @RefRowPointer, @RefType, @Type)";
				
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefRowPointer", _RefRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Type", _Type, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
