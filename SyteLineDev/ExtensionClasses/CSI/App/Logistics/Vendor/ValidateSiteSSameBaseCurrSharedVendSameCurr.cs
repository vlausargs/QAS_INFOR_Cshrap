//PROJECT NAME: Logistics
//CLASS NAME: ValidateSiteSSameBaseCurrSharedVendSameCurr.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class ValidateSiteSSameBaseCurrSharedVendSameCurr : IValidateSiteSSameBaseCurrSharedVendSameCurr
	{
		readonly IApplicationDB appDB;
		
		
		public ValidateSiteSSameBaseCurrSharedVendSameCurr(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PSite,
		int? PEnableSalesTax,
		int? PEnableSalesTax2,
		string Infobar) ValidateSiteSSameBaseCurrSharedVendSameCurrSp(string PSite,
		string PVendNum,
		int? PEnableSalesTax,
		int? PEnableSalesTax2,
		string Infobar)
		{
			SiteType _PSite = PSite;
			VendNumType _PVendNum = PVendNum;
			ListYesNoType _PEnableSalesTax = PEnableSalesTax;
			ListYesNoType _PEnableSalesTax2 = PEnableSalesTax2;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidateSiteSSameBaseCurrSharedVendSameCurrSp";
				
				appDB.AddCommandParameter(cmd, "PSite", _PSite, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEnableSalesTax", _PEnableSalesTax, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PEnableSalesTax2", _PEnableSalesTax2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PSite = _PSite;
				PEnableSalesTax = _PEnableSalesTax;
				PEnableSalesTax2 = _PEnableSalesTax2;
				Infobar = _Infobar;
				
				return (Severity, PSite, PEnableSalesTax, PEnableSalesTax2, Infobar);
			}
		}
	}
}
