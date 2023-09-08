//PROJECT NAME: Production
//CLASS NAME: RSQC_PrintReceiptTag.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_PrintReceiptTag : IRSQC_PrintReceiptTag
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_PrintReceiptTag(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? RSQC_PrintReceiptTagsp(int? i_RcvrNum,
		DateTime? i_TransDate,
		string i_UserCode,
		decimal? i_TagQty,
		string i_Stat)
		{
			QCRcvrNumType _i_RcvrNum = i_RcvrNum;
			DateType _i_TransDate = i_TransDate;
			UserCodeType _i_UserCode = i_UserCode;
			QtyUnitType _i_TagQty = i_TagQty;
			QCCodeType _i_Stat = i_Stat;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_PrintReceiptTagsp";
				
				appDB.AddCommandParameter(cmd, "i_RcvrNum", _i_RcvrNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_TransDate", _i_TransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_UserCode", _i_UserCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_TagQty", _i_TagQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_Stat", _i_Stat, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
