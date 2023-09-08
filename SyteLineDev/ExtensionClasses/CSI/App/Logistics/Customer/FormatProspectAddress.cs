//PROJECT NAME: CSICustomer
//CLASS NAME: FormatProspectAddress.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IFormatProspectAddress
	{
		(int? ReturnCode, string ProAddress, string Infobar, string DerCurrCode, string TaxCode1, string TaxCode2) FormatProspectAddressSp(string ProspectId,
		string ProAddress,
		string Infobar,
		string DerCurrCode = null,
		string TaxCode1 = null,
		string TaxCode2 = null);

		string FormatProspectAddressFn(
			string ProspectId);
	}
	
	public class FormatProspectAddress : IFormatProspectAddress
	{
		readonly IApplicationDB appDB;
		
		public FormatProspectAddress(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string ProAddress, string Infobar, string DerCurrCode, string TaxCode1, string TaxCode2) FormatProspectAddressSp(string ProspectId,
		string ProAddress,
		string Infobar,
		string DerCurrCode = null,
		string TaxCode1 = null,
		string TaxCode2 = null)
		{
			ProspectIDType _ProspectId = ProspectId;
			LongAddress _ProAddress = ProAddress;
			Infobar _Infobar = Infobar;
			CurrCodeType _DerCurrCode = DerCurrCode;
			TaxCodeType _TaxCode1 = TaxCode1;
			TaxCodeType _TaxCode2 = TaxCode2;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FormatProspectAddressSp";
				
				appDB.AddCommandParameter(cmd, "ProspectId", _ProspectId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProAddress", _ProAddress, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DerCurrCode", _DerCurrCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode1", _TaxCode1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode2", _TaxCode2, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ProAddress = _ProAddress;
				Infobar = _Infobar;
				DerCurrCode = _DerCurrCode;
				TaxCode1 = _TaxCode1;
				TaxCode2 = _TaxCode2;
				
				return (Severity, ProAddress, Infobar, DerCurrCode, TaxCode1, TaxCode2);
			}
		}

		public string FormatProspectAddressFn(
			string ProspectId)
		{
			ProspectIDType _ProspectId = ProspectId;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[FormatProspectAddress](@ProspectId)";

				appDB.AddCommandParameter(cmd, "ProspectId", _ProspectId, ParameterDirection.Input);

				var Output = appDB.ExecuteScalar<string>(cmd);

				return Output;
			}
		}
	}
}
