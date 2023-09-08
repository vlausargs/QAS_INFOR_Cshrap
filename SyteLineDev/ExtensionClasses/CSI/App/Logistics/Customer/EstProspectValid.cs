//PROJECT NAME: Logistics
//CLASS NAME: EstProspectValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class EstProspectValid : IEstProspectValid
	{
		readonly IApplicationDB appDB;
		
		
		public EstProspectValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Slsman,
		string CurrCode,
		decimal? ExchRate,
		int? CurrRateIsFixed,
		string PCur0AmtFormat,
		string Infobar,
		string BillToAddress,
		string TaxCode1,
		string TaxCode2,
		string Phone) EstProspectValidSp(string ProspectId,
		string Slsman,
		string CurrCode,
		decimal? ExchRate,
		int? CurrRateIsFixed,
		string PCur0AmtFormat,
		string Infobar,
		string BillToAddress,
		string TaxCode1 = null,
		string TaxCode2 = null,
		string Phone = null)
		{
			ProspectIDType _ProspectId = ProspectId;
			SlsmanType _Slsman = Slsman;
			CurrCodeType _CurrCode = CurrCode;
			ExchRateType _ExchRate = ExchRate;
			ListYesNoType _CurrRateIsFixed = CurrRateIsFixed;
			InputMaskType _PCur0AmtFormat = PCur0AmtFormat;
			Infobar _Infobar = Infobar;
			LongAddress _BillToAddress = BillToAddress;
			TaxCodeType _TaxCode1 = TaxCode1;
			TaxCodeType _TaxCode2 = TaxCode2;
			PhoneType _Phone = Phone;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EstProspectValidSp";
				
				appDB.AddCommandParameter(cmd, "ProspectId", _ProspectId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Slsman", _Slsman, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ExchRate", _ExchRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurrRateIsFixed", _CurrRateIsFixed, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PCur0AmtFormat", _PCur0AmtFormat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BillToAddress", _BillToAddress, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode1", _TaxCode1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode2", _TaxCode2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Phone", _Phone, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Slsman = _Slsman;
				CurrCode = _CurrCode;
				ExchRate = _ExchRate;
				CurrRateIsFixed = _CurrRateIsFixed;
				PCur0AmtFormat = _PCur0AmtFormat;
				Infobar = _Infobar;
				BillToAddress = _BillToAddress;
				TaxCode1 = _TaxCode1;
				TaxCode2 = _TaxCode2;
				Phone = _Phone;
				
				return (Severity, Slsman, CurrCode, ExchRate, CurrRateIsFixed, PCur0AmtFormat, Infobar, BillToAddress, TaxCode1, TaxCode2, Phone);
			}
		}
	}
}
