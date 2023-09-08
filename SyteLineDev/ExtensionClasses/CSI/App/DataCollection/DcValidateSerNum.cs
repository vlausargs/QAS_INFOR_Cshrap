//PROJECT NAME: DataCollection
//CLASS NAME: DcValidateSerNum.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public class DcValidateSerNum : IDcValidateSerNum
	{
		readonly IApplicationDB appDB;
		
		
		public DcValidateSerNum(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? Completed,
		string Infobar) DcValidateSerNumSp(int? Connected,
		int? PInOut,
		string PType,
		string PWhseType,
		string PItem,
		string PLocation,
		string PLot,
		string PCurWhse,
		string PSerNum,
		decimal? PRsvdInv = 0,
		int? PDuplicate = null,
		int? Completed = null,
		string Infobar = null)
		{
			ListYesNoType _Connected = Connected;
			ListYesNoType _PInOut = PInOut;
			StringType _PType = PType;
			StringType _PWhseType = PWhseType;
			ItemType _PItem = PItem;
			LocType _PLocation = PLocation;
			LotType _PLot = PLot;
			WhseType _PCurWhse = PCurWhse;
			SerNumType _PSerNum = PSerNum;
			RsvdNumType _PRsvdInv = PRsvdInv;
			ListYesNoType _PDuplicate = PDuplicate;
			ListYesNoType _Completed = Completed;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DcValidateSerNumSp";
				
				appDB.AddCommandParameter(cmd, "Connected", _Connected, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInOut", _PInOut, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PType", _PType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PWhseType", _PWhseType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLocation", _PLocation, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLot", _PLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCurWhse", _PCurWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSerNum", _PSerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRsvdInv", _PRsvdInv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDuplicate", _PDuplicate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Completed", _Completed, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Completed = _Completed;
				Infobar = _Infobar;
				
				return (Severity, Completed, Infobar);
			}
		}
	}
}
