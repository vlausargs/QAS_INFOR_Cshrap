//PROJECT NAME: CSIVendor
//CLASS NAME: GetApParmsOffsetAcctInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IGetApParmsOffsetAcctInfo
	{
		int GetApParmsOffsetAcctInfoSp(ref string Acct,
		                               ref string UnitCode1,
		                               ref string UnitCode2,
		                               ref string UnitCode3,
		                               ref string UnitCode4,
		                               ref string AccessUnitCode1,
		                               ref string AccessUnitCode2,
		                               ref string AccessUnitCode3,
		                               ref string AccessUnitCode4,
		                               ref string AcctDescription,
		                               ref string SiteGroup);
	}
	
	public class GetApParmsOffsetAcctInfo : IGetApParmsOffsetAcctInfo
	{
		readonly IApplicationDB appDB;
		
		public GetApParmsOffsetAcctInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetApParmsOffsetAcctInfoSp(ref string Acct,
		                                      ref string UnitCode1,
		                                      ref string UnitCode2,
		                                      ref string UnitCode3,
		                                      ref string UnitCode4,
		                                      ref string AccessUnitCode1,
		                                      ref string AccessUnitCode2,
		                                      ref string AccessUnitCode3,
		                                      ref string AccessUnitCode4,
		                                      ref string AcctDescription,
		                                      ref string SiteGroup)
		{
			AcctType _Acct = Acct;
			UnitCode1Type _UnitCode1 = UnitCode1;
			UnitCode2Type _UnitCode2 = UnitCode2;
			UnitCode1Type _UnitCode3 = UnitCode3;
			UnitCode1Type _UnitCode4 = UnitCode4;
			UnitCodeAccessType _AccessUnitCode1 = AccessUnitCode1;
			UnitCodeAccessType _AccessUnitCode2 = AccessUnitCode2;
			UnitCodeAccessType _AccessUnitCode3 = AccessUnitCode3;
			UnitCodeAccessType _AccessUnitCode4 = AccessUnitCode4;
			DescriptionType _AcctDescription = AcctDescription;
			SiteGroupType _SiteGroup = SiteGroup;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetApParmsOffsetAcctInfoSp";
				
				appDB.AddCommandParameter(cmd, "Acct", _Acct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitCode1", _UnitCode1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitCode2", _UnitCode2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitCode3", _UnitCode3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitCode4", _UnitCode4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AccessUnitCode1", _AccessUnitCode1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AccessUnitCode2", _AccessUnitCode2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AccessUnitCode3", _AccessUnitCode3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AccessUnitCode4", _AccessUnitCode4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AcctDescription", _AcctDescription, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SiteGroup", _SiteGroup, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Acct = _Acct;
				UnitCode1 = _UnitCode1;
				UnitCode2 = _UnitCode2;
				UnitCode3 = _UnitCode3;
				UnitCode4 = _UnitCode4;
				AccessUnitCode1 = _AccessUnitCode1;
				AccessUnitCode2 = _AccessUnitCode2;
				AccessUnitCode3 = _AccessUnitCode3;
				AccessUnitCode4 = _AccessUnitCode4;
				AcctDescription = _AcctDescription;
				SiteGroup = _SiteGroup;
				
				return Severity;
			}
		}
	}
}
