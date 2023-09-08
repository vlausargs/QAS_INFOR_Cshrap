//PROJECT NAME: Data
//CLASS NAME: UpdateJmatlCost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class UpdateJmatlCost : IUpdateJmatlCost
	{
		readonly IApplicationDB appDB;
		
		public UpdateJmatlCost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) UpdateJmatlCostSp(
			string PReqNum,
			int? PReqLine,
			string PVendNum,
			decimal? PPlanCostConv,
			string PRefNum,
			int? PRefLineSuf,
			int? PRefRelease,
			string PItem,
			string PUM,
			string Infobar)
		{
			ReqNumType _PReqNum = PReqNum;
			ReqLineType _PReqLine = PReqLine;
			VendNumType _PVendNum = PVendNum;
			CostPrcType _PPlanCostConv = PPlanCostConv;
			CoJobProjTrnNumType _PRefNum = PRefNum;
			CoLineSuffixProjTaskTrnLineType _PRefLineSuf = PRefLineSuf;
			CoReleaseOperNumType _PRefRelease = PRefRelease;
			ItemType _PItem = PItem;
			UMType _PUM = PUM;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UpdateJmatlCostSp";
				
				appDB.AddCommandParameter(cmd, "PReqNum", _PReqNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PReqLine", _PReqLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPlanCostConv", _PPlanCostConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefNum", _PRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefLineSuf", _PRefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefRelease", _PRefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUM", _PUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
