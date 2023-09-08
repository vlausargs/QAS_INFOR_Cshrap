//PROJECT NAME: Data
//CLASS NAME: MdayCal.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class MdayCal : IMdayCal
	{
		readonly IApplicationDB appDB;
		
		public MdayCal(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			DateTime? MdayDate,
			string Infobar) MdayCalSp(
			int? RunCalcHorizon = 1,
			DateTime? MdayDate = null,
			string Infobar = null)
		{
			ListYesNoType _RunCalcHorizon = RunCalcHorizon;
			CurrentDateType _MdayDate = MdayDate;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MdayCalSp";
				
				appDB.AddCommandParameter(cmd, "RunCalcHorizon", _RunCalcHorizon, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MdayDate", _MdayDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				MdayDate = _MdayDate;
				Infobar = _Infobar;
				
				return (Severity, MdayDate, Infobar);
			}
		}
	}
}
