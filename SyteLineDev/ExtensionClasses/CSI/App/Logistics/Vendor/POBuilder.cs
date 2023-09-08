//PROJECT NAME: Logistics
//CLASS NAME: POBuilder.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class POBuilder : IPOBuilder
	{
		readonly IApplicationDB appDB;
		
		
		public POBuilder(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string BuilderPONumber,
		string Infobar) POBuilderSP(Guid? ProcessID,
		string Vendor,
		DateTime? Date,
		string POType,
		string Status,
		string CreateAs,
		int? IncludeTaxInCost,
		string TermsCode,
		string BuilderPONumber,
		string Infobar,
		int? AutoVoucher)
		{
			RowPointerType _ProcessID = ProcessID;
			VendNumType _Vendor = Vendor;
			DateType _Date = Date;
			PoTypeType _POType = POType;
			PoStatType _Status = Status;
			StringType _CreateAs = CreateAs;
			ListYesNoType _IncludeTaxInCost = IncludeTaxInCost;
			TermsCodeType _TermsCode = TermsCode;
			BuilderPoNumType _BuilderPONumber = BuilderPONumber;
			InfobarType _Infobar = Infobar;
			ListYesNoType _AutoVoucher = AutoVoucher;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "POBuilderSP";
				
				appDB.AddCommandParameter(cmd, "ProcessID", _ProcessID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Vendor", _Vendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Date", _Date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POType", _POType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Status", _Status, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CreateAs", _CreateAs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludeTaxInCost", _IncludeTaxInCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TermsCode", _TermsCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BuilderPONumber", _BuilderPONumber, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AutoVoucher", _AutoVoucher, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				BuilderPONumber = _BuilderPONumber;
				Infobar = _Infobar;
				
				return (Severity, BuilderPONumber, Infobar);
			}
		}
	}
}
