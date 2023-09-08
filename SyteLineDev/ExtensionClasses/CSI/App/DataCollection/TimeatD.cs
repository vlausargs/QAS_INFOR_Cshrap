//PROJECT NAME: DataCollection
//CLASS NAME: TimeatD.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public interface ITimeatD
	{
		(int? ReturnCode, string Infobar) TimeatDSp(string Status,
		string TransType,
		string FROMEmpNum,
		string ToEmpNum,
		decimal? FROMTransNum,
		decimal? ToTransNum,
		DateTime? FROMTransDate,
		DateTime? ToTransDate,
		DateTime? FROMPostDate,
		DateTime? ToPostDate,
		string Infobar,
		short? StartingTransDateOffset = null,
		short? EndingTransDateOffset = null,
		short? StartingPostDateOffset = null,
		short? EndingPostDateOffset = null);
	}
	
	public class TimeatD : ITimeatD
	{
		readonly IApplicationDB appDB;
		
		public TimeatD(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) TimeatDSp(string Status,
		string TransType,
		string FROMEmpNum,
		string ToEmpNum,
		decimal? FROMTransNum,
		decimal? ToTransNum,
		DateTime? FROMTransDate,
		DateTime? ToTransDate,
		DateTime? FROMPostDate,
		DateTime? ToPostDate,
		string Infobar,
		short? StartingTransDateOffset = null,
		short? EndingTransDateOffset = null,
		short? StartingPostDateOffset = null,
		short? EndingPostDateOffset = null)
		{
			StringType _Status = Status;
			StringType _TransType = TransType;
			EmpNumType _FROMEmpNum = FROMEmpNum;
			EmpNumType _ToEmpNum = ToEmpNum;
			HugeTransNumType _FROMTransNum = FROMTransNum;
			HugeTransNumType _ToTransNum = ToTransNum;
			DateTimeType _FROMTransDate = FROMTransDate;
			DateTimeType _ToTransDate = ToTransDate;
			DateTimeType _FROMPostDate = FROMPostDate;
			DateTimeType _ToPostDate = ToPostDate;
			InfobarType _Infobar = Infobar;
			DateOffsetType _StartingTransDateOffset = StartingTransDateOffset;
			DateOffsetType _EndingTransDateOffset = EndingTransDateOffset;
			DateOffsetType _StartingPostDateOffset = StartingPostDateOffset;
			DateOffsetType _EndingPostDateOffset = EndingPostDateOffset;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TimeatDSp";
				
				appDB.AddCommandParameter(cmd, "Status", _Status, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransType", _TransType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FROMEmpNum", _FROMEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToEmpNum", _ToEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FROMTransNum", _FROMTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToTransNum", _ToTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FROMTransDate", _FROMTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToTransDate", _ToTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FROMPostDate", _FROMPostDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToPostDate", _ToPostDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "StartingTransDateOffset", _StartingTransDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingTransDateOffset", _EndingTransDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingPostDateOffset", _StartingPostDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingPostDateOffset", _EndingPostDateOffset, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
