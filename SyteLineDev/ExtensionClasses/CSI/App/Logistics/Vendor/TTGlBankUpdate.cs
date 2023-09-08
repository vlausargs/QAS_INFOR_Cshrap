//PROJECT NAME: Logistics
//CLASS NAME: TTGlBankUpdate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class TTGlBankUpdate : ITTGlBankUpdate
	{
		readonly IApplicationDB appDB;
		
		
		public TTGlBankUpdate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) TTGlBankUpdateSp(Guid? PRowPointer,
		int? PProcessFlag,
		int? POverrideDate,
		string Infobar)
		{
			RowPointerType _PRowPointer = PRowPointer;
			ListYesNoType _PProcessFlag = PProcessFlag;
			ListYesNoType _POverrideDate = POverrideDate;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TTGlBankUpdateSp";
				
				appDB.AddCommandParameter(cmd, "PRowPointer", _PRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PProcessFlag", _PProcessFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POverrideDate", _POverrideDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
