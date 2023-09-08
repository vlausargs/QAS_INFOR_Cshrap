//PROJECT NAME: Finance
//CLASS NAME: SSSCCIShipAuthUtil.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.CreditCard
{
	public interface ISSSCCIShipAuthUtil
	{
		(int? ReturnCode, string Infobar) SSSCCIShipAuthUtilSp(string StartOrderNum,
		string EndOrderNum,
		DateTime? StartShipDate,
		DateTime? EndShipDate,
		short? StartShipDateOffset,
		short? EndShipDateOffset,
		string StartShipVia,
		string EndShipVia,
		string GenerateReport,
		string Infobar,
		decimal? TaskId = null,
		string pSite = null);
	}
	
	public class SSSCCIShipAuthUtil : ISSSCCIShipAuthUtil
	{
		readonly IApplicationDB appDB;
		
		public SSSCCIShipAuthUtil(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) SSSCCIShipAuthUtilSp(string StartOrderNum,
		string EndOrderNum,
		DateTime? StartShipDate,
		DateTime? EndShipDate,
		short? StartShipDateOffset,
		short? EndShipDateOffset,
		string StartShipVia,
		string EndShipVia,
		string GenerateReport,
		string Infobar,
		decimal? TaskId = null,
		string pSite = null)
		{
			CoNumType _StartOrderNum = StartOrderNum;
			CoNumType _EndOrderNum = EndOrderNum;
			DateType _StartShipDate = StartShipDate;
			DateType _EndShipDate = EndShipDate;
			DateOffsetType _StartShipDateOffset = StartShipDateOffset;
			DateOffsetType _EndShipDateOffset = EndShipDateOffset;
			ShipCodeType _StartShipVia = StartShipVia;
			ShipCodeType _EndShipVia = EndShipVia;
			StringType _GenerateReport = GenerateReport;
			InfobarType _Infobar = Infobar;
			TokenType _TaskId = TaskId;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSCCIShipAuthUtilSp";
				
				appDB.AddCommandParameter(cmd, "StartOrderNum", _StartOrderNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndOrderNum", _EndOrderNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartShipDate", _StartShipDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndShipDate", _EndShipDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartShipDateOffset", _StartShipDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndShipDateOffset", _EndShipDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartShipVia", _StartShipVia, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndShipVia", _EndShipVia, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GenerateReport", _GenerateReport, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaskId", _TaskId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
