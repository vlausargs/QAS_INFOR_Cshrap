//PROJECT NAME: Logistics
//CLASS NAME: PostRemClearTT.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class PostRemClearTT : IPostRemClearTT
	{
		readonly IApplicationDB appDB;
		
		
		public PostRemClearTT(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) PostRemClearTTSP(Guid? PSessionID,
		int? PPrintedFlag = null,
		int? PPostedFlag = null,
		string Infobar = null)
		{
			RowPointerType _PSessionID = PSessionID;
			FlagNyType _PPrintedFlag = PPrintedFlag;
			FlagNyType _PPostedFlag = PPostedFlag;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PostRemClearTTSP";
				
				appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPrintedFlag", _PPrintedFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPostedFlag", _PPostedFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
