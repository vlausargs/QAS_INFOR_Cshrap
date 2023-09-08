//PROJECT NAME: Finance
//CLASS NAME: GlMassPostCreateTT.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class GlMassPostCreateTT : IGlMassPostCreateTT
	{
		readonly IApplicationDB appDB;
		
		
		public GlMassPostCreateTT(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) GlMassPostCreateTTSp(Guid? PSessionID,
		DateTime? PostThroughDate,
		string Infobar)
		{
			RowPointer _PSessionID = PSessionID;
			DateType _PostThroughDate = PostThroughDate;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GlMassPostCreateTTSp";
				
				appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PostThroughDate", _PostThroughDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
