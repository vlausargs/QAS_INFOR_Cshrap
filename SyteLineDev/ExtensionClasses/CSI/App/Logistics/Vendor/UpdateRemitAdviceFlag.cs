//PROJECT NAME: Logistics
//CLASS NAME: UpdateRemitAdviceFlag.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class UpdateRemitAdviceFlag : IUpdateRemitAdviceFlag
	{
		readonly IApplicationDB appDB;
		
		
		public UpdateRemitAdviceFlag(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) UpdateRemitAdviceFlagSp(Guid? PSessionID,
		int? RemitAdvicePrintedOK = 0,
		int? ForAPCheckOrAPEft = null,
		string Infobar = null)
		{
			RowPointerType _PSessionID = PSessionID;
			ListYesNoType _RemitAdvicePrintedOK = RemitAdvicePrintedOK;
			IntType _ForAPCheckOrAPEft = ForAPCheckOrAPEft;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UpdateRemitAdviceFlagSp";
				
				appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RemitAdvicePrintedOK", _RemitAdvicePrintedOK, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ForAPCheckOrAPEft", _ForAPCheckOrAPEft, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
