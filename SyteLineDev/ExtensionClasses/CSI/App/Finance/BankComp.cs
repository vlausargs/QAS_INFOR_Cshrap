//PROJECT NAME: CSIFinance
//CLASS NAME: BankComp.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public interface IBankComp
	{
		(int? ReturnCode, int? RNumProcessed, string Infobar) BankCompSp(string PBankCode,
		DateTime? PCompressDate,
		int? RNumProcessed,
		string Infobar,
		int? ThruDateOffset = null);
	}
	
	public class BankComp : IBankComp
	{
		readonly IApplicationDB appDB;
		
		public BankComp(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? RNumProcessed, string Infobar) BankCompSp(string PBankCode,
		DateTime? PCompressDate,
		int? RNumProcessed,
		string Infobar,
		int? ThruDateOffset = null)
		{
			BankCodeType _PBankCode = PBankCode;
			DateType _PCompressDate = PCompressDate;
			GenericNoType _RNumProcessed = RNumProcessed;
			InfobarType _Infobar = Infobar;
			DateOffsetType _ThruDateOffset = ThruDateOffset;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "BankCompSP";
				
				appDB.AddCommandParameter(cmd, "PBankCode", _PBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCompressDate", _PCompressDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RNumProcessed", _RNumProcessed, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ThruDateOffset", _ThruDateOffset, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				RNumProcessed = _RNumProcessed;
				Infobar = _Infobar;
				
				return (Severity, RNumProcessed, Infobar);
			}
		}
	}
}
