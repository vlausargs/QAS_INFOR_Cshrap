//PROJECT NAME: CSIChineseFinancials
//CLASS NAME: CHSValidateTransAmount.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.Chinese
{
	public interface ICHSValidateTransAmount
	{
		(int? ReturnCode, string Infobar) CHSValidateTransAmountSp(DateTime? BegTransDate = null,
		DateTime? EndTransDate = null,
		decimal? BegTransNum = null,
		decimal? EndTransNum = null,
		string JournalId = null,
		string Infobar = null);
	}
	
	public class CHSValidateTransAmount : ICHSValidateTransAmount
	{
		readonly IApplicationDB appDB;
		
		public CHSValidateTransAmount(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) CHSValidateTransAmountSp(DateTime? BegTransDate = null,
		DateTime? EndTransDate = null,
		decimal? BegTransNum = null,
		decimal? EndTransNum = null,
		string JournalId = null,
		string Infobar = null)
		{
			DateType _BegTransDate = BegTransDate;
			DateType _EndTransDate = EndTransDate;
			MatlTransNumType _BegTransNum = BegTransNum;
			MatlTransNumType _EndTransNum = EndTransNum;
			JournalIdType _JournalId = JournalId;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CHSValidateTransAmountSp";
				
				appDB.AddCommandParameter(cmd, "BegTransDate", _BegTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndTransDate", _EndTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegTransNum", _BegTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndTransNum", _EndTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JournalId", _JournalId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
