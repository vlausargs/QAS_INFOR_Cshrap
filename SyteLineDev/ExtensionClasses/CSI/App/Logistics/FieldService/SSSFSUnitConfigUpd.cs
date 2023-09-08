//PROJECT NAME: Logistics
//CLASS NAME: SSSFSUnitConfigUpd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSUnitConfigUpd : ISSSFSUnitConfigUpd
	{
		readonly IApplicationDB appDB;
		
		
		public SSSFSUnitConfigUpd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) SSSFSUnitConfigUpdSp(int? iCompID,
		string description,
		DateTime? install_date,
		string item,
		string cust_item,
		string lot,
		int? parent_id,
		string ser_num,
		decimal? qty,
		string reason,
		DateTime? remove_date,
		string revision,
		string u_m,
		string Infobar,
		string charfld1,
		string charfld2,
		string charfld3,
		DateTime? datefld,
		decimal? decifld1,
		decimal? decifld2,
		decimal? decifld3,
		int? logifld,
		string SroNum = null,
		int? SroLine = null,
		int? SroOper = null,
		int? TransNum = null)
		{
			FSCompIdType _iCompID = iCompID;
			DescriptionType _description = description;
			DateType _install_date = install_date;
			ItemType _item = item;
			CustItemType _cust_item = cust_item;
			LotType _lot = lot;
			FSCompIdType _parent_id = parent_id;
			SerNumType _ser_num = ser_num;
			QtyUnitType _qty = qty;
			ReasonCodeType _reason = reason;
			DateType _remove_date = remove_date;
			RevisionType _revision = revision;
			UMType _u_m = u_m;
			InfobarType _Infobar = Infobar;
			UserCharFldType _charfld1 = charfld1;
			UserCharFldType _charfld2 = charfld2;
			UserCharFldType _charfld3 = charfld3;
			UserDateFldType _datefld = datefld;
			UserDeciFldType _decifld1 = decifld1;
			UserDeciFldType _decifld2 = decifld2;
			UserDeciFldType _decifld3 = decifld3;
			UserLogiFldType _logifld = logifld;
			FSSRONumType _SroNum = SroNum;
			FSSROLineType _SroLine = SroLine;
			FSSROOperType _SroOper = SroOper;
			FSSROTransNumType _TransNum = TransNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSUnitConfigUpdSp";
				
				appDB.AddCommandParameter(cmd, "iCompID", _iCompID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "description", _description, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "install_date", _install_date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "item", _item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "cust_item", _cust_item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "lot", _lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "parent_id", _parent_id, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ser_num", _ser_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "qty", _qty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "reason", _reason, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "remove_date", _remove_date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "revision", _revision, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "u_m", _u_m, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "charfld1", _charfld1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "charfld2", _charfld2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "charfld3", _charfld3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "datefld", _datefld, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "decifld1", _decifld1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "decifld2", _decifld2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "decifld3", _decifld3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "logifld", _logifld, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroNum", _SroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroLine", _SroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroOper", _SroOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransNum", _TransNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
