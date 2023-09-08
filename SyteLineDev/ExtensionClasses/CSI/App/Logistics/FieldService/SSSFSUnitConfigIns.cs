//PROJECT NAME: Logistics
//CLASS NAME: SSSFSUnitConfigIns.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSUnitConfigIns : ISSSFSUnitConfigIns
	{
		readonly IApplicationDB appDB;
		
		
		public SSSFSUnitConfigIns(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? comp_id,
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
		int? logifld) SSSFSUnitConfigInsSp(int? comp_id,
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
			FSCompIdType _comp_id = comp_id;
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
			Infobar _Infobar = Infobar;
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
				cmd.CommandText = "SSSFSUnitConfigInsSp";
				
				appDB.AddCommandParameter(cmd, "comp_id", _comp_id, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "description", _description, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "install_date", _install_date, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "item", _item, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "cust_item", _cust_item, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "lot", _lot, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "parent_id", _parent_id, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ser_num", _ser_num, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "qty", _qty, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "reason", _reason, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "remove_date", _remove_date, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "revision", _revision, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "u_m", _u_m, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "charfld1", _charfld1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "charfld2", _charfld2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "charfld3", _charfld3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "datefld", _datefld, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "decifld1", _decifld1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "decifld2", _decifld2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "decifld3", _decifld3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "logifld", _logifld, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SroNum", _SroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroLine", _SroLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroOper", _SroOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransNum", _TransNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				comp_id = _comp_id;
				description = _description;
				install_date = _install_date;
				item = _item;
				cust_item = _cust_item;
				lot = _lot;
				parent_id = _parent_id;
				ser_num = _ser_num;
				qty = _qty;
				reason = _reason;
				remove_date = _remove_date;
				revision = _revision;
				u_m = _u_m;
				Infobar = _Infobar;
				charfld1 = _charfld1;
				charfld2 = _charfld2;
				charfld3 = _charfld3;
				datefld = _datefld;
				decifld1 = _decifld1;
				decifld2 = _decifld2;
				decifld3 = _decifld3;
				logifld = _logifld;
				
				return (Severity, comp_id, description, install_date, item, cust_item, lot, parent_id, ser_num, qty, reason, remove_date, revision, u_m, Infobar, charfld1, charfld2, charfld3, datefld, decifld1, decifld2, decifld3, logifld);
			}
		}
	}
}
