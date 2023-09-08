//PROJECT NAME: Logistics
//CLASS NAME: PostRemVerifyPrint.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class PostRemVerifyPrint : IPostRemVerifyPrint
	{
		readonly IApplicationDB appDB;
		
		
		public PostRemVerifyPrint(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, Guid? PSessionID,
		string Infobar) PostRemVerifyPrintSP(Guid? PSessionID,
		string Infobar)
		{
			RowPointer _PSessionID = PSessionID;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PostRemVerifyPrintSP";
				
				appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PSessionID = _PSessionID;
				Infobar = _Infobar;
				
				return (Severity, PSessionID, Infobar);
			}
		}
	}
}
