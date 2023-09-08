//PROJECT NAME: CSICustomer
//CLASS NAME: EstimateQuickEntryPreLoadBinding.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IEstimateQuickEntryPreLoadBinding
	{
		int EstimateQuickEntryPreLoadBindingSp(string CanAnyType1,
		                                       string CanAnyFormName1,
		                                       ref short? Privilege1,
		                                       string CanAnyType2,
		                                       string CanAnyFormName2,
		                                       ref short? Privilege2,
		                                       string CanAnyType3,
		                                       string CanAnyFormName3,
		                                       ref short? Privilege3,
		                                       string CanAnyType4,
		                                       string CanAnyFormName4,
		                                       ref short? Privilege4,
		                                       string CanAnyType5,
		                                       string CanAnyFormName5,
		                                       ref short? Privilege5,
		                                       ref string ApsParmApsmode,
		                                       ref short? ExpPeriod);
	}
	
	public class EstimateQuickEntryPreLoadBinding : IEstimateQuickEntryPreLoadBinding
	{
		readonly IApplicationDB appDB;
		
		public EstimateQuickEntryPreLoadBinding(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int EstimateQuickEntryPreLoadBindingSp(string CanAnyType1,
		                                              string CanAnyFormName1,
		                                              ref short? Privilege1,
		                                              string CanAnyType2,
		                                              string CanAnyFormName2,
		                                              ref short? Privilege2,
		                                              string CanAnyType3,
		                                              string CanAnyFormName3,
		                                              ref short? Privilege3,
		                                              string CanAnyType4,
		                                              string CanAnyFormName4,
		                                              ref short? Privilege4,
		                                              string CanAnyType5,
		                                              string CanAnyFormName5,
		                                              ref short? Privilege5,
		                                              ref string ApsParmApsmode,
		                                              ref short? ExpPeriod)
		{
			LongList _CanAnyType1 = CanAnyType1;
			AuthorizationObjectNameType _CanAnyFormName1 = CanAnyFormName1;
			PrivilegeType _Privilege1 = Privilege1;
			LongList _CanAnyType2 = CanAnyType2;
			AuthorizationObjectNameType _CanAnyFormName2 = CanAnyFormName2;
			PrivilegeType _Privilege2 = Privilege2;
			LongList _CanAnyType3 = CanAnyType3;
			AuthorizationObjectNameType _CanAnyFormName3 = CanAnyFormName3;
			PrivilegeType _Privilege3 = Privilege3;
			LongList _CanAnyType4 = CanAnyType4;
			AuthorizationObjectNameType _CanAnyFormName4 = CanAnyFormName4;
			PrivilegeType _Privilege4 = Privilege4;
			LongList _CanAnyType5 = CanAnyType5;
			AuthorizationObjectNameType _CanAnyFormName5 = CanAnyFormName5;
			PrivilegeType _Privilege5 = Privilege5;
			ApsModeType _ApsParmApsmode = ApsParmApsmode;
			DuePeriodType _ExpPeriod = ExpPeriod;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EstimateQuickEntryPreLoadBindingSp";
				
				appDB.AddCommandParameter(cmd, "CanAnyType1", _CanAnyType1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CanAnyFormName1", _CanAnyFormName1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Privilege1", _Privilege1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CanAnyType2", _CanAnyType2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CanAnyFormName2", _CanAnyFormName2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Privilege2", _Privilege2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CanAnyType3", _CanAnyType3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CanAnyFormName3", _CanAnyFormName3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Privilege3", _Privilege3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CanAnyType4", _CanAnyType4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CanAnyFormName4", _CanAnyFormName4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Privilege4", _Privilege4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CanAnyType5", _CanAnyType5, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CanAnyFormName5", _CanAnyFormName5, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Privilege5", _Privilege5, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ApsParmApsmode", _ApsParmApsmode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ExpPeriod", _ExpPeriod, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Privilege1 = _Privilege1;
				Privilege2 = _Privilege2;
				Privilege3 = _Privilege3;
				Privilege4 = _Privilege4;
				Privilege5 = _Privilege5;
				ApsParmApsmode = _ApsParmApsmode;
				ExpPeriod = _ExpPeriod;
				
				return Severity;
			}
		}
	}
}
