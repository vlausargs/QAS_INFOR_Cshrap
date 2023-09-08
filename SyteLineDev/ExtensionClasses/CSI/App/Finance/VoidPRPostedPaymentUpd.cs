//PROJECT NAME: Finance
//CLASS NAME: VoidPRPostedPaymentUpd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class VoidPRPostedPaymentUpd : IVoidPRPostedPaymentUpd
	{
		readonly IApplicationDB appDB;
		
		
		public VoidPRPostedPaymentUpd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) VoidPRPostedPaymentUpdSp(Guid? SessionID,
		Guid? PRowPointer,
		int? PProcessFlag,
		string Infobar)
		{
			RowPointerType _SessionID = SessionID;
			RowPointerType _PRowPointer = PRowPointer;
			ListYesNoType _PProcessFlag = PProcessFlag;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "VoidPRPostedPaymentUpdSp";
				
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRowPointer", _PRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PProcessFlag", _PProcessFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
