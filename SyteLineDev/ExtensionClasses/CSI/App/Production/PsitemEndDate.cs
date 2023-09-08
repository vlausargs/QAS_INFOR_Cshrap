//PROJECT NAME: Production
//CLASS NAME: PsitemEndDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class PsitemEndDate : IPsitemEndDate
	{
		readonly IApplicationDB appDB;
		
		
		public PsitemEndDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, DateTime? PEndDate,
		decimal? PEndTick,
		string Infobar) PsitemEndDateSp(string PPsNum,
		string PItem,
		string PPsJob,
		DateTime? PEndDate,
		decimal? PEndTick,
		string Infobar)
		{
			PsNumType _PPsNum = PPsNum;
			ItemType _PItem = PItem;
			JobType _PPsJob = PPsJob;
			CurrentDateType _PEndDate = PEndDate;
			TicksType _PEndTick = PEndTick;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PsitemEndDateSp";
				
				appDB.AddCommandParameter(cmd, "PPsNum", _PPsNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPsJob", _PPsJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndDate", _PEndDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PEndTick", _PEndTick, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PEndDate = _PEndDate;
				PEndTick = _PEndTick;
				Infobar = _Infobar;
				
				return (Severity, PEndDate, PEndTick, Infobar);
			}
		}
	}
}
