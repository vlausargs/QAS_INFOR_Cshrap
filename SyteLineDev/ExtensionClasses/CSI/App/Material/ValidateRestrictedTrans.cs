//PROJECT NAME: Material
//CLASS NAME: ValidateRestrictedTrans.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class ValidateRestrictedTrans : IValidateRestrictedTrans
	{
		readonly IApplicationDB appDB;
		
		
		public ValidateRestrictedTrans(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) ValidateRestrictedTransSp(string Item = null,
		string Lot = null,
		string SerialNums = null,
		string MatlTransType = null,
		string Infobar = null,
		decimal? RefId = 0,
		string RefType = null,
		Guid? ProcessId = null,
		string Site = null)
		{
			ItemType _Item = Item;
			LotType _Lot = Lot;
			SerNumType _SerialNums = SerialNums;
			MatlTransTypeType _MatlTransType = MatlTransType;
			Infobar _Infobar = Infobar;
			DecimalType _RefId = RefId;
			StringType _RefType = RefType;
			RowPointerType _ProcessId = ProcessId;
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidateRestrictedTransSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerialNums", _SerialNums, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatlTransType", _MatlTransType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RefId", _RefId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProcessId", _ProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
