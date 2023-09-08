//PROJECT NAME: Logistics
//CLASS NAME: ApPmtpVoidOne.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class ApPmtpVoidOne : IApPmtpVoidOne
	{
		readonly IApplicationDB appDB;
		
		
		public ApPmtpVoidOne(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) ApPmtpVoidOneSp(Guid? PSessionID,
		Guid? PAppmtRowPointer,
		string PPayType = null,
		string Infobar = null)
		{
			RowPointerType _PSessionID = PSessionID;
			RowPointerType _PAppmtRowPointer = PAppmtRowPointer;
			StringType _PPayType = PPayType;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApPmtpVoidOneSp";
				
				appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAppmtRowPointer", _PAppmtRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPayType", _PPayType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
