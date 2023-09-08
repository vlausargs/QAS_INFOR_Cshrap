//PROJECT NAME: Finance
//CLASS NAME: GlCmprPDoProcessBk.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class GlCmprPDoProcessBk : IGlCmprPDoProcessBk
	{
		readonly IApplicationDB appDB;
		
		
		public GlCmprPDoProcessBk(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? GlCmprPDoProcessBkSp(string CompressBy,
		string CompressionLevel,
		int? AnalyticalLedger,
		DateTime? PerStart,
		DateTime? PerEnd,
		string AcctStart,
		string AcctEnd,
		string Site,
		decimal? UserId,
		string CurrentCultureName,
		decimal? BGTaskId)
		{
			LongListType _CompressBy = CompressBy;
			LongListType _CompressionLevel = CompressionLevel;
			FlagNyType _AnalyticalLedger = AnalyticalLedger;
			DateType _PerStart = PerStart;
			DateType _PerEnd = PerEnd;
			AcctType _AcctStart = AcctStart;
			AcctType _AcctEnd = AcctEnd;
			SiteType _Site = Site;
			TokenType _UserId = UserId;
			LanguageIDType _CurrentCultureName = CurrentCultureName;
			TokenType _BGTaskId = BGTaskId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GlCmprPDoProcessBkSp";
				
				appDB.AddCommandParameter(cmd, "CompressBy", _CompressBy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CompressionLevel", _CompressionLevel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AnalyticalLedger", _AnalyticalLedger, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PerStart", _PerStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PerEnd", _PerEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctStart", _AcctStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctEnd", _AcctEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UserId", _UserId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrentCultureName", _CurrentCultureName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGTaskId", _BGTaskId, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
