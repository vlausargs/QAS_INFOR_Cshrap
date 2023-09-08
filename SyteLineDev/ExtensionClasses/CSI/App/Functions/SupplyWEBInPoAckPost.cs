//PROJECT NAME: Data
//CLASS NAME: SupplyWEBInPoAckPost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class SupplyWEBInPoAckPost : ISupplyWEBInPoAckPost
	{
		readonly IApplicationDB appDB;
		
		public SupplyWEBInPoAckPost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			Guid? PoRowPointer,
			int? VendorActiveForDataIntegration,
			string Infobar) SupplyWEBInPoAckPostSp(
			Guid? TmpAckPoRowPointer,
			Guid? PoRowPointer,
			int? VendorActiveForDataIntegration,
			string Infobar)
		{
			RowPointerType _TmpAckPoRowPointer = TmpAckPoRowPointer;
			RowPointerType _PoRowPointer = PoRowPointer;
			ListYesNoType _VendorActiveForDataIntegration = VendorActiveForDataIntegration;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SupplyWEBInPoAckPostSp";
				
				appDB.AddCommandParameter(cmd, "TmpAckPoRowPointer", _TmpAckPoRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoRowPointer", _PoRowPointer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VendorActiveForDataIntegration", _VendorActiveForDataIntegration, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PoRowPointer = _PoRowPointer;
				VendorActiveForDataIntegration = _VendorActiveForDataIntegration;
				Infobar = _Infobar;
				
				return (Severity, PoRowPointer, VendorActiveForDataIntegration, Infobar);
			}
		}
	}
}
