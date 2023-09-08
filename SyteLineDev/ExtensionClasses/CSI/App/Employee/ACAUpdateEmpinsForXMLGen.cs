//PROJECT NAME: CSIEmployee
//CLASS NAME: ACAUpdateEmpinsForXMLGen.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public interface IACAUpdateEmpinsForXMLGen
	{
		(int? ReturnCode, int? TotalNumberOf1095, string Infobar) ACAUpdateEmpinsForXMLGenSp(string EmployeeNumStarting = null,
		string EmployeeNumEnding = null,
		DateTime? OfferDateStarting = null,
		DateTime? OfferDateEnding = null,
		byte? Corrected = null,
		string ReceiptID = null,
		short? SubmissionID = null,
		int? TotalNumberOf1095 = null,
		string Infobar = null);
	}
	
	public class ACAUpdateEmpinsForXMLGen : IACAUpdateEmpinsForXMLGen
	{
		readonly IApplicationDB appDB;
		
		public ACAUpdateEmpinsForXMLGen(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? TotalNumberOf1095, string Infobar) ACAUpdateEmpinsForXMLGenSp(string EmployeeNumStarting = null,
		string EmployeeNumEnding = null,
		DateTime? OfferDateStarting = null,
		DateTime? OfferDateEnding = null,
		byte? Corrected = null,
		string ReceiptID = null,
		short? SubmissionID = null,
		int? TotalNumberOf1095 = null,
		string Infobar = null)
		{
			EmpNumType _EmployeeNumStarting = EmployeeNumStarting;
			EmpNumType _EmployeeNumEnding = EmployeeNumEnding;
			Date4Type _OfferDateStarting = OfferDateStarting;
			Date4Type _OfferDateEnding = OfferDateEnding;
			ListYesNoType _Corrected = Corrected;
			ACAReceiptIDType _ReceiptID = ReceiptID;
			ACASubmissionIDType _SubmissionID = SubmissionID;
			IntType _TotalNumberOf1095 = TotalNumberOf1095;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ACAUpdateEmpinsForXMLGenSp";
				
				appDB.AddCommandParameter(cmd, "EmployeeNumStarting", _EmployeeNumStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmployeeNumEnding", _EmployeeNumEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OfferDateStarting", _OfferDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OfferDateEnding", _OfferDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Corrected", _Corrected, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReceiptID", _ReceiptID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SubmissionID", _SubmissionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TotalNumberOf1095", _TotalNumberOf1095, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TotalNumberOf1095 = _TotalNumberOf1095;
				Infobar = _Infobar;
				
				return (Severity, TotalNumberOf1095, Infobar);
			}
		}
	}
}
