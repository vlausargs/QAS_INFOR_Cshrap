//PROJECT NAME: THLOC
//CLASS NAME: THAGetCompNameAndAddr.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.THLOC
{
	public class THAGetCompNameAndAddr : ITHAGetCompNameAndAddr
	{
		readonly IApplicationDB appDB;
		
		
		public THAGetCompNameAndAddr(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string CompName,
		string Addr1,
		string Addr2,
		string Addr3,
		string Addr4,
		string TaxRegNum,
		string Infobar,
        string BranchId) THAGetCompNameAndAddrSp(string CompName,
		string Addr1,
		string Addr2,
		string Addr3,
		string Addr4,
		string TaxRegNum,
		string Infobar,
        string BranchId)
		{
			NameType _CompName = CompName;
			AddressType _Addr1 = Addr1;
			AddressType _Addr2 = Addr2;
			AddressType _Addr3 = Addr3;
			AddressType _Addr4 = Addr4;
			TaxRegNumType _TaxRegNum = TaxRegNum;
			InfobarType _Infobar = Infobar;
            BranchIdType _BranchId = BranchId;

            using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "THAGetCompNameAndAddrSp";
				
				appDB.AddCommandParameter(cmd, "CompName", _CompName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Addr1", _Addr1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Addr2", _Addr2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Addr3", _Addr3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Addr4", _Addr4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxRegNum", _TaxRegNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "BranchId", _BranchId, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);
				
				CompName = _CompName;
				Addr1 = _Addr1;
				Addr2 = _Addr2;
				Addr3 = _Addr3;
				Addr4 = _Addr4;
				TaxRegNum = _TaxRegNum;
				Infobar = _Infobar;
                BranchId = _BranchId;

                return (Severity, CompName, Addr1, Addr2, Addr3, Addr4, TaxRegNum, Infobar, BranchId);
			}
		}
	}
}
