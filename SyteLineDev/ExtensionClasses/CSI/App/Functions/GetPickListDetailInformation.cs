//PROJECT NAME: Data
//CLASS NAME: GetPickListDetailInformation.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetPickListDetailInformation : IGetPickListDetailInformation
	{
		readonly IApplicationDB appDB;
		
		public GetPickListDetailInformation(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? QtyToShip,
			string InfoBar) GetPickListDetailInformationSp(
			decimal? picklist,
			string RefNum,
			int? RefLine,
			int? RefRelease,
			string fromlot,
			string fromloc,
			int? PickListRefSeq,
			decimal? PickLocQtyPicked,
			decimal? QtyToShip,
			string InfoBar)
		{
			PickListIDType _picklist = picklist;
			CoNumType _RefNum = RefNum;
			CoLineType _RefLine = RefLine;
			CoReleaseType _RefRelease = RefRelease;
			LotType _fromlot = fromlot;
			LocType _fromloc = fromloc;
			PickListSequenceType _PickListRefSeq = PickListRefSeq;
			QtyUnitType _PickLocQtyPicked = PickLocQtyPicked;
			QtyUnitType _QtyToShip = QtyToShip;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetPickListDetailInformationSp";
				
				appDB.AddCommandParameter(cmd, "picklist", _picklist, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLine", _RefLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefRelease", _RefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "fromlot", _fromlot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "fromloc", _fromloc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PickListRefSeq", _PickListRefSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PickLocQtyPicked", _PickLocQtyPicked, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyToShip", _QtyToShip, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				QtyToShip = _QtyToShip;
				InfoBar = _InfoBar;
				
				return (Severity, QtyToShip, InfoBar);
			}
		}
	}
}
