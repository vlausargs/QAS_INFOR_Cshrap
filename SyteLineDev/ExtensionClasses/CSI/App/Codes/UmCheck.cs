//PROJECT NAME: Codes
//CLASS NAME: UmCheck.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public class UmCheck : IUmCheck
	{
		readonly IApplicationDB appDB;
		
		
		public UmCheck(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) UmCheckSp(string Selection,
		string OldUM,
		string NewUM,
		string Item,
		string ConvType,
		string CustVendType,
		decimal? ConvFactor,
		decimal? ConvDivisor,
		int? RptFlag,
		string Infobar)
		{
			LongListType _Selection = Selection;
			UMType _OldUM = OldUM;
			UMType _NewUM = NewUM;
			ItemType _Item = Item;
			UMConvTypeType _ConvType = ConvType;
			VendNumType _CustVendType = CustVendType;
			UMConvFactorType _ConvFactor = ConvFactor;
			UMConvFactorType _ConvDivisor = ConvDivisor;
			ListYesNoType _RptFlag = RptFlag;
			LongListType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UmCheckSp";
				
				appDB.AddCommandParameter(cmd, "Selection", _Selection, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldUM", _OldUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewUM", _NewUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ConvType", _ConvType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustVendType", _CustVendType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ConvFactor", _ConvFactor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ConvDivisor", _ConvDivisor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RptFlag", _RptFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
