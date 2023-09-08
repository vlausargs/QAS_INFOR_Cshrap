//PROJECT NAME: Codes
//CLASS NAME: EuroPart.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public class EuroPart : IEuroPart
	{
		readonly IApplicationDB appDB;
		
		
		public EuroPart(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? PPartOfEuro) EuroPartSp(string PCurrCode,
		int? PPartOfEuro,
		string Site = null)
		{
			CurrCodeType _PCurrCode = PCurrCode;
			FlagNyType _PPartOfEuro = PPartOfEuro;
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EuroPartSp";
				
				appDB.AddCommandParameter(cmd, "PCurrCode", _PCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPartOfEuro", _PPartOfEuro, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PPartOfEuro = _PPartOfEuro;
				
				return (Severity, PPartOfEuro);
			}
		}
	}
}
