//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROLeadPartner.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSSROLeadPartner : ISSSFSSROLeadPartner
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSROLeadPartner(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string SSSFSSROLeadPartnerFn(
			string iPartner = null,
			string iIncNum = null,
			string iCustNum = null,
			int? iCustSeq = null,
			string iSroType = null,
			string iSerNum = null,
			string iItem = null)
		{
			FSPartnerType _iPartner = iPartner;
			FSIncNumType _iIncNum = iIncNum;
			CustNumType _iCustNum = iCustNum;
			CustSeqType _iCustSeq = iCustSeq;
			FSSROTypeType _iSroType = iSroType;
			SerNumType _iSerNum = iSerNum;
			ItemType _iItem = iItem;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SSSFSSROLeadPartner](@iPartner, @iIncNum, @iCustNum, @iCustSeq, @iSroType, @iSerNum, @iItem)";
				
				appDB.AddCommandParameter(cmd, "iPartner", _iPartner, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iIncNum", _iIncNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iCustNum", _iCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iCustSeq", _iCustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSroType", _iSroType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iSerNum", _iSerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iItem", _iItem, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
