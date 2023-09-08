//PROJECT NAME: Finance
//CLASS NAME: CHSRepAcctsReSequence.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.Chinese
{
	public class CHSRepAcctsReSequence : ICHSRepAcctsReSequence
	{
		readonly IApplicationDB appDB;
		
		
		public CHSRepAcctsReSequence(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string InfoBar) CHSRepAcctsReSequenceSp(decimal? BookKey,
		string InfoBar)
		{
			SequenceType _BookKey = BookKey;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CHSRepAcctsReSequenceSp";
				
				appDB.AddCommandParameter(cmd, "BookKey", _BookKey, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return (Severity, InfoBar);
			}
		}
	}
}
