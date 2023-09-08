//PROJECT NAME: Logistics
//CLASS NAME: POBuilderCreate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class POBuilderCreate : IPOBuilderCreate
	{
		readonly IApplicationDB appDB;
		
		public POBuilderCreate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) POBuilderCreateSp(
			string OriginatingSite,
			Guid? ProcessID,
			string Vendor,
			DateTime? Date,
			string PoType,
			string Status,
			string CreateAs,
			int? IncludeTaxInCost,
			string BuilderPONumber,
			string TermsCode,
			string Infobar,
			int? AutoVoucher)
		{
			SiteType _OriginatingSite = OriginatingSite;
			RowPointerType _ProcessID = ProcessID;
			VendNumType _Vendor = Vendor;
			DateType _Date = Date;
			PoTypeType _PoType = PoType;
			PoStatType _Status = Status;
			StringType _CreateAs = CreateAs;
			ListYesNoType _IncludeTaxInCost = IncludeTaxInCost;
			BuilderPoNumType _BuilderPONumber = BuilderPONumber;
			TermsCodeType _TermsCode = TermsCode;
			InfobarType _Infobar = Infobar;
			ListYesNoType _AutoVoucher = AutoVoucher;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "POBuilderCreateSp";
				
				appDB.AddCommandParameter(cmd, "OriginatingSite", _OriginatingSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProcessID", _ProcessID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Vendor", _Vendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Date", _Date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoType", _PoType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Status", _Status, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CreateAs", _CreateAs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludeTaxInCost", _IncludeTaxInCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BuilderPONumber", _BuilderPONumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TermsCode", _TermsCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AutoVoucher", _AutoVoucher, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
