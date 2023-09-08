//PROJECT NAME: Data
//CLASS NAME: RmatSsd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class RmatSsd : IRmatSsd
	{
		readonly IApplicationDB appDB;
		
		public RmatSsd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) RmatSsdSp(
			string ParamRmaNum,
			int? ParamRmaLine,
			DateTime? ParamTransDate,
			decimal? ParamQty,
			string ParamReasonCode,
			string Infobar)
		{
			RmaNumType _ParamRmaNum = ParamRmaNum;
			RmaLineType _ParamRmaLine = ParamRmaLine;
			DateType _ParamTransDate = ParamTransDate;
			QtyUnitNoNegType _ParamQty = ParamQty;
			ReasonCodeType _ParamReasonCode = ParamReasonCode;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RmatSsdSp";
				
				appDB.AddCommandParameter(cmd, "ParamRmaNum", _ParamRmaNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParamRmaLine", _ParamRmaLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParamTransDate", _ParamTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParamQty", _ParamQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParamReasonCode", _ParamReasonCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
