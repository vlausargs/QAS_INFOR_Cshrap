//PROJECT NAME: Finance
//CLASS NAME: SetCons.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public interface ISetCons
	{
		(int? ReturnCode, string Infobar) SetConsSp(string SAcct,
		string EAcct,
		DateTime? STransDate,
		DateTime? ETransDate,
		string ExOptacChartType,
		string Infobar,
		short? StartingDateOffset = null,
		short? EndingDateOffset = null);
	}
	
	public class SetCons : ISetCons
	{
		readonly IApplicationDB appDB;
		
		public SetCons(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) SetConsSp(string SAcct,
		string EAcct,
		DateTime? STransDate,
		DateTime? ETransDate,
		string ExOptacChartType,
		string Infobar,
		short? StartingDateOffset = null,
		short? EndingDateOffset = null)
		{
			AcctType _SAcct = SAcct;
			AcctType _EAcct = EAcct;
			DateType _STransDate = STransDate;
			DateType _ETransDate = ETransDate;
			StringType _ExOptacChartType = ExOptacChartType;
			InfobarType _Infobar = Infobar;
			DateOffsetType _StartingDateOffset = StartingDateOffset;
			DateOffsetType _EndingDateOffset = EndingDateOffset;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SetConsSp";
				
				appDB.AddCommandParameter(cmd, "SAcct", _SAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EAcct", _EAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "STransDate", _STransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ETransDate", _ETransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptacChartType", _ExOptacChartType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "StartingDateOffset", _StartingDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingDateOffset", _EndingDateOffset, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
