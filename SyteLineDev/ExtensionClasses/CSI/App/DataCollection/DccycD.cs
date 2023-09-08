//PROJECT NAME: CSIDataCollection
//CLASS NAME: DccycD.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public interface IDccycD
	{
		(int? ReturnCode, string Infobar) DccycDSp(string Status,
		decimal? FromTransNum,
		decimal? ToTransNum,
		DateTime? FromTransDate,
		DateTime? ToTransDate,
		string Infobar,
		short? StartingTransDateOffset = null,
		short? EndingTransDateOffset = null);
	}
	
	public class DccycD : IDccycD
	{
		readonly IApplicationDB appDB;
		
		public DccycD(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) DccycDSp(string Status,
		decimal? FromTransNum,
		decimal? ToTransNum,
		DateTime? FromTransDate,
		DateTime? ToTransDate,
		string Infobar,
		short? StartingTransDateOffset = null,
		short? EndingTransDateOffset = null)
		{
			StringType _Status = Status;
			HugeTransNumType _FromTransNum = FromTransNum;
			HugeTransNumType _ToTransNum = ToTransNum;
			DateTimeType _FromTransDate = FromTransDate;
			DateTimeType _ToTransDate = ToTransDate;
			InfobarType _Infobar = Infobar;
			DateOffsetType _StartingTransDateOffset = StartingTransDateOffset;
			DateOffsetType _EndingTransDateOffset = EndingTransDateOffset;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DccycDSp";
				
				appDB.AddCommandParameter(cmd, "Status", _Status, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromTransNum", _FromTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToTransNum", _ToTransNum, ParameterDirection.Input);
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
