//PROJECT NAME: CSICustomer
//CLASS NAME: ILogDel.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IILogDel
	{
		(int? ReturnCode, string Infobar) ILogDelSp(DateTime? StartingDate,
		DateTime? EndingDate,
		string StartingRma,
		string EndingRma,
		short? StartingLine,
		short? EndingLine,
		byte? CreateInitRmaLog = (byte)0,
		string Infobar = null,
		short? StartingActivityDateOffset = null,
		short? EndingActivityDateOffset = null);
	}
	
	public class ILogDel : IILogDel
	{
		IApplicationDB appDB;
		
		public ILogDel(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) ILogDelSp(DateTime? StartingDate,
		DateTime? EndingDate,
		string StartingRma,
		string EndingRma,
		short? StartingLine,
		short? EndingLine,
		byte? CreateInitRmaLog = (byte)0,
		string Infobar = null,
		short? StartingActivityDateOffset = null,
		short? EndingActivityDateOffset = null)
		{
			DateType _StartingDate = StartingDate;
			DateType _EndingDate = EndingDate;
			RmaNumType _StartingRma = StartingRma;
			RmaNumType _EndingRma = EndingRma;
			RmaLineType _StartingLine = StartingLine;
			RmaLineType _EndingLine = EndingLine;
			ListYesNoType _CreateInitRmaLog = CreateInitRmaLog;
			InfobarType _Infobar = Infobar;
			DateOffsetType _StartingActivityDateOffset = StartingActivityDateOffset;
			DateOffsetType _EndingActivityDateOffset = EndingActivityDateOffset;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ILogDelSp";
				
				appDB.AddCommandParameter(cmd, "StartingDate", _StartingDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingDate", _EndingDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingRma", _StartingRma, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingRma", _EndingRma, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingLine", _StartingLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingLine", _EndingLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CreateInitRmaLog", _CreateInitRmaLog, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "StartingActivityDateOffset", _StartingActivityDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingActivityDateOffset", _EndingActivityDateOffset, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
