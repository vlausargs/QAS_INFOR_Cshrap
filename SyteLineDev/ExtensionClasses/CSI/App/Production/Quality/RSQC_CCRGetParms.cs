//PROJECT NAME: Production
//CLASS NAME: RSQC_CCRGetPar.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_CCRGetPar : IRSQC_CCRGetPar
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_CCRGetPar(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? CustomerReviewDays,
		int? CustomerFollowupDays,
		int? EmailEnabled,
		int? ValidateCustomer,
		int? ValidateEmployee,
		int? ValidateItem) RSQC_CCRGetParms(int? CustomerReviewDays,
		int? CustomerFollowupDays,
		int? EmailEnabled,
		int? ValidateCustomer,
		int? ValidateEmployee,
		int? ValidateItem)
		{
			IntType _CustomerReviewDays = CustomerReviewDays;
			IntType _CustomerFollowupDays = CustomerFollowupDays;
			IntType _EmailEnabled = EmailEnabled;
			ListYesNoType _ValidateCustomer = ValidateCustomer;
			ListYesNoType _ValidateEmployee = ValidateEmployee;
			ListYesNoType _ValidateItem = ValidateItem;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_CCRGetParms";
				
				appDB.AddCommandParameter(cmd, "CustomerReviewDays", _CustomerReviewDays, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CustomerFollowupDays", _CustomerFollowupDays, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EmailEnabled", _EmailEnabled, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ValidateCustomer", _ValidateCustomer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ValidateEmployee", _ValidateEmployee, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ValidateItem", _ValidateItem, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CustomerReviewDays = _CustomerReviewDays;
				CustomerFollowupDays = _CustomerFollowupDays;
				EmailEnabled = _EmailEnabled;
				ValidateCustomer = _ValidateCustomer;
				ValidateEmployee = _ValidateEmployee;
				ValidateItem = _ValidateItem;
				
				return (Severity, CustomerReviewDays, CustomerFollowupDays, EmailEnabled, ValidateCustomer, ValidateEmployee, ValidateItem);
			}
		}
	}
}
