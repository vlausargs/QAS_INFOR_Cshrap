//PROJECT NAME: CSIDataCollection
//CLASS NAME: DcwcD.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public interface IDcwcD
	{
		(int? ReturnCode, string Infobar) DcwcDSp(string Status,
		decimal? FromTransNum,
		decimal? ToTransNum,
		string FromEmpNum,
		string ToEmpNum,
		DateTime? FromTransDate,
		DateTime? ToTransDate,
		string Infobar,
		short? StartingTransDateOffset = null,
		short? EndingTransDateOffset = null);
	}
	
	public class DcwcD : IDcwcD
	{
		readonly IApplicationDB appDB;
		
		public DcwcD(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) DcwcDSp(string Status,
		decimal? FromTransNum,
		decimal? ToTransNum,
		string FromEmpNum,
		string ToEmpNum,
		DateTime? FromTransDate,
		DateTime? ToTransDate,
		string Infobar,
		short? StartingTransDateOffset = null,
		short? EndingTransDateOffset = null)
		{
			StringType _Status = Status;
			HugeTransNumType _FromTransNum = FromTransNum;
			HugeTransNumType _ToTransNum = ToTransNum;
			EmpNumType _FromEmpNum = FromEmpNum;
			EmpNumType _ToEmpNum = ToEmpNum;
			DateTimeType _FromTransDate = FromTransDate;
			DateTimeType _ToTransDate = ToTransDate;
			InfobarType _Infobar = Infobar;
			DateOffsetType _StartingTransDateOffset = StartingTransDateOffset;
			DateOffsetType _EndingTransDateOffset = EndingTransDateOffset;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DcwcDSp";
				
				appDB.AddCommandParameter(cmd, "Status", _Status, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromTransNum", _FromTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToTransNum", _ToTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromEmpNum", _FromEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToEmpNum", _ToEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromTransDate", _FromTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToTransDate", _ToTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "StartingTransDateOffset", _StartingTransDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingTransDateOffset", _EndingTransDateOffset, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
