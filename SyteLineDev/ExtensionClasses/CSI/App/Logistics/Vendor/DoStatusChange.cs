//PROJECT NAME: CSIVendor
//CLASS NAME: DoStatusChange.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IDoStatusChange
	{
		int DoStatusChangeSp(byte? PCanApprove,
		                     string PReqNum,
		                     short? PReqLine,
		                     string PType,
		                     string POldStat,
		                     string PNewStat,
		                     decimal? PQtyOrdered,
		                     string PUser,
		                     ref string Infobar);
	}
	
	public class DoStatusChange : IDoStatusChange
	{
		readonly IApplicationDB appDB;
		
		public DoStatusChange(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int DoStatusChangeSp(byte? PCanApprove,
		                            string PReqNum,
		                            short? PReqLine,
		                            string PType,
		                            string POldStat,
		                            string PNewStat,
		                            decimal? PQtyOrdered,
		                            string PUser,
		                            ref string Infobar)
		{
			FlagNyType _PCanApprove = PCanApprove;
			ReqNumType _PReqNum = PReqNum;
			ReqLineType _PReqLine = PReqLine;
			LongListType _PType = PType;
			PreqitemStatusType _POldStat = POldStat;
			PreqitemStatusType _PNewStat = PNewStat;
			QtyUnitNoNegType _PQtyOrdered = PQtyOrdered;
			UsernameType _PUser = PUser;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DoStatusChangeSp";
				
				appDB.AddCommandParameter(cmd, "PCanApprove", _PCanApprove, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PReqNum", _PReqNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PReqLine", _PReqLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PType", _PType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POldStat", _POldStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNewStat", _PNewStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQtyOrdered", _PQtyOrdered, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUser", _PUser, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
