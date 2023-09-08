//PROJECT NAME: Production
//CLASS NAME: IJustInTimeTransactionCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IJustInTimeTransactionCRUD
	{
		bool Optional_ModuleForExists();
		ICollectionLoadResponse Optional_Module1Select();
		void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse);
		bool Tv_ALTGENForExists();
		(string, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName);
		ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName);
		void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		(string, int? rowCount) ItemasparentLoad(string TItem, string ObsoleteItem, DateTime? TTransDate);
		(int? WhsePhyInvFlg, string WhseWhse, int? PPostNeg, int? rowCount) WhseLoad(int? PPostNeg, int? WhsePhyInvFlg, string WhseWhse);
		(int? ItemSerialTracked, string ItemJob, int? ItemSuffix, int? rowCount) ItemLoad(string TItem, int? ItemSerialTracked, string ItemJob, int? ItemSuffix);
		(string, int? rowCount) JobLoad(string ItemJob, int? ItemSuffix, string JobJob);
		(string JobrouteJob, int? JobrouteSuffix, int? JobrouteOperNum, string JobrouteWc, int? rowCount) JobrouteLoad(string ItemJob, int? ItemSuffix, string JobrouteJob, int? JobrouteSuffix, int? JobrouteOperNum, string JobrouteWc);
		bool JobtranForExists(Guid? JobtranRowPointer);
		ICollectionLoadResponse NontableSelect(Guid? JobtranRowPointer, string JobtranTransType, string JobtranTransClass, DateTime? JobtranTransDate, decimal? JobtranQtyComplete, decimal? JobtranQtyScrapped, string JobtranEmpNum, decimal? JobtranQtyMoved, string JobtranShift, string JobtranWhse, string JobtranLoc, string JobtranUserCode, string JobtranLot, int? JobtranNextOper, int? JobtranPosted, int? JobtranAwaitingEop, string JobtranJob, int? JobtranSuffix, int? JobtranOperNum, string JobtranWc, string ContainerNum);
		void NontableInsert(ICollectionLoadResponse nonTableLoadResponse);
		ICollectionLoadResponse Jobtran1Select(Guid? JobtranRowPointer);
		void Jobtran1Update(string ContainerNum, string JobtranTransType, string JobtranTransClass, DateTime? JobtranTransDate, decimal? JobtranQtyComplete, decimal? JobtranQtyScrapped, string JobtranEmpNum, decimal? JobtranQtyMoved, string JobtranShift, string JobtranWhse, string JobtranLoc, string JobtranUserCode, string JobtranLot, int? JobtranNextOper, int? JobtranPosted, int? JobtranAwaitingEop, string JobtranJob, int? JobtranSuffix, int? JobtranOperNum, string JobtranWc, ICollectionLoadResponse jobtran1LoadResponse);
		(decimal?, int? rowCount) Jobtran2Load(Guid? JobtranRowPointer, decimal? TJobtranTransNum);
		ICollectionLoadResponse Tmp_SerSelect(int? Severity, Guid? SessionID, decimal? TJobtranTransNum, int? Coby, string Infobar);
		void Tmp_SerDelete(ICollectionLoadResponse tmp_serLoadResponse);
		(int? ReturnCode, string Infobar) AltExtGen_JustInTimeTransactionSp(string AltExtGenSp, string TItem, decimal? TcQtuQty, string TWhse, string TLoc, string TLot, DateTime? TTransDate, string TShift, string TEmpNum, int? PPostNeg, string SerialPrefix, Guid? SessionID, string Infobar, string ContainerNum, string DocumentNum);
	}
}

