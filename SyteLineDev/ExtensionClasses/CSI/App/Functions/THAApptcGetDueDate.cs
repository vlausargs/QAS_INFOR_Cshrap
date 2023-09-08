//PROJECT NAME: Data
//CLASS NAME: THAApptcGetDueDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class THAApptcGetDueDate : ITHAApptcGetDueDate
	{
		readonly IApplicationDB appDB;
		
		public THAApptcGetDueDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			DateTime? RDueDate,
			string Infobar) THAApptcGetDueDateSp(
			DateTime? PCheckDate,
			string PVendNum,
			DateTime? RDueDate,
			string Infobar)
		{
			DateType _PCheckDate = PCheckDate;
			VendNumType _PVendNum = PVendNum;
			DateType _RDueDate = RDueDate;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "THAApptcGetDueDateSp";
				
				appDB.AddCommandParameter(cmd, "PCheckDate", _PCheckDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RDueDate", _RDueDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				RDueDate = _RDueDate;
				Infobar = _Infobar;
				
				return (Severity, RDueDate, Infobar);
			}
		}
	}
}
