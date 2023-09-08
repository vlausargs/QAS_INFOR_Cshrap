//PROJECT NAME: Logistics
//CLASS NAME: UpdateParmsRsvd1.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class UpdateParmsRsvd1 : IUpdateParmsRsvd1
	{
		readonly IApplicationDB appDB;
		
		
		public UpdateParmsRsvd1(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) UpdateParmsRsvd1Sp(int? CoparmsParmKey,
		int? ParmsRsvd1,
		string Infobar)
		{
			ParmKeyType _CoparmsParmKey = CoparmsParmKey;
			ListYesNoType _ParmsRsvd1 = ParmsRsvd1;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UpdateParmsRsvd1Sp";
				
				appDB.AddCommandParameter(cmd, "CoparmsParmKey", _CoparmsParmKey, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmsRsvd1", _ParmsRsvd1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
