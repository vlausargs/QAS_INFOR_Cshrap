//PROJECT NAME: Material
//CLASS NAME: UpdatePreassignedSerial.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class UpdatePreassignedSerial : IUpdatePreassignedSerial
	{
		readonly IApplicationDB appDB;
		
		
		public UpdatePreassignedSerial(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) UpdatePreassignedSerialSp(int? Select,
		string SerNum,
		string RefType,
		string RefNum,
		int? RefLineSuf,
		int? RefRelease,
		string Item,
		string Infobar)
		{
			ListYesNoType _Select = Select;
			SerNumType _SerNum = SerNum;
			RefTypeJKOType _RefType = RefType;
			CoNumType _RefNum = RefNum;
			CoLineType _RefLineSuf = RefLineSuf;
			CoReleaseType _RefRelease = RefRelease;
			ItemType _Item = Item;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UpdatePreassignedSerialSp";
				
				appDB.AddCommandParameter(cmd, "Select", _Select, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerNum", _SerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLineSuf", _RefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefRelease", _RefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
