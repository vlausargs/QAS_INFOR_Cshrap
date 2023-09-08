//PROJECT NAME: Logistics
//CLASS NAME: THACheckWH.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class THACheckWH : ITHACheckWH
	{
		readonly IApplicationDB appDB;
		
		
		public THACheckWH(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? WithRecord,
		string Infobar) THACheckWHSp(string VendNum,
		int? CheckNum,
		int? CheckSeq,
		DateTime? CheckDate,
		int? WithRecord,
		string Infobar)
		{
			VendNumType _VendNum = VendNum;
			ApCheckNumType _CheckNum = CheckNum;
			ApCheckSeqType _CheckSeq = CheckSeq;
			DateType _CheckDate = CheckDate;
			ListYesNoType _WithRecord = WithRecord;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "THACheckWHSp";
				
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckNum", _CheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckSeq", _CheckSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckDate", _CheckDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WithRecord", _WithRecord, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				WithRecord = _WithRecord;
				Infobar = _Infobar;
				
				return (Severity, WithRecord, Infobar);
			}
		}
	}
}
