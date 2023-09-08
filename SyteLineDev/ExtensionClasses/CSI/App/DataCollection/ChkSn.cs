//PROJECT NAME: CSIDataCollection
//CLASS NAME: ChkSn.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public interface IChkSn
	{
		(int? ReturnCode, string PErr, string Infobar) ChkSnSp(string PSite,
		string PSerNum,
		string PItem,
		decimal? PQtyShip,
		string PErr,
		string Infobar,
		byte? CalledFromSerialTrigger = (byte)0);
	}
	
	public class ChkSn : IChkSn
	{
		readonly IApplicationDB appDB;
		
		public ChkSn(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PErr, string Infobar) ChkSnSp(string PSite,
		string PSerNum,
		string PItem,
		decimal? PQtyShip,
		string PErr,
		string Infobar,
		byte? CalledFromSerialTrigger = (byte)0)
		{
			SiteType _PSite = PSite;
			SerNumType _PSerNum = PSerNum;
			ItemType _PItem = PItem;
			QtyUnitType _PQtyShip = PQtyShip;
			LongListType _PErr = PErr;
			InfobarType _Infobar = Infobar;
			ListYesNoType _CalledFromSerialTrigger = CalledFromSerialTrigger;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ChkSnSp";
				
				appDB.AddCommandParameter(cmd, "PSite", _PSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSerNum", _PSerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQtyShip", _PQtyShip, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PErr", _PErr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CalledFromSerialTrigger", _CalledFromSerialTrigger, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PErr = _PErr;
				Infobar = _Infobar;
				
				return (Severity, PErr, Infobar);
			}
		}
	}
}
