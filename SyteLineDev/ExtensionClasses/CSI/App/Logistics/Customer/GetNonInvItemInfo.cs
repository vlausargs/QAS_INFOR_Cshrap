//PROJECT NAME: Logistics
//CLASS NAME: GetNonInvItemInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GetNonInvItemInfo : IGetNonInvItemInfo
	{
		readonly IApplicationDB appDB;
		
		
		public GetNonInvItemInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Description,
		string UM,
		string MatlType,
		string Revision,
		string ProductCode,
		string DrawingNum,
		string FamilyCode,
		string Buyer,
		string CommCode,
		string Origin,
		int? SubjectToNaftaRvc,
		decimal? UnitCost,
		string PrefCrit,
		int? Producer,
		string WeightUnit,
		decimal? UnitWeight,
		decimal? UnitPrice,
		int? AllowOnPickList,
		string Infobar) GetNonInvItemInfoSp(string Item,
		string Description = null,
		string UM = null,
		string MatlType = null,
		string Revision = null,
		string ProductCode = null,
		string DrawingNum = null,
		string FamilyCode = null,
		string Buyer = null,
		string CommCode = null,
		string Origin = null,
		int? SubjectToNaftaRvc = null,
		decimal? UnitCost = 0,
		string PrefCrit = null,
		int? Producer = null,
		string WeightUnit = null,
		decimal? UnitWeight = 0,
		decimal? UnitPrice = 0,
		int? AllowOnPickList = null,
		string Infobar = null,
		string CurrCode = null,
		string OrderType = null,
		string OrderKey1 = null)
		{
			ItemType _Item = Item;
			DescriptionType _Description = Description;
			UMType _UM = UM;
			MatlTypeType _MatlType = MatlType;
			RevisionType _Revision = Revision;
			ProductCodeType _ProductCode = ProductCode;
			DrawingNbrType _DrawingNum = DrawingNum;
			FamilyCodeType _FamilyCode = FamilyCode;
			UsernameType _Buyer = Buyer;
			CommodityCodeType _CommCode = CommCode;
			EcCodeType _Origin = Origin;
			ListYesNoType _SubjectToNaftaRvc = SubjectToNaftaRvc;
			CostPrcType _UnitCost = UnitCost;
			NAFTAPreferenceCriterionType _PrefCrit = PrefCrit;
			ListYesNoType _Producer = Producer;
			WeightUnitsType _WeightUnit = WeightUnit;
			WeightType _UnitWeight = UnitWeight;
			CostPrcType _UnitPrice = UnitPrice;
			ListYesNoType _AllowOnPickList = AllowOnPickList;
			Infobar _Infobar = Infobar;
			CurrCodeType _CurrCode = CurrCode;
			StringType _OrderType = OrderType;
			AnyRefNumType _OrderKey1 = OrderKey1;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetNonInvItemInfoSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MatlType", _MatlType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Revision", _Revision, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProductCode", _ProductCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DrawingNum", _DrawingNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FamilyCode", _FamilyCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Buyer", _Buyer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CommCode", _CommCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Origin", _Origin, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SubjectToNaftaRvc", _SubjectToNaftaRvc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitCost", _UnitCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrefCrit", _PrefCrit, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Producer", _Producer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "WeightUnit", _WeightUnit, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitWeight", _UnitWeight, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitPrice", _UnitPrice, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AllowOnPickList", _AllowOnPickList, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderType", _OrderType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderKey1", _OrderKey1, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Description = _Description;
				UM = _UM;
				MatlType = _MatlType;
				Revision = _Revision;
				ProductCode = _ProductCode;
				DrawingNum = _DrawingNum;
				FamilyCode = _FamilyCode;
				Buyer = _Buyer;
				CommCode = _CommCode;
				Origin = _Origin;
				SubjectToNaftaRvc = _SubjectToNaftaRvc;
				UnitCost = _UnitCost;
				PrefCrit = _PrefCrit;
				Producer = _Producer;
				WeightUnit = _WeightUnit;
				UnitWeight = _UnitWeight;
				UnitPrice = _UnitPrice;
				AllowOnPickList = _AllowOnPickList;
				Infobar = _Infobar;
				
				return (Severity, Description, UM, MatlType, Revision, ProductCode, DrawingNum, FamilyCode, Buyer, CommCode, Origin, SubjectToNaftaRvc, UnitCost, PrefCrit, Producer, WeightUnit, UnitWeight, UnitPrice, AllowOnPickList, Infobar);
			}
		}
	}
}
