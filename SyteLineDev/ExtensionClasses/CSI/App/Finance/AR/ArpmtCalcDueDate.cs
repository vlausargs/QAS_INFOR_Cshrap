//PROJECT NAME: Finance
//CLASS NAME: ArpmtCalcDueDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.AR
{
	public class ArpmtCalcDueDate : IArpmtCalcDueDate
	{
		readonly IApplicationDB appDB;
		
		public ArpmtCalcDueDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			DateTime? PDueDate) ArpmtCalcDueDateSP(
			DateTime? PRecptDate,
			string PCustNum,
			DateTime? PDueDate)
		{
			DateType _PRecptDate = PRecptDate;
			CustNumType _PCustNum = PCustNum;
			DateType _PDueDate = PDueDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ArpmtCalcDueDateSP";
				
				appDB.AddCommandParameter(cmd, "PRecptDate", _PRecptDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDueDate", _PDueDate, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PDueDate = _PDueDate;
				
				return (Severity, PDueDate);
			}
		}
	}
}
