//PROJECT NAME: Codes
//CLASS NAME: ProdCodeChangeMarkup.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public interface IProdCodeChangeMarkup
	{
		int? ProdCodeChangeMarkupSp(string PProductCode,
		                            decimal? PMarkup,
		                            byte? PProceed);
	}
	
	public class ProdCodeChangeMarkup : IProdCodeChangeMarkup
	{
		readonly IApplicationDB appDB;
		
		public ProdCodeChangeMarkup(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ProdCodeChangeMarkupSp(string PProductCode,
		                                   decimal? PMarkup,
		                                   byte? PProceed)
		{
			ProductCodeType _PProductCode = PProductCode;
			MarkupType _PMarkup = PMarkup;
			ListYesNoType _PProceed = PProceed;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProdCodeChangeMarkupSp";
				
				appDB.AddCommandParameter(cmd, "PProductCode", _PProductCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PMarkup", _PMarkup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PProceed", _PProceed, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
