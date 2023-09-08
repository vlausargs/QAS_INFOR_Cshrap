//PROJECT NAME: POS
//CLASS NAME: SSSPOSPromotionCodeValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.POS
{
	public interface ISSSPOSPromotionCodeValid
	{
		(int? ReturnCode, string Infobar) SSSPOSPromotionCodeValidSp(string Whse = null,
		string Item = null,
		string Slsman = null,
		string EndUserType = null,
		string PromotionCode = null,
		string Infobar = null,
		string CustNum = null,
		int? CustSeq = null);
	}
	
	public class SSSPOSPromotionCodeValid : ISSSPOSPromotionCodeValid
	{
		readonly IApplicationDB appDB;
		
		public SSSPOSPromotionCodeValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) SSSPOSPromotionCodeValidSp(string Whse = null,
		string Item = null,
		string Slsman = null,
		string EndUserType = null,
		string PromotionCode = null,
		string Infobar = null,
		string CustNum = null,
		int? CustSeq = null)
		{
			WhseType _Whse = Whse;
			ItemType _Item = Item;
			SlsmanType _Slsman = Slsman;
			EndUserTypeType _EndUserType = EndUserType;
			PromotionCodeType _PromotionCode = PromotionCode;
			InfobarType _Infobar = Infobar;
			CustNumType _CustNum = CustNum;
			CustSeqType _CustSeq = CustSeq;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSPOSPromotionCodeValidSp";
				
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Slsman", _Slsman, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndUserType", _EndUserType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PromotionCode", _PromotionCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
