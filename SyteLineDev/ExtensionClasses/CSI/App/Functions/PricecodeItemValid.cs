//PROJECT NAME: Data
//CLASS NAME: PricecodeItemValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class PricecodeItemValid : IPricecodeItemValid
	{
		readonly IApplicationDB appDB;
		
		public PricecodeItemValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string PricecodeDesc,
			string Infobar) PricecodeItemValidSp(
			string Pricecode,
			string PricecodeDesc,
			string Infobar,
			string Site = null)
		{
			PriceCodeType _Pricecode = Pricecode;
			DescriptionType _PricecodeDesc = PricecodeDesc;
			InfobarType _Infobar = Infobar;
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PricecodeItemValidSp";
				
				appDB.AddCommandParameter(cmd, "Pricecode", _Pricecode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PricecodeDesc", _PricecodeDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PricecodeDesc = _PricecodeDesc;
				Infobar = _Infobar;
				
				return (Severity, PricecodeDesc, Infobar);
			}
		}
	}
}
