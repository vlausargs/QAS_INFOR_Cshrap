//PROJECT NAME: CSIMaterial
//CLASS NAME: GetSiteParmsForItemAlls.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface IGetSiteParmsForItemAlls
	{
		(int? ReturnCode, string CurrCode, byte? EcReporting, byte? LotGenExp, byte? SerialLength) GetSiteParmsForItemAllsSP(string Site,
		string CurrCode,
		byte? EcReporting,
		byte? LotGenExp,
		byte? SerialLength);
	}
	
	public class GetSiteParmsForItemAlls : IGetSiteParmsForItemAlls
	{
		readonly IApplicationDB appDB;
		
		public GetSiteParmsForItemAlls(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string CurrCode, byte? EcReporting, byte? LotGenExp, byte? SerialLength) GetSiteParmsForItemAllsSP(string Site,
		string CurrCode,
		byte? EcReporting,
		byte? LotGenExp,
		byte? SerialLength)
		{
			SiteType _Site = Site;
			CurrCodeType _CurrCode = CurrCode;
			ListYesNoType _EcReporting = EcReporting;
			ListYesNoType _LotGenExp = LotGenExp;
			SerialLengthType _SerialLength = SerialLength;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetSiteParmsForItemAllsSP";
				
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EcReporting", _EcReporting, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LotGenExp", _LotGenExp, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SerialLength", _SerialLength, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CurrCode = _CurrCode;
				EcReporting = _EcReporting;
				LotGenExp = _LotGenExp;
				SerialLength = _SerialLength;
				
				return (Severity, CurrCode, EcReporting, LotGenExp, SerialLength);
			}
		}
	}
}
