//PROJECT NAME: BusInterface
//CLASS NAME: LoadESBShipmentSchLineCreditValidate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBShipmentSchLineCreditValidate : ILoadESBShipmentSchLineCreditValidate
	{
		readonly IApplicationDB appDB;
		
		public LoadESBShipmentSchLineCreditValidate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) LoadESBShipmentSchLineCreditValidateSp(
			string CoNum,
			decimal? CobPrice,
			decimal? CoItemQuantity,
			int? CoLine,
			int? CoItemRelease,
			string CobItem,
			string TaxCode1,
			string TaxCode2,
			string CustNum,
			string CoOrigSite,
			string Infobar)
		{
			CoNumType _CoNum = CoNum;
			CostPrcType _CobPrice = CobPrice;
			CostPrcType _CoItemQuantity = CoItemQuantity;
			CoLineType _CoLine = CoLine;
			GenericIntType _CoItemRelease = CoItemRelease;
			ItemType _CobItem = CobItem;
			TaxCodeType _TaxCode1 = TaxCode1;
			TaxCodeType _TaxCode2 = TaxCode2;
			CustNumType _CustNum = CustNum;
			SiteType _CoOrigSite = CoOrigSite;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBShipmentSchLineCreditValidateSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CobPrice", _CobPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoItemQuantity", _CoItemQuantity, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoItemRelease", _CoItemRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CobItem", _CobItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxCode1", _TaxCode1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxCode2", _TaxCode2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoOrigSite", _CoOrigSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
