//PROJECT NAME: Logistics
//CLASS NAME: PoitemInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class PoitemInfo : IPoitemInfo
	{
		readonly IApplicationDB appDB;
		
		
		public PoitemInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string OutItem,
		string OutItemDesc,
		string OutUM,
		decimal? QtyShipped) PoitemInfoSp(string PoNum,
		int? PoLine,
		int? PoRelease,
		string OutItem,
		string OutItemDesc,
		string OutUM,
		decimal? QtyShipped)
		{
			PoNumType _PoNum = PoNum;
			PoLineType _PoLine = PoLine;
			PoReleaseType _PoRelease = PoRelease;
			ItemType _OutItem = OutItem;
			DescriptionType _OutItemDesc = OutItemDesc;
			UMType _OutUM = OutUM;
			QtyUnitType _QtyShipped = QtyShipped;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PoitemInfoSp";
				
				appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoLine", _PoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoRelease", _PoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OutItem", _OutItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OutItemDesc", _OutItemDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OutUM", _OutUM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyShipped", _QtyShipped, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				OutItem = _OutItem;
				OutItemDesc = _OutItemDesc;
				OutUM = _OutUM;
				QtyShipped = _QtyShipped;
				
				return (Severity, OutItem, OutItemDesc, OutUM, QtyShipped);
			}
		}
	}
}
