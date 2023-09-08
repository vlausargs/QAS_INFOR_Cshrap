//PROJECT NAME: Data
//CLASS NAME: DisplayedAddressWithPhoneLang.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class DisplayedAddressWithPhoneLang : IDisplayedAddressWithPhoneLang
	{
		readonly IApplicationDB appDB;
		
		public DisplayedAddressWithPhoneLang(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string DisplayedAddressWithPhoneLangSp(
			string CustNum,
			int? CustSeq,
			string MessageLanguage)
		{
			CustNumType _CustNum = CustNum;
			CustSeqType _CustSeq = CustSeq;
			MessageLanguageType _MessageLanguage = MessageLanguage;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[DisplayedAddressWithPhoneLangSp](@CustNum, @CustSeq, @MessageLanguage)";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MessageLanguage", _MessageLanguage, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
