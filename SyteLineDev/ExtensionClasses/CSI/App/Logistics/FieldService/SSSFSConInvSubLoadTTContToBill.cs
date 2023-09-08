//PROJECT NAME: Logistics
//CLASS NAME: SSSFSConInvSubLoadTTContToBill.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSConInvSubLoadTTContToBill : ISSSFSConInvSubLoadTTContToBill
	{
		readonly IApplicationDB appDB;
		
		public SSSFSConInvSubLoadTTContToBill(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SSSFSConInvSubLoadTTContToBillSp(
			Guid? SessionId,
			string Contract,
			int? ContLine,
			DateTime? RenewByDate,
			string CalledFromForm = null)
		{
			RowPointerType _SessionId = SessionId;
			FSContractType _Contract = Contract;
			FSContLineType _ContLine = ContLine;
			DateType _RenewByDate = RenewByDate;
			DescriptionType _CalledFromForm = CalledFromForm;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSConInvSubLoadTTContToBillSp";
				
				appDB.AddCommandParameter(cmd, "SessionId", _SessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Contract", _Contract, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ContLine", _ContLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RenewByDate", _RenewByDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CalledFromForm", _CalledFromForm, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
