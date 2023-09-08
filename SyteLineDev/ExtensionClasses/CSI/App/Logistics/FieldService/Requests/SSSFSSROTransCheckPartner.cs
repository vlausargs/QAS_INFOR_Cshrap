//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROTransCheckPartner.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSSROTransCheckPartner
	{
		(int? ReturnCode, string Dept,
		string Whse,
		byte? PartnerReimbMatl,
		byte? PartnerReimbLabor,
		string PartnerCurrCode,
		string VatLabel,
		string Infobar,
		string WorkCode,
		string MiscCode,
		string ReimbTaxCode1,
		string ReimbTaxCode2,
		string ReimbMethod,
		string WorkCodeDesc,
		string MiscCodeDesc) SSSFSSROTransCheckPartnerSp(string PartnerId,
		string Table,
		string SroNum,
		int? SroLine,
		int? SroOper,
		string Dept,
		string Whse,
		byte? PartnerReimbMatl,
		byte? PartnerReimbLabor,
		string PartnerCurrCode,
		string VatLabel,
		string Infobar,
		string WorkCode = null,
		string MiscCode = null,
		string ReimbTaxCode1 = null,
		string ReimbTaxCode2 = null,
		string ReimbMethod = null,
		string WorkCodeDesc = null,
		string MiscCodeDesc = null);
	}
	
	public class SSSFSSROTransCheckPartner : ISSSFSSROTransCheckPartner
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSROTransCheckPartner(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Dept,
		string Whse,
		byte? PartnerReimbMatl,
		byte? PartnerReimbLabor,
		string PartnerCurrCode,
		string VatLabel,
		string Infobar,
		string WorkCode,
		string MiscCode,
		string ReimbTaxCode1,
		string ReimbTaxCode2,
		string ReimbMethod,
		string WorkCodeDesc,
		string MiscCodeDesc) SSSFSSROTransCheckPartnerSp(string PartnerId,
		string Table,
		string SroNum,
		int? SroLine,
		int? SroOper,
		string Dept,
		string Whse,
		byte? PartnerReimbMatl,
		byte? PartnerReimbLabor,
		string PartnerCurrCode,
		string VatLabel,
		string Infobar,
		string WorkCode = null,
		string MiscCode = null,
		string ReimbTaxCode1 = null,
		string ReimbTaxCode2 = null,
		string ReimbMethod = null,
		string WorkCodeDesc = null,
		string MiscCodeDesc = null)
		{
			FSPartnerType _PartnerId = PartnerId;
			StringType _Table = Table;
			FSSRONumType _SroNum = SroNum;
			FSSROLineType _SroLine = SroLine;
			FSSROOperType _SroOper = SroOper;
			DeptType _Dept = Dept;
			WhseType _Whse = Whse;
			ListYesNoType _PartnerReimbMatl = PartnerReimbMatl;
			ListYesNoType _PartnerReimbLabor = PartnerReimbLabor;
			CurrCodeType _PartnerCurrCode = PartnerCurrCode;
			StringType _VatLabel = VatLabel;
			InfobarType _Infobar = Infobar;
			FSWorkCodeType _WorkCode = WorkCode;
			FSMiscCodeType _MiscCode = MiscCode;
			TaxCodeType _ReimbTaxCode1 = ReimbTaxCode1;
			TaxCodeType _ReimbTaxCode2 = ReimbTaxCode2;
			FSReimbMethodType _ReimbMethod = ReimbMethod;
			DescriptionType _WorkCodeDesc = WorkCodeDesc;
			DescriptionType _MiscCodeDesc = MiscCodeDesc;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSROTransCheckPartnerSp";
				
				appDB.AddCommandParameter(cmd, "PartnerId", _PartnerId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Table", _Table, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroNum", _SroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroLine", _SroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroOper", _SroOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Dept", _Dept, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PartnerReimbMatl", _PartnerReimbMatl, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PartnerReimbLabor", _PartnerReimbLabor, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PartnerCurrCode", _PartnerCurrCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VatLabel", _VatLabel, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "WorkCode", _WorkCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MiscCode", _MiscCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ReimbTaxCode1", _ReimbTaxCode1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ReimbTaxCode2", _ReimbTaxCode2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ReimbMethod", _ReimbMethod, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "WorkCodeDesc", _WorkCodeDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MiscCodeDesc", _MiscCodeDesc, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Dept = _Dept;
				Whse = _Whse;
				PartnerReimbMatl = _PartnerReimbMatl;
				PartnerReimbLabor = _PartnerReimbLabor;
				PartnerCurrCode = _PartnerCurrCode;
				VatLabel = _VatLabel;
				Infobar = _Infobar;
				WorkCode = _WorkCode;
				MiscCode = _MiscCode;
				ReimbTaxCode1 = _ReimbTaxCode1;
				ReimbTaxCode2 = _ReimbTaxCode2;
				ReimbMethod = _ReimbMethod;
				WorkCodeDesc = _WorkCodeDesc;
				MiscCodeDesc = _MiscCodeDesc;
				
				return (Severity, Dept, Whse, PartnerReimbMatl, PartnerReimbLabor, PartnerCurrCode, VatLabel, Infobar, WorkCode, MiscCode, ReimbTaxCode1, ReimbTaxCode2, ReimbMethod, WorkCodeDesc, MiscCodeDesc);
			}
		}
	}
}
