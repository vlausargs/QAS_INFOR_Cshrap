//PROJECT NAME: CSICustomer
//CLASS NAME: GetSiteGroupARAgingInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IGetSiteGroupARAgingInfo
	{
		int GetSiteGroupARAgingInfoSp(byte? PSubordinate,
		                              string PCustNum,
		                              string PSiteGroup,
		                              ref decimal? PAgeBal1,
		                              ref decimal? PAgeBal2,
		                              ref decimal? PAgeBal3,
		                              ref decimal? PAgeBal4,
		                              ref decimal? PAgeBal5,
		                              ref decimal? PAgeBal6);
	}
	
	public class GetSiteGroupARAgingInfo : IGetSiteGroupARAgingInfo
	{
		readonly IApplicationDB appDB;
		
		public GetSiteGroupARAgingInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetSiteGroupARAgingInfoSp(byte? PSubordinate,
		                                     string PCustNum,
		                                     string PSiteGroup,
		                                     ref decimal? PAgeBal1,
		                                     ref decimal? PAgeBal2,
		                                     ref decimal? PAgeBal3,
		                                     ref decimal? PAgeBal4,
		                                     ref decimal? PAgeBal5,
		                                     ref decimal? PAgeBal6)
		{
			FlagNyType _PSubordinate = PSubordinate;
			CustNumType _PCustNum = PCustNum;
			SiteGroupType _PSiteGroup = PSiteGroup;
			GenericDecimalType _PAgeBal1 = PAgeBal1;
			GenericDecimalType _PAgeBal2 = PAgeBal2;
			GenericDecimalType _PAgeBal3 = PAgeBal3;
			GenericDecimalType _PAgeBal4 = PAgeBal4;
			GenericDecimalType _PAgeBal5 = PAgeBal5;
			GenericDecimalType _PAgeBal6 = PAgeBal6;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetSiteGroupARAgingInfoSp";
				
				appDB.AddCommandParameter(cmd, "PSubordinate", _PSubordinate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSiteGroup", _PSiteGroup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAgeBal1", _PAgeBal1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAgeBal2", _PAgeBal2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAgeBal3", _PAgeBal3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAgeBal4", _PAgeBal4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAgeBal5", _PAgeBal5, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAgeBal6", _PAgeBal6, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PAgeBal1 = _PAgeBal1;
				PAgeBal2 = _PAgeBal2;
				PAgeBal3 = _PAgeBal3;
				PAgeBal4 = _PAgeBal4;
				PAgeBal5 = _PAgeBal5;
				PAgeBal6 = _PAgeBal6;
				
				return Severity;
			}
		}
	}
}
