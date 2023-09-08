//PROJECT NAME: Logistics
//CLASS NAME: SSSFSConInvSubSelBillLine.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSConInvSubSelBillLine : ISSSFSConInvSubSelBillLine
	{
		readonly IApplicationDB appDB;
		
		public SSSFSConInvSubSelBillLine(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SSSFSConInvSubSelBillLineSp(
			Guid? SessionId,
			string Contract,
			int? StartContLine,
			int? EndContLine,
			DateTime? RenewByDate = null,
			string BillingFreq = "ASQBMOE",
			string CalledFromForm = null)
		{
			RowPointerType _SessionId = SessionId;
			FSContractType _Contract = Contract;
			FSContLineType _StartContLine = StartContLine;
			FSContLineType _EndContLine = EndContLine;
			DateType _RenewByDate = RenewByDate;
			InfobarType _BillingFreq = BillingFreq;
			DescriptionType _CalledFromForm = CalledFromForm;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSConInvSubSelBillLineSp";
				
				appDB.AddCommandParameter(cmd, "SessionId", _SessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Contract", _Contract, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartContLine", _StartContLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndContLine", _EndContLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RenewByDate", _RenewByDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BillingFreq", _BillingFreq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CalledFromForm", _CalledFromForm, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
