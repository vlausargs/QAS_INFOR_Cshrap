//PROJECT NAME: CSIVendor
//CLASS NAME: GetAPAgingInfoBySiteGroup.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IGetAPAgingInfoBySiteGroup
	{
		int GetAPAgingInfoBySiteGroupSp(string PVendNum,
		                                string PCurrCode,
		                                byte? PTransDom,
		                                byte? PSiteQuery,
		                                string PSiteGroup,
		                                ref string PAgeDesc1,
		                                ref string PAgeDesc2,
		                                ref string PAgeDesc3,
		                                ref string PAgeDesc4,
		                                ref string PAgeDesc5,
		                                ref decimal? PAgeBal1,
		                                ref decimal? PAgeBal2,
		                                ref decimal? PAgeBal3,
		                                ref decimal? PAgeBal4,
		                                ref decimal? PAgeBal5,
		                                ref decimal? PAgeBal6,
		                                ref string Infobar);
	}
	
	public class GetAPAgingInfoBySiteGroup : IGetAPAgingInfoBySiteGroup
	{
		readonly IApplicationDB appDB;
		
		public GetAPAgingInfoBySiteGroup(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetAPAgingInfoBySiteGroupSp(string PVendNum,
		                                       string PCurrCode,
		                                       byte? PTransDom,
		                                       byte? PSiteQuery,
		                                       string PSiteGroup,
		                                       ref string PAgeDesc1,
		                                       ref string PAgeDesc2,
		                                       ref string PAgeDesc3,
		                                       ref string PAgeDesc4,
		                                       ref string PAgeDesc5,
		                                       ref decimal? PAgeBal1,
		                                       ref decimal? PAgeBal2,
		                                       ref decimal? PAgeBal3,
		                                       ref decimal? PAgeBal4,
		                                       ref decimal? PAgeBal5,
		                                       ref decimal? PAgeBal6,
		                                       ref string Infobar)
		{
			VendNumType _PVendNum = PVendNum;
			CurrCodeType _PCurrCode = PCurrCode;
			FlagNyType _PTransDom = PTransDom;
			FlagNyType _PSiteQuery = PSiteQuery;
			SiteGroupType _PSiteGroup = PSiteGroup;
			LongListType _PAgeDesc1 = PAgeDesc1;
			LongListType _PAgeDesc2 = PAgeDesc2;
			LongListType _PAgeDesc3 = PAgeDesc3;
			LongListType _PAgeDesc4 = PAgeDesc4;
			LongListType _PAgeDesc5 = PAgeDesc5;
			GenericDecimalType _PAgeBal1 = PAgeBal1;
			GenericDecimalType _PAgeBal2 = PAgeBal2;
			GenericDecimalType _PAgeBal3 = PAgeBal3;
			GenericDecimalType _PAgeBal4 = PAgeBal4;
			GenericDecimalType _PAgeBal5 = PAgeBal5;
			GenericDecimalType _PAgeBal6 = PAgeBal6;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetAPAgingInfoBySiteGroupSp";
				
				appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCurrCode", _PCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransDom", _PTransDom, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSiteQuery", _PSiteQuery, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSiteGroup", _PSiteGroup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAgeDesc1", _PAgeDesc1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAgeDesc2", _PAgeDesc2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAgeDesc3", _PAgeDesc3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAgeDesc4", _PAgeDesc4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAgeDesc5", _PAgeDesc5, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAgeBal1", _PAgeBal1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAgeBal2", _PAgeBal2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAgeBal3", _PAgeBal3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAgeBal4", _PAgeBal4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAgeBal5", _PAgeBal5, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAgeBal6", _PAgeBal6, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PAgeDesc1 = _PAgeDesc1;
				PAgeDesc2 = _PAgeDesc2;
				PAgeDesc3 = _PAgeDesc3;
				PAgeDesc4 = _PAgeDesc4;
				PAgeDesc5 = _PAgeDesc5;
				PAgeBal1 = _PAgeBal1;
				PAgeBal2 = _PAgeBal2;
				PAgeBal3 = _PAgeBal3;
				PAgeBal4 = _PAgeBal4;
				PAgeBal5 = _PAgeBal5;
				PAgeBal6 = _PAgeBal6;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
