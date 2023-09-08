//PROJECT NAME: Production
//CLASS NAME: LeaveItem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class LeaveItem : ILeaveItem
	{
		readonly IApplicationDB appDB;
		
		
		public LeaveItem(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PDescription,
		string PRevision,
		string PWipAcct,
		string PWipAcctUnit1,
		string PWipAcctUnit2,
		string PWipAcctUnit3,
		string PWipAcctUnit4,
		string PJcbAcct,
		string PJcbAcctUnit1,
		string PJcbAcctUnit2,
		string PJcbAcctUnit3,
		string PJcbAcctUnit4,
		string PWipLbrAcct,
		string PWipLbrAcctUnit1,
		string PWipLbrAcctUnit2,
		string PWipLbrAcctUnit3,
		string PWipLbrAcctUnit4,
		string PWipFovhdAcct,
		string PWipFovhdAcctUnit1,
		string PWipFovhdAcctUnit2,
		string PWipFovhdAcctUnit3,
		string PWipFovhdAcctUnit4,
		string PWipVovhdAcct,
		string PWipVovhdAcctUnit1,
		string PWipVovhdAcctUnit2,
		string PWipVovhdAcctUnit3,
		string PWipVovhdAcctUnit4,
		string PWipOutAcct,
		string PWipOutAcctUnit1,
		string PWipOutAcctUnit2,
		string PWipOutAcctUnit3,
		string PWipOutAcctUnit4,
		string PProdMix,
		string PWipAcctDescription,
		string PWipAccessUnit1,
		string PWipAccessUnit2,
		string PWipAccessUnit3,
		string PWipAccessUnit4,
		string PJcbAcctDescription,
		string PJcbAccessUnit1,
		string PJcbAccessUnit2,
		string PJcbAccessUnit3,
		string PJcbAccessUnit4,
		string PWipLbrAcctDescription,
		string PWipLbrAccessUnit1,
		string PWipLbrAccessUnit2,
		string PWipLbrAccessUnit3,
		string PWipLbrAccessUnit4,
		string PWipFovhdAcctDescription,
		string PWipFovhdAccessUnit1,
		string PWipFovhdAccessUnit2,
		string PWipFovhdAccessUnit3,
		string PWipFovhdAccessUnit4,
		string PWipVovhdAcctDescription,
		string PWipVovhdAccessUnit1,
		string PWipVovhdAccessUnit2,
		string PWipVovhdAccessUnit3,
		string PWipVovhdAccessUnit4,
		string PWipOutAcctDescription,
		string PWipOutAccessUnit1,
		string PWipOutAccessUnit2,
		string PWipOutAccessUnit3,
		string PWipOutAccessUnit4,
		string Infobar,
		int? PreassignLots,
		int? PreassignSerials,
		int? ItemLotTracked,
		int? ItemSerialTracked,
		string ItemLotPrefix,
		string ItemSerialPrefix,
		int? PWipAcctIsControl,
		int? PJcbAcctIsControl,
		int? PWipLbrAcctIsControl,
		int? PWipFovhdAcctIsControl,
		int? PWipVovhdAcctIsControl,
		int? PWipOutAcctIsControl,
		string PUM) LeaveItemSp(string PNewItem,
		string PJob,
		int? PSuffix,
		string PType,
		string PDescription,
		string PRevision,
		string PWipAcct,
		string PWipAcctUnit1,
		string PWipAcctUnit2,
		string PWipAcctUnit3,
		string PWipAcctUnit4,
		string PJcbAcct,
		string PJcbAcctUnit1,
		string PJcbAcctUnit2,
		string PJcbAcctUnit3,
		string PJcbAcctUnit4,
		string PWipLbrAcct,
		string PWipLbrAcctUnit1,
		string PWipLbrAcctUnit2,
		string PWipLbrAcctUnit3,
		string PWipLbrAcctUnit4,
		string PWipFovhdAcct,
		string PWipFovhdAcctUnit1,
		string PWipFovhdAcctUnit2,
		string PWipFovhdAcctUnit3,
		string PWipFovhdAcctUnit4,
		string PWipVovhdAcct,
		string PWipVovhdAcctUnit1,
		string PWipVovhdAcctUnit2,
		string PWipVovhdAcctUnit3,
		string PWipVovhdAcctUnit4,
		string PWipOutAcct,
		string PWipOutAcctUnit1,
		string PWipOutAcctUnit2,
		string PWipOutAcctUnit3,
		string PWipOutAcctUnit4,
		string PProdMix,
		string PWipAcctDescription,
		string PWipAccessUnit1,
		string PWipAccessUnit2,
		string PWipAccessUnit3,
		string PWipAccessUnit4,
		string PJcbAcctDescription,
		string PJcbAccessUnit1,
		string PJcbAccessUnit2,
		string PJcbAccessUnit3,
		string PJcbAccessUnit4,
		string PWipLbrAcctDescription,
		string PWipLbrAccessUnit1,
		string PWipLbrAccessUnit2,
		string PWipLbrAccessUnit3,
		string PWipLbrAccessUnit4,
		string PWipFovhdAcctDescription,
		string PWipFovhdAccessUnit1,
		string PWipFovhdAccessUnit2,
		string PWipFovhdAccessUnit3,
		string PWipFovhdAccessUnit4,
		string PWipVovhdAcctDescription,
		string PWipVovhdAccessUnit1,
		string PWipVovhdAccessUnit2,
		string PWipVovhdAccessUnit3,
		string PWipVovhdAccessUnit4,
		string PWipOutAcctDescription,
		string PWipOutAccessUnit1,
		string PWipOutAccessUnit2,
		string PWipOutAccessUnit3,
		string PWipOutAccessUnit4,
		string Infobar,
		int? PreassignLots,
		int? PreassignSerials,
		int? ItemLotTracked,
		int? ItemSerialTracked,
		string ItemLotPrefix,
		string ItemSerialPrefix,
		int? PWipAcctIsControl,
		int? PJcbAcctIsControl,
		int? PWipLbrAcctIsControl,
		int? PWipFovhdAcctIsControl,
		int? PWipVovhdAcctIsControl,
		int? PWipOutAcctIsControl,
		string PUM = null)
		{
			ItemType _PNewItem = PNewItem;
			JobType _PJob = PJob;
			SuffixType _PSuffix = PSuffix;
			JobTypeType _PType = PType;
			DescriptionType _PDescription = PDescription;
			RevisionType _PRevision = PRevision;
			AcctType _PWipAcct = PWipAcct;
			UnitCode1Type _PWipAcctUnit1 = PWipAcctUnit1;
			UnitCode2Type _PWipAcctUnit2 = PWipAcctUnit2;
			UnitCode3Type _PWipAcctUnit3 = PWipAcctUnit3;
			UnitCode4Type _PWipAcctUnit4 = PWipAcctUnit4;
			AcctType _PJcbAcct = PJcbAcct;
			UnitCode1Type _PJcbAcctUnit1 = PJcbAcctUnit1;
			UnitCode2Type _PJcbAcctUnit2 = PJcbAcctUnit2;
			UnitCode3Type _PJcbAcctUnit3 = PJcbAcctUnit3;
			UnitCode4Type _PJcbAcctUnit4 = PJcbAcctUnit4;
			AcctType _PWipLbrAcct = PWipLbrAcct;
			UnitCode1Type _PWipLbrAcctUnit1 = PWipLbrAcctUnit1;
			UnitCode2Type _PWipLbrAcctUnit2 = PWipLbrAcctUnit2;
			UnitCode3Type _PWipLbrAcctUnit3 = PWipLbrAcctUnit3;
			UnitCode4Type _PWipLbrAcctUnit4 = PWipLbrAcctUnit4;
			AcctType _PWipFovhdAcct = PWipFovhdAcct;
			UnitCode1Type _PWipFovhdAcctUnit1 = PWipFovhdAcctUnit1;
			UnitCode2Type _PWipFovhdAcctUnit2 = PWipFovhdAcctUnit2;
			UnitCode3Type _PWipFovhdAcctUnit3 = PWipFovhdAcctUnit3;
			UnitCode4Type _PWipFovhdAcctUnit4 = PWipFovhdAcctUnit4;
			AcctType _PWipVovhdAcct = PWipVovhdAcct;
			UnitCode1Type _PWipVovhdAcctUnit1 = PWipVovhdAcctUnit1;
			UnitCode2Type _PWipVovhdAcctUnit2 = PWipVovhdAcctUnit2;
			UnitCode3Type _PWipVovhdAcctUnit3 = PWipVovhdAcctUnit3;
			UnitCode4Type _PWipVovhdAcctUnit4 = PWipVovhdAcctUnit4;
			AcctType _PWipOutAcct = PWipOutAcct;
			UnitCode1Type _PWipOutAcctUnit1 = PWipOutAcctUnit1;
			UnitCode2Type _PWipOutAcctUnit2 = PWipOutAcctUnit2;
			UnitCode3Type _PWipOutAcctUnit3 = PWipOutAcctUnit3;
			UnitCode4Type _PWipOutAcctUnit4 = PWipOutAcctUnit4;
			ProdMixType _PProdMix = PProdMix;
			DescriptionType _PWipAcctDescription = PWipAcctDescription;
			UnitCodeAccessType _PWipAccessUnit1 = PWipAccessUnit1;
			UnitCodeAccessType _PWipAccessUnit2 = PWipAccessUnit2;
			UnitCodeAccessType _PWipAccessUnit3 = PWipAccessUnit3;
			UnitCodeAccessType _PWipAccessUnit4 = PWipAccessUnit4;
			DescriptionType _PJcbAcctDescription = PJcbAcctDescription;
			UnitCodeAccessType _PJcbAccessUnit1 = PJcbAccessUnit1;
			UnitCodeAccessType _PJcbAccessUnit2 = PJcbAccessUnit2;
			UnitCodeAccessType _PJcbAccessUnit3 = PJcbAccessUnit3;
			UnitCodeAccessType _PJcbAccessUnit4 = PJcbAccessUnit4;
			DescriptionType _PWipLbrAcctDescription = PWipLbrAcctDescription;
			UnitCodeAccessType _PWipLbrAccessUnit1 = PWipLbrAccessUnit1;
			UnitCodeAccessType _PWipLbrAccessUnit2 = PWipLbrAccessUnit2;
			UnitCodeAccessType _PWipLbrAccessUnit3 = PWipLbrAccessUnit3;
			UnitCodeAccessType _PWipLbrAccessUnit4 = PWipLbrAccessUnit4;
			DescriptionType _PWipFovhdAcctDescription = PWipFovhdAcctDescription;
			UnitCodeAccessType _PWipFovhdAccessUnit1 = PWipFovhdAccessUnit1;
			UnitCodeAccessType _PWipFovhdAccessUnit2 = PWipFovhdAccessUnit2;
			UnitCodeAccessType _PWipFovhdAccessUnit3 = PWipFovhdAccessUnit3;
			UnitCodeAccessType _PWipFovhdAccessUnit4 = PWipFovhdAccessUnit4;
			DescriptionType _PWipVovhdAcctDescription = PWipVovhdAcctDescription;
			UnitCodeAccessType _PWipVovhdAccessUnit1 = PWipVovhdAccessUnit1;
			UnitCodeAccessType _PWipVovhdAccessUnit2 = PWipVovhdAccessUnit2;
			UnitCodeAccessType _PWipVovhdAccessUnit3 = PWipVovhdAccessUnit3;
			UnitCodeAccessType _PWipVovhdAccessUnit4 = PWipVovhdAccessUnit4;
			DescriptionType _PWipOutAcctDescription = PWipOutAcctDescription;
			UnitCodeAccessType _PWipOutAccessUnit1 = PWipOutAccessUnit1;
			UnitCodeAccessType _PWipOutAccessUnit2 = PWipOutAccessUnit2;
			UnitCodeAccessType _PWipOutAccessUnit3 = PWipOutAccessUnit3;
			UnitCodeAccessType _PWipOutAccessUnit4 = PWipOutAccessUnit4;
			InfobarType _Infobar = Infobar;
			ListYesNoType _PreassignLots = PreassignLots;
			ListYesNoType _PreassignSerials = PreassignSerials;
			ListYesNoType _ItemLotTracked = ItemLotTracked;
			ListYesNoType _ItemSerialTracked = ItemSerialTracked;
			LotPrefixType _ItemLotPrefix = ItemLotPrefix;
			SerialPrefixType _ItemSerialPrefix = ItemSerialPrefix;
			ListYesNoType _PWipAcctIsControl = PWipAcctIsControl;
			ListYesNoType _PJcbAcctIsControl = PJcbAcctIsControl;
			ListYesNoType _PWipLbrAcctIsControl = PWipLbrAcctIsControl;
			ListYesNoType _PWipFovhdAcctIsControl = PWipFovhdAcctIsControl;
			ListYesNoType _PWipVovhdAcctIsControl = PWipVovhdAcctIsControl;
			ListYesNoType _PWipOutAcctIsControl = PWipOutAcctIsControl;
			UMType _PUM = PUM;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LeaveItemSp";
				
				appDB.AddCommandParameter(cmd, "PNewItem", _PNewItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PJob", _PJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSuffix", _PSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PType", _PType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDescription", _PDescription, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PRevision", _PRevision, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PWipAcct", _PWipAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PWipAcctUnit1", _PWipAcctUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PWipAcctUnit2", _PWipAcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PWipAcctUnit3", _PWipAcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PWipAcctUnit4", _PWipAcctUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PJcbAcct", _PJcbAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PJcbAcctUnit1", _PJcbAcctUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PJcbAcctUnit2", _PJcbAcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PJcbAcctUnit3", _PJcbAcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PJcbAcctUnit4", _PJcbAcctUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PWipLbrAcct", _PWipLbrAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PWipLbrAcctUnit1", _PWipLbrAcctUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PWipLbrAcctUnit2", _PWipLbrAcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PWipLbrAcctUnit3", _PWipLbrAcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PWipLbrAcctUnit4", _PWipLbrAcctUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PWipFovhdAcct", _PWipFovhdAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PWipFovhdAcctUnit1", _PWipFovhdAcctUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PWipFovhdAcctUnit2", _PWipFovhdAcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PWipFovhdAcctUnit3", _PWipFovhdAcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PWipFovhdAcctUnit4", _PWipFovhdAcctUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PWipVovhdAcct", _PWipVovhdAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PWipVovhdAcctUnit1", _PWipVovhdAcctUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PWipVovhdAcctUnit2", _PWipVovhdAcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PWipVovhdAcctUnit3", _PWipVovhdAcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PWipVovhdAcctUnit4", _PWipVovhdAcctUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PWipOutAcct", _PWipOutAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PWipOutAcctUnit1", _PWipOutAcctUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PWipOutAcctUnit2", _PWipOutAcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PWipOutAcctUnit3", _PWipOutAcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PWipOutAcctUnit4", _PWipOutAcctUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PProdMix", _PProdMix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PWipAcctDescription", _PWipAcctDescription, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PWipAccessUnit1", _PWipAccessUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PWipAccessUnit2", _PWipAccessUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PWipAccessUnit3", _PWipAccessUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PWipAccessUnit4", _PWipAccessUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PJcbAcctDescription", _PJcbAcctDescription, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PJcbAccessUnit1", _PJcbAccessUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PJcbAccessUnit2", _PJcbAccessUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PJcbAccessUnit3", _PJcbAccessUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PJcbAccessUnit4", _PJcbAccessUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PWipLbrAcctDescription", _PWipLbrAcctDescription, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PWipLbrAccessUnit1", _PWipLbrAccessUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PWipLbrAccessUnit2", _PWipLbrAccessUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PWipLbrAccessUnit3", _PWipLbrAccessUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PWipLbrAccessUnit4", _PWipLbrAccessUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PWipFovhdAcctDescription", _PWipFovhdAcctDescription, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PWipFovhdAccessUnit1", _PWipFovhdAccessUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PWipFovhdAccessUnit2", _PWipFovhdAccessUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PWipFovhdAccessUnit3", _PWipFovhdAccessUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PWipFovhdAccessUnit4", _PWipFovhdAccessUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PWipVovhdAcctDescription", _PWipVovhdAcctDescription, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PWipVovhdAccessUnit1", _PWipVovhdAccessUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PWipVovhdAccessUnit2", _PWipVovhdAccessUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PWipVovhdAccessUnit3", _PWipVovhdAccessUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PWipVovhdAccessUnit4", _PWipVovhdAccessUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PWipOutAcctDescription", _PWipOutAcctDescription, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PWipOutAccessUnit1", _PWipOutAccessUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PWipOutAccessUnit2", _PWipOutAccessUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PWipOutAccessUnit3", _PWipOutAccessUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PWipOutAccessUnit4", _PWipOutAccessUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PreassignLots", _PreassignLots, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PreassignSerials", _PreassignSerials, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemLotTracked", _ItemLotTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemSerialTracked", _ItemSerialTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemLotPrefix", _ItemLotPrefix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemSerialPrefix", _ItemSerialPrefix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PWipAcctIsControl", _PWipAcctIsControl, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PJcbAcctIsControl", _PJcbAcctIsControl, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PWipLbrAcctIsControl", _PWipLbrAcctIsControl, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PWipFovhdAcctIsControl", _PWipFovhdAcctIsControl, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PWipVovhdAcctIsControl", _PWipVovhdAcctIsControl, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PWipOutAcctIsControl", _PWipOutAcctIsControl, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PUM", _PUM, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PDescription = _PDescription;
				PRevision = _PRevision;
				PWipAcct = _PWipAcct;
				PWipAcctUnit1 = _PWipAcctUnit1;
				PWipAcctUnit2 = _PWipAcctUnit2;
				PWipAcctUnit3 = _PWipAcctUnit3;
				PWipAcctUnit4 = _PWipAcctUnit4;
				PJcbAcct = _PJcbAcct;
				PJcbAcctUnit1 = _PJcbAcctUnit1;
				PJcbAcctUnit2 = _PJcbAcctUnit2;
				PJcbAcctUnit3 = _PJcbAcctUnit3;
				PJcbAcctUnit4 = _PJcbAcctUnit4;
				PWipLbrAcct = _PWipLbrAcct;
				PWipLbrAcctUnit1 = _PWipLbrAcctUnit1;
				PWipLbrAcctUnit2 = _PWipLbrAcctUnit2;
				PWipLbrAcctUnit3 = _PWipLbrAcctUnit3;
				PWipLbrAcctUnit4 = _PWipLbrAcctUnit4;
				PWipFovhdAcct = _PWipFovhdAcct;
				PWipFovhdAcctUnit1 = _PWipFovhdAcctUnit1;
				PWipFovhdAcctUnit2 = _PWipFovhdAcctUnit2;
				PWipFovhdAcctUnit3 = _PWipFovhdAcctUnit3;
				PWipFovhdAcctUnit4 = _PWipFovhdAcctUnit4;
				PWipVovhdAcct = _PWipVovhdAcct;
				PWipVovhdAcctUnit1 = _PWipVovhdAcctUnit1;
				PWipVovhdAcctUnit2 = _PWipVovhdAcctUnit2;
				PWipVovhdAcctUnit3 = _PWipVovhdAcctUnit3;
				PWipVovhdAcctUnit4 = _PWipVovhdAcctUnit4;
				PWipOutAcct = _PWipOutAcct;
				PWipOutAcctUnit1 = _PWipOutAcctUnit1;
				PWipOutAcctUnit2 = _PWipOutAcctUnit2;
				PWipOutAcctUnit3 = _PWipOutAcctUnit3;
				PWipOutAcctUnit4 = _PWipOutAcctUnit4;
				PProdMix = _PProdMix;
				PWipAcctDescription = _PWipAcctDescription;
				PWipAccessUnit1 = _PWipAccessUnit1;
				PWipAccessUnit2 = _PWipAccessUnit2;
				PWipAccessUnit3 = _PWipAccessUnit3;
				PWipAccessUnit4 = _PWipAccessUnit4;
				PJcbAcctDescription = _PJcbAcctDescription;
				PJcbAccessUnit1 = _PJcbAccessUnit1;
				PJcbAccessUnit2 = _PJcbAccessUnit2;
				PJcbAccessUnit3 = _PJcbAccessUnit3;
				PJcbAccessUnit4 = _PJcbAccessUnit4;
				PWipLbrAcctDescription = _PWipLbrAcctDescription;
				PWipLbrAccessUnit1 = _PWipLbrAccessUnit1;
				PWipLbrAccessUnit2 = _PWipLbrAccessUnit2;
				PWipLbrAccessUnit3 = _PWipLbrAccessUnit3;
				PWipLbrAccessUnit4 = _PWipLbrAccessUnit4;
				PWipFovhdAcctDescription = _PWipFovhdAcctDescription;
				PWipFovhdAccessUnit1 = _PWipFovhdAccessUnit1;
				PWipFovhdAccessUnit2 = _PWipFovhdAccessUnit2;
				PWipFovhdAccessUnit3 = _PWipFovhdAccessUnit3;
				PWipFovhdAccessUnit4 = _PWipFovhdAccessUnit4;
				PWipVovhdAcctDescription = _PWipVovhdAcctDescription;
				PWipVovhdAccessUnit1 = _PWipVovhdAccessUnit1;
				PWipVovhdAccessUnit2 = _PWipVovhdAccessUnit2;
				PWipVovhdAccessUnit3 = _PWipVovhdAccessUnit3;
				PWipVovhdAccessUnit4 = _PWipVovhdAccessUnit4;
				PWipOutAcctDescription = _PWipOutAcctDescription;
				PWipOutAccessUnit1 = _PWipOutAccessUnit1;
				PWipOutAccessUnit2 = _PWipOutAccessUnit2;
				PWipOutAccessUnit3 = _PWipOutAccessUnit3;
				PWipOutAccessUnit4 = _PWipOutAccessUnit4;
				Infobar = _Infobar;
				PreassignLots = _PreassignLots;
				PreassignSerials = _PreassignSerials;
				ItemLotTracked = _ItemLotTracked;
				ItemSerialTracked = _ItemSerialTracked;
				ItemLotPrefix = _ItemLotPrefix;
				ItemSerialPrefix = _ItemSerialPrefix;
				PWipAcctIsControl = _PWipAcctIsControl;
				PJcbAcctIsControl = _PJcbAcctIsControl;
				PWipLbrAcctIsControl = _PWipLbrAcctIsControl;
				PWipFovhdAcctIsControl = _PWipFovhdAcctIsControl;
				PWipVovhdAcctIsControl = _PWipVovhdAcctIsControl;
				PWipOutAcctIsControl = _PWipOutAcctIsControl;
				PUM = _PUM;
				
				return (Severity, PDescription, PRevision, PWipAcct, PWipAcctUnit1, PWipAcctUnit2, PWipAcctUnit3, PWipAcctUnit4, PJcbAcct, PJcbAcctUnit1, PJcbAcctUnit2, PJcbAcctUnit3, PJcbAcctUnit4, PWipLbrAcct, PWipLbrAcctUnit1, PWipLbrAcctUnit2, PWipLbrAcctUnit3, PWipLbrAcctUnit4, PWipFovhdAcct, PWipFovhdAcctUnit1, PWipFovhdAcctUnit2, PWipFovhdAcctUnit3, PWipFovhdAcctUnit4, PWipVovhdAcct, PWipVovhdAcctUnit1, PWipVovhdAcctUnit2, PWipVovhdAcctUnit3, PWipVovhdAcctUnit4, PWipOutAcct, PWipOutAcctUnit1, PWipOutAcctUnit2, PWipOutAcctUnit3, PWipOutAcctUnit4, PProdMix, PWipAcctDescription, PWipAccessUnit1, PWipAccessUnit2, PWipAccessUnit3, PWipAccessUnit4, PJcbAcctDescription, PJcbAccessUnit1, PJcbAccessUnit2, PJcbAccessUnit3, PJcbAccessUnit4, PWipLbrAcctDescription, PWipLbrAccessUnit1, PWipLbrAccessUnit2, PWipLbrAccessUnit3, PWipLbrAccessUnit4, PWipFovhdAcctDescription, PWipFovhdAccessUnit1, PWipFovhdAccessUnit2, PWipFovhdAccessUnit3, PWipFovhdAccessUnit4, PWipVovhdAcctDescription, PWipVovhdAccessUnit1, PWipVovhdAccessUnit2, PWipVovhdAccessUnit3, PWipVovhdAccessUnit4, PWipOutAcctDescription, PWipOutAccessUnit1, PWipOutAccessUnit2, PWipOutAccessUnit3, PWipOutAccessUnit4, Infobar, PreassignLots, PreassignSerials, ItemLotTracked, ItemSerialTracked, ItemLotPrefix, ItemSerialPrefix, PWipAcctIsControl, PJcbAcctIsControl, PWipLbrAcctIsControl, PWipFovhdAcctIsControl, PWipVovhdAcctIsControl, PWipOutAcctIsControl, PUM);
			}
		}
	}
}
