//PROJECT NAME: CSICustomer
//CLASS NAME: PortalQuoteTaxEstimation.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IPortalQuoteTaxEstimation
	{
		(int? ReturnCode, decimal? CoSalesTax, decimal? CoSalesTax2, string Infobar) PortalQuoteTaxEstimationSp(string CustNum,
		string CoNum,
		string CoLineList,
		string CustSeqList,
		decimal? Freight,
		decimal? CoSalesTax,
		decimal? CoSalesTax2,
		string Infobar = null);
	}
	
	public class PortalQuoteTaxEstimation : IPortalQuoteTaxEstimation
	{
		readonly IApplicationDB appDB;
		
		public PortalQuoteTaxEstimation(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? CoSalesTax, decimal? CoSalesTax2, string Infobar) PortalQuoteTaxEstimationSp(string CustNum,
		string CoNum,
		string CoLineList,
		string CustSeqList,
		decimal? Freight,
		decimal? CoSalesTax,
		decimal? CoSalesTax2,
		string Infobar = null)
		{
			CustNumType _CustNum = CustNum;
			CoNumType _CoNum = CoNum;
			StringType _CoLineList = CoLineList;
			StringType _CustSeqList = CustSeqList;
			AmountType _Freight = Freight;
			AmountType _CoSalesTax = CoSalesTax;
			AmountType _CoSalesTax2 = CoSalesTax2;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PortalQuoteTaxEstimationSp";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLineList", _CoLineList, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeqList", _CustSeqList, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Freight", _Freight, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoSalesTax", _CoSalesTax, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoSalesTax2", _CoSalesTax2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CoSalesTax = _CoSalesTax;
				CoSalesTax2 = _CoSalesTax2;
				Infobar = _Infobar;
				
				return (Severity, CoSalesTax, CoSalesTax2, Infobar);
			}
		}
	}
}
