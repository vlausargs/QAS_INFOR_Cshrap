//PROJECT NAME: CSICustomer
//CLASS NAME: ArpmtGetCurrInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IArpmtGetCurrInfo
	{
		(int? ReturnCode, string PEuroCurrCode, string PEuroAmtFormat, int? PDomPartofEuro) ArpmtGetCurrInfoSp(string PCurrCode,
		string PEuroCurrCode = null,
		string PEuroAmtFormat = null,
		int? PDomPartofEuro = null);
	}
	
	public class ArpmtGetCurrInfo : IArpmtGetCurrInfo
	{
		readonly IApplicationDB appDB;
		
		public ArpmtGetCurrInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PEuroCurrCode, string PEuroAmtFormat, int? PDomPartofEuro) ArpmtGetCurrInfoSp(string PCurrCode,
		string PEuroCurrCode = null,
		string PEuroAmtFormat = null,
		int? PDomPartofEuro = null)
		{
			CurrCodeType _PCurrCode = PCurrCode;
			CurrCodeType _PEuroCurrCode = PEuroCurrCode;
			InputMaskType _PEuroAmtFormat = PEuroAmtFormat;
			ListYesNoType _PDomPartofEuro = PDomPartofEuro;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ArpmtGetCurrInfoSp";
				
				appDB.AddCommandParameter(cmd, "PCurrCode", _PCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEuroCurrCode", _PEuroCurrCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PEuroAmtFormat", _PEuroAmtFormat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PDomPartofEuro", _PDomPartofEuro, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PEuroCurrCode = _PEuroCurrCode;
				PEuroAmtFormat = _PEuroAmtFormat;
				PDomPartofEuro = _PDomPartofEuro;
				
				return (Severity, PEuroCurrCode, PEuroAmtFormat, PDomPartofEuro);
			}
		}
	}
}
