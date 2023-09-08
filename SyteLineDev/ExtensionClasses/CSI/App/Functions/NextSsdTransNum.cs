//PROJECT NAME: Data
//CLASS NAME: NextSsdTransNum.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class NextSsdTransNum : INextSsdTransNum
	{
		readonly IApplicationDB appDB;
		
		public NextSsdTransNum(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? NextTransNum,
			string Infobar) NextSsdTransNumSp(
			decimal? NextTransNum,
			string Infobar)
		{
			MatlTransNumType _NextTransNum = NextTransNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "NextSsdTransNumSp";
				
				appDB.AddCommandParameter(cmd, "NextTransNum", _NextTransNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				NextTransNum = _NextTransNum;
				Infobar = _Infobar;
				
				return (Severity, NextTransNum, Infobar);
			}
		}
	}
}
