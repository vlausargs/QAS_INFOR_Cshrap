//PROJECT NAME: Logistics
//CLASS NAME: FTSLValidateSerialNumber.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSLValidateSerialNumber
	{
		(int? ReturnCode, string Infobar) FTSLValidateSerialNumberSp(string SerialNumber,
		string Job = null,
		short? Suffix = 0,
		string TransactionType = null,
		string Item = null,
		string Whse = null,
		string Loc = null,
		string Lot = null,
		string Site = null,
		string Infobar = null);
	}
	
	public class FTSLValidateSerialNumber : IFTSLValidateSerialNumber
	{
		readonly IApplicationDB appDB;
		
		public FTSLValidateSerialNumber(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) FTSLValidateSerialNumberSp(string SerialNumber,
		string Job = null,
		short? Suffix = 0,
		string TransactionType = null,
		string Item = null,
		string Whse = null,
		string Loc = null,
		string Lot = null,
		string Site = null,
		string Infobar = null)
		{
			SerNumType _SerialNumber = SerialNumber;
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			ProcessIndType _TransactionType = TransactionType;
			ItemType _Item = Item;
			WhseType _Whse = Whse;
			LocType _Loc = Loc;
			LotType _Lot = Lot;
			SiteType _Site = Site;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTSLValidateSerialNumberSp";
				
				appDB.AddCommandParameter(cmd, "SerialNumber", _SerialNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransactionType", _TransactionType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
