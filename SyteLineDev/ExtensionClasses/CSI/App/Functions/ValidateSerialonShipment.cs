//PROJECT NAME: Data
//CLASS NAME: ValidateSerialonShipment.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ValidateSerialonShipment : IValidateSerialonShipment
	{
		readonly IApplicationDB appDB;
		
		public ValidateSerialonShipment(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? HadAddedToShip,
			string InfoBar) ValidateSerialonShipmentSp(
			decimal? picklist,
			int? PickListRefSeq,
			string RefNum,
			int? RefLineSuf,
			int? RefRelease,
			string Serial,
			int? HadAddedToShip,
			string InfoBar)
		{
			PickListIDType _picklist = picklist;
			PickListSequenceType _PickListRefSeq = PickListRefSeq;
			CoNumType _RefNum = RefNum;
			CoLineType _RefLineSuf = RefLineSuf;
			CoReleaseType _RefRelease = RefRelease;
			SerNumType _Serial = Serial;
			ListYesNoType _HadAddedToShip = HadAddedToShip;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidateSerialonShipmentSp";
				
				appDB.AddCommandParameter(cmd, "picklist", _picklist, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PickListRefSeq", _PickListRefSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLineSuf", _RefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefRelease", _RefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Serial", _Serial, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "HadAddedToShip", _HadAddedToShip, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				HadAddedToShip = _HadAddedToShip;
				InfoBar = _InfoBar;
				
				return (Severity, HadAddedToShip, InfoBar);
			}
		}
	}
}
