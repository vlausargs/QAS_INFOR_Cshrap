//PROJECT NAME: DataCollection
//CLASS NAME: DcATimeat.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public class DcATimeat : IDcATimeat
	{
		readonly IApplicationDB appDB;
		
		
		public DcATimeat(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) DcATimeatSp(string TTermId,
		int? TTransType,
		string TEmpNum,
		DateTime? TDate,
		int? TTime,
		string Infobar)
		{
			DcTermIdType _TTermId = TTermId;
			DcTransNumType _TTransType = TTransType;
			EmpNumType _TEmpNum = TEmpNum;
			DateType _TDate = TDate;
			TimeSecondsType _TTime = TTime;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DcATimeatSp";
				
				appDB.AddCommandParameter(cmd, "TTermId", _TTermId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TTransType", _TTransType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TEmpNum", _TEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TDate", _TDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TTime", _TTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
