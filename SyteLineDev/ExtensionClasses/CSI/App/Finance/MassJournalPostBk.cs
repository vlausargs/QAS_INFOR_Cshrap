//PROJECT NAME: Finance
//CLASS NAME: MassJournalPostBk.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class MassJournalPostBk : IMassJournalPostBk
	{
		readonly IApplicationDB appDB;
		
		
		public MassJournalPostBk(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) MassJournalPostBkSp(int? CompressJournals,
		string CompressionLevel,
		int? JournalsToPost,
		int? OverrideWarning,
		decimal? UserId,
		string CurrentCultureName,
		string Infobar)
		{
			ListYesNoType _CompressJournals = CompressJournals;
			JournalCompLevelType _CompressionLevel = CompressionLevel;
			IntType _JournalsToPost = JournalsToPost;
			IntType _OverrideWarning = OverrideWarning;
			TokenType _UserId = UserId;
			LanguageIDType _CurrentCultureName = CurrentCultureName;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MassJournalPostBkSp";
				
				appDB.AddCommandParameter(cmd, "CompressJournals", _CompressJournals, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CompressionLevel", _CompressionLevel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JournalsToPost", _JournalsToPost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OverrideWarning", _OverrideWarning, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UserId", _UserId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrentCultureName", _CurrentCultureName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
