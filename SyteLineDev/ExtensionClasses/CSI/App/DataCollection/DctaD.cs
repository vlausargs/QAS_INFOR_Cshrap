//PROJECT NAME: CSIDataCollection
//CLASS NAME: DctaD.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public interface IDctaD
	{
		(int? ReturnCode, string Infobar) DctaDSp(string Status,
		string TransType,
		string FromEmpNum,
		string ToEmpNum,
		decimal? FromTransNum,
		decimal? ToTransNum,
		DateTime? FromTransDate,
		DateTime? ToTransDate,
		DateTime? FromPostDate,
		DateTime? ToPostDate,
		string Infobar,
		short? StartingTransDateOffset = null,
		short? EndingTransDateOffset = null,
		short? StartingPostDateOffset = null,
		short? EndingPostDateOffset = null);
	}
	
	public class DctaD : IDctaD
	{
		readonly IApplicationDB appDB;
		
		public DctaD(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) DctaDSp(string Status,
		string TransType,
		string FromEmpNum,
		string ToEmpNum,
		decimal? FromTransNum,
		decimal? ToTransNum,
		DateTime? FromTransDate,
		DateTime? ToTransDate,
		DateTime? FromPostDate,
		DateTime? ToPostDate,
		string Infobar,
		short? StartingTransDateOffset = null,
		short? EndingTransDateOffset = null,
		short? StartingPostDateOffset = null,
		short? EndingPostDateOffset = null)
		{
			StringType _Status = Status;
			StringType _TransType = TransType;
			EmpNumType _FromEmpNum = FromEmpNum;
			EmpNumType _ToEmpNum = ToEmpNum;
			HugeTransNumType _FromTransNum = FromTransNum;
			HugeTransNumType _ToTransNum = ToTransNum;
			DateTimeType _FromTransDate = FromTransDate;
			DateTimeType _ToTransDate = ToTransDate;
			DateTimeType _FromPostDate = FromPostDate;
			DateTimeType _ToPostDate = ToPostDate;
			InfobarType _Infobar = Infobar;
			DateOffsetType _StartingTransDateOffset = StartingTransDateOffset;
			DateOffsetType _EndingTransDateOffset = EndingTransDateOffset;
			DateOffsetType _StartingPostDateOffset = StartingPostDateOffset;
			DateOffsetType _EndingPostDateOffset = EndingPostDateOffset;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DctaDSp";
				
				appDB.AddCommandParameter(cmd, "Status", _Status, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransType", _TransType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromEmpNum", _FromEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToEmpNum", _ToEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromTransNum", _FromTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToTransNum", _ToTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromTransDate", _FromTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToTransDate", _ToTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromPostDate", _FromPostDate, ParameterDirection.Input);
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
