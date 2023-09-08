//PROJECT NAME: Finance
//CLASS NAME: THAGetAcqDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class THAGetAcqDate : ITHAGetAcqDate
	{
		readonly IApplicationDB appDB;
		
		
		public THAGetAcqDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, DateTime? AcqDate,
		int? AddOne,
		string Infobar) THAGetAcqDateSp(string FaNum,
		DateTime? AcqDate,
		int? AddOne,
		string Infobar)
		{
			FaNumType _FaNum = FaNum;
			DateType _AcqDate = AcqDate;
			IntType _AddOne = AddOne;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "THAGetAcqDateSp";
				
				appDB.AddCommandParameter(cmd, "FaNum", _FaNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcqDate", _AcqDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AddOne", _AddOne, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				AcqDate = _AcqDate;
				AddOne = _AddOne;
				Infobar = _Infobar;
				
				return (Severity, AcqDate, AddOne, Infobar);
			}
		}
	}
}
