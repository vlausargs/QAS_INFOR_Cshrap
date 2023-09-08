//PROJECT NAME: Logistics
//CLASS NAME: SSSFSWarrExpireProcessLevel.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSWarrExpireProcessLevel : ISSSFSWarrExpireProcessLevel
	{
		readonly IApplicationDB appDB;
		
		public SSSFSWarrExpireProcessLevel(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) SSSFSWarrExpireProcessLevelSp(
			string pcust_num,
			int? pcust_seq,
			string pcust_name,
			int? pCompID,
			string pitem,
			string pDescription,
			string pSerNum,
			string pWarrCode,
			DateTime? pExpireDate,
			string beg_childItem,
			string end_ChildItem,
			DateTime? beg_warr_expire,
			DateTime? end_warr_expire,
			int? ChildCompID,
			string Infobar)
		{
			CustNumType _pcust_num = pcust_num;
			CustSeqType _pcust_seq = pcust_seq;
			NameType _pcust_name = pcust_name;
			FSCompIdType _pCompID = pCompID;
			ItemType _pitem = pitem;
			DescriptionType _pDescription = pDescription;
			SerNumType _pSerNum = pSerNum;
			FSWarrCodeType _pWarrCode = pWarrCode;
			DateType _pExpireDate = pExpireDate;
			ItemType _beg_childItem = beg_childItem;
			ItemType _end_ChildItem = end_ChildItem;
			DateType _beg_warr_expire = beg_warr_expire;
			DateType _end_warr_expire = end_warr_expire;
			FSCompIdType _ChildCompID = ChildCompID;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSWarrExpireProcessLevelSp";
				
				appDB.AddCommandParameter(cmd, "pcust_num", _pcust_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pcust_seq", _pcust_seq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pcust_name", _pcust_name, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCompID", _pCompID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pitem", _pitem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pDescription", _pDescription, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSerNum", _pSerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pWarrCode", _pWarrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pExpireDate", _pExpireDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "beg_childItem", _beg_childItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "end_ChildItem", _end_ChildItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "beg_warr_expire", _beg_warr_expire, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "end_warr_expire", _end_warr_expire, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChildCompID", _ChildCompID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
