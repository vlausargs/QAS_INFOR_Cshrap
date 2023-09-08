//PROJECT NAME: Logistics
//CLASS NAME: ValidateInvSequence.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ValidateInvSequence : IValidateInvSequence
	{
		readonly IApplicationDB appDB;
		
		
		public ValidateInvSequence(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PStartingInvNum,
		string PEndingInvNum,
		DateTime? PStartingInvDate,
		DateTime? PEndingInvDate,
		string Infobar) ValidateInvSequenceSp(string PArtranType,
		string PInvCategory,
		string PStartingInvNum,
		string PEndingInvNum,
		DateTime? PStartingInvDate,
		DateTime? PEndingInvDate,
		string Infobar)
		{
			ArtranTypeType _PArtranType = PArtranType;
			InvCategoryType _PInvCategory = PInvCategory;
			InvNumType _PStartingInvNum = PStartingInvNum;
			InvNumType _PEndingInvNum = PEndingInvNum;
			DateTimeType _PStartingInvDate = PStartingInvDate;
			DateTimeType _PEndingInvDate = PEndingInvDate;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidateInvSequenceSp";
				
				appDB.AddCommandParameter(cmd, "PArtranType", _PArtranType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInvCategory", _PInvCategory, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingInvNum", _PStartingInvNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PEndingInvNum", _PEndingInvNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PStartingInvDate", _PStartingInvDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PEndingInvDate", _PEndingInvDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PStartingInvNum = _PStartingInvNum;
				PEndingInvNum = _PEndingInvNum;
				PStartingInvDate = _PStartingInvDate;
				PEndingInvDate = _PEndingInvDate;
				Infobar = _Infobar;
				
				return (Severity, PStartingInvNum, PEndingInvNum, PStartingInvDate, PEndingInvDate, Infobar);
			}
		}
	}
}
