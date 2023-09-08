//PROJECT NAME: CSIDataCollection
//CLASS NAME: DcsfcD.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public interface IDcsfcD
	{
		(int? ReturnCode, string Infobar, int? PreDelCount) DcsfcDSp(string Status,
		string TransType,
		string FromEmpNum,
		string ToEmpNum,
		decimal? FromTransNum,
		decimal? ToTransNum,
		DateTime? FromTransDate,
		DateTime? ToTransDate,
		string FromWC,
		string ToWC,
		string Infobar,
		short? StartingTransDateOffset = null,
		short? EndingTransDateOffset = null,
		int? PreDelCount = null);
	}
	
	public class DcsfcD : IDcsfcD
	{
		readonly IApplicationDB appDB;
		
		public DcsfcD(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar, int? PreDelCount) DcsfcDSp(string Status,
		string TransType,
		string FromEmpNum,
		string ToEmpNum,
		decimal? FromTransNum,
		decimal? ToTransNum,
		DateTime? FromTransDate,
		DateTime? ToTransDate,
		string FromWC,
		string ToWC,
		string Infobar,
		short? StartingTransDateOffset = null,
		short? EndingTransDateOffset = null,
		int? PreDelCount = null)
		{
			StringType _Status = Status;
			StringType _TransType = TransType;
			EmpNumType _FromEmpNum = FromEmpNum;
			EmpNumType _ToEmpNum = ToEmpNum;
			HugeTransNumType _FromTransNum = FromTransNum;
			HugeTransNumType _ToTransNum = ToTransNum;
			DateTimeType _FromTransDate = FromTransDate;
			DateTimeType _ToTransDate = ToTransDate;
			WcType _FromWC = FromWC;
			WcType _ToWC = ToWC;
			InfobarType _Infobar = Infobar;
			DateOffsetType _StartingTransDateOffset = StartingTransDateOffset;
			DateOffsetType _EndingTransDateOffset = EndingTransDateOffset;
			IntType _PreDelCount = PreDelCount;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DcsfcDSp";
				
				appDB.AddCommandParameter(cmd, "Status", _Status, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransType", _TransType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromEmpNum", _FromEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToEmpNum", _ToEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromTransNum", _FromTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToTransNum", _ToTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromTransDate", _FromTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToTransDate", _ToTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromWC", _FromWC, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToWC", _ToWC, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "StartingTransDateOffset", _StartingTransDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingTransDateOffset", _EndingTransDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PreDelCount", _PreDelCount, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				PreDelCount = _PreDelCount;
				
				return (Severity, Infobar, PreDelCount);
			}
		}
	}
}
