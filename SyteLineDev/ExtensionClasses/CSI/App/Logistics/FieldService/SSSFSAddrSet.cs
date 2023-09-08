//PROJECT NAME: Logistics
//CLASS NAME: SSSFSAddrSet.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSAddrSet : ISSSFSAddrSet
	{
		readonly IApplicationDB appDB;
		
		public SSSFSAddrSet(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Addr1_1,
			string Addr1_2,
			string Addr1_3,
			string Addr1_4,
			string Addr1_5,
			string Addr1_6,
			string Addr1_7,
			string Addr1_8,
			string Infobar) SSSFSAddrSetSp(
			int? ContactNum,
			string CustNum,
			int? CustSeq,
			string Addr1_1,
			string Addr1_2,
			string Addr1_3,
			string Addr1_4,
			string Addr1_5,
			string Addr1_6,
			string Addr1_7,
			string Addr1_8,
			string Infobar,
			string SroContact = null)
		{
			GenericNoType _ContactNum = ContactNum;
			CustNumType _CustNum = CustNum;
			CustSeqType _CustSeq = CustSeq;
			AddressType _Addr1_1 = Addr1_1;
			NameType _Addr1_2 = Addr1_2;
			AddressType _Addr1_3 = Addr1_3;
			AddressType _Addr1_4 = Addr1_4;
			AddressType _Addr1_5 = Addr1_5;
			AddressType _Addr1_6 = Addr1_6;
			AddressType _Addr1_7 = Addr1_7;
			AddressType _Addr1_8 = Addr1_8;
			Infobar _Infobar = Infobar;
			NameType _SroContact = SroContact;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSAddrSetSp";
				
				appDB.AddCommandParameter(cmd, "ContactNum", _ContactNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr1_1", _Addr1_1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Addr1_2", _Addr1_2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Addr1_3", _Addr1_3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Addr1_4", _Addr1_4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Addr1_5", _Addr1_5, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Addr1_6", _Addr1_6, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Addr1_7", _Addr1_7, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Addr1_8", _Addr1_8, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SroContact", _SroContact, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Addr1_1 = _Addr1_1;
				Addr1_2 = _Addr1_2;
				Addr1_3 = _Addr1_3;
				Addr1_4 = _Addr1_4;
				Addr1_5 = _Addr1_5;
				Addr1_6 = _Addr1_6;
				Addr1_7 = _Addr1_7;
				Addr1_8 = _Addr1_8;
				Infobar = _Infobar;
				
				return (Severity, Addr1_1, Addr1_2, Addr1_3, Addr1_4, Addr1_5, Addr1_6, Addr1_7, Addr1_8, Infobar);
			}
		}
	}
}
