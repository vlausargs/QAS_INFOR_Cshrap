//PROJECT NAME: Logistics
//CLASS NAME: COPromotionCodeValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class COPromotionCodeValid : ICOPromotionCodeValid
	{
		readonly IApplicationDB appDB;
		
		
		public COPromotionCodeValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) COPromotionCodeValidSp(string Slsman = null,
		string CustNum = null,
		string EndUserType = null,
		DateTime? CoOrderDate = null,
		string CurrCode = null,
		string CoNum = null,
		int? CustSeq = null,
		string CorpCust = null,
		string Infobar = null)
		{
			SlsmanType _Slsman = Slsman;
			CustNumType _CustNum = CustNum;
			EndUserTypeType _EndUserType = EndUserType;
			DateType _CoOrderDate = CoOrderDate;
			CurrCodeType _CurrCode = CurrCode;
			CoNumType _CoNum = CoNum;
			CustSeqType _CustSeq = CustSeq;
			CustNumType _CorpCust = CorpCust;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "COPromotionCodeValidSp";
				
				appDB.AddCommandParameter(cmd, "Slsman", _Slsman, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndUserType", _EndUserType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoOrderDate", _CoOrderDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CorpCust", _CorpCust, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
