//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBExpenseReportLineDetail.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.BusInterface
{
	public interface ILoadESBExpenseReportLineDetail
	{
		int LoadESBExpenseReportLineDetailSp(string DerBODID,
		                                     string EmployeeID,
		                                     decimal? BaseAmount,
		                                     string ProjectReference,
		                                     string CurrCode,
		                                     string CostCenterCode,
		                                     string PersonalIndicator,
		                                     string ItemizedIndicator,
		                                     string ExpenseType,
		                                     string SpecialCode,
		                                     string PaymentType,
		                                     string PaymentMethod,
		                                     string LineNumber,
		                                     ref string Infobar);
	}
	
	public class LoadESBExpenseReportLineDetail : ILoadESBExpenseReportLineDetail
	{
		readonly IApplicationDB appDB;
		
		public LoadESBExpenseReportLineDetail(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int LoadESBExpenseReportLineDetailSp(string DerBODID,
		                                            string EmployeeID,
		                                            decimal? BaseAmount,
		                                            string ProjectReference,
		                                            string CurrCode,
		                                            string CostCenterCode,
		                                            string PersonalIndicator,
		                                            string ItemizedIndicator,
		                                            string ExpenseType,
		                                            string SpecialCode,
		                                            string PaymentType,
		                                            string PaymentMethod,
		                                            string LineNumber,
		                                            ref string Infobar)
		{
			LongListType _DerBODID = DerBODID;
			StringType _EmployeeID = EmployeeID;
			DecimalType _BaseAmount = BaseAmount;
			StringType _ProjectReference = ProjectReference;
			StringType _CurrCode = CurrCode;
			StringType _CostCenterCode = CostCenterCode;
			StringType _PersonalIndicator = PersonalIndicator;
			StringType _ItemizedIndicator = ItemizedIndicator;
			StringType _ExpenseType = ExpenseType;
			StringType _SpecialCode = SpecialCode;
			StringType _PaymentType = PaymentType;
			StringType _PaymentMethod = PaymentMethod;
			StringType _LineNumber = LineNumber;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBExpenseReportLineDetailSp";
				
				appDB.AddCommandParameter(cmd, "DerBODID", _DerBODID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmployeeID", _EmployeeID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BaseAmount", _BaseAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProjectReference", _ProjectReference, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CostCenterCode", _CostCenterCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PersonalIndicator", _PersonalIndicator, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemizedIndicator", _ItemizedIndicator, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExpenseType", _ExpenseType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SpecialCode", _SpecialCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PaymentType", _PaymentType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PaymentMethod", _PaymentMethod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LineNumber", _LineNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
