//PROJECT NAME: Production
//CLASS NAME: RSQC_ValidateVendor.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_ValidateVendor : IRSQC_ValidateVendor
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_ValidateVendor(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Name,
		string Infobar) RSQC_ValidateVendorSp(int? ValidateVendor,
		string VendNum,
		string Name,
		string Infobar)
		{
			ListYesNoType _ValidateVendor = ValidateVendor;
			VendNumType _VendNum = VendNum;
			NameType _Name = Name;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_ValidateVendorSp";
				
				appDB.AddCommandParameter(cmd, "ValidateVendor", _ValidateVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Name", _Name, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Name = _Name;
				Infobar = _Infobar;
				
				return (Severity, Name, Infobar);
			}
		}
	}
}
