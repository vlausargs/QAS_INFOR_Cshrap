//PROJECT NAME: Logistics
//CLASS NAME: VoucherBuilderDelete.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class VoucherBuilderDelete : IVoucherBuilderDelete
	{
		readonly IApplicationDB appDB;
		
		
		public VoucherBuilderDelete(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? VoucherBuilderDeleteSp(Guid? ProcessID,
		string Vend_Num = null)
		{
			RowPointerType _ProcessID = ProcessID;
			VendNumType _Vend_Num = Vend_Num;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "VoucherBuilderDeleteSp";
				
				appDB.AddCommandParameter(cmd, "ProcessID", _ProcessID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Vend_Num", _Vend_Num, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
