using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using CSI.MG;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.CRUD.Production.Quality.RcvrUpdate
{
    public interface IQCTransactionCRUD
    {
        void GetTransactionNumberByRcvrNum(int? RcvrNum, out QCTransNumType TransNum);

        void GetTransactionRecordByTransNum(QCTransNumType TransNum, out ItemType Item, out QCDocNumType Entity, out QCCharType TestType, out QCTestSeqType TestSeq, out QCRefType RefType, out QCRefNumType RefNum, out QCRefLineType RefLine, out QCRefReleaseType RefRelease, out DateType TransDate, out QCCodeType Stat, out QCCodeType DCode, out RevisionType Revision, out DateType OrigDueDate, out LotType Lot, out LotType QCLot, out SiteType OrigSite);

        void InsertNewTransactionRecord(ItemType Item, QCDocNumType Entity, QCCharType TestType, QCTestSeqType TestSeq, int? RcvrNum, QCRefType RefType, QCRefNumType RefNum, QCRefLineType RefLine, QCRefReleaseType RefRelease, DateType TransDate, QCCodeType Stat, QCCodeType DCode, decimal? Qty, UserCodeType UserCode, RevisionType Revision, DateType OrigDueDate, LotType Lot, LotType QCLot);
    }

    public class QCTransactionCRUD : IQCTransactionCRUD
    {
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
        readonly ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory;
        readonly IApplicationDB appDB;

        public QCTransactionCRUD(ICollectionLoadRequestFactory collectionLoadRequestFactory, ICollectionInsertRequestFactory collectionInsertRequestFactory, IApplicationDB appDB, ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory)
        {
            this.collectionLoadRequestFactory = collectionLoadRequestFactory ?? throw new ArgumentNullException(nameof(collectionLoadRequestFactory));
            this.collectionInsertRequestFactory = collectionInsertRequestFactory ?? throw new ArgumentNullException(nameof(collectionInsertRequestFactory));
            this.collectionLoadStatementRequestFactory = collectionLoadStatementRequestFactory ?? throw new ArgumentNullException(nameof(collectionLoadStatementRequestFactory));
            this.appDB = appDB ?? throw new ArgumentNullException(nameof(appDB));
        }

        public void GetTransactionNumberByRcvrNum(int? RcvrNum, out QCTransNumType TransNum)
        {
            QCTransNumType transNum = DBNull.Value;

            //var request = collectionLoadRequestFactory.SQLLoad(
            //    columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
            //    {
            //                { transNum, "MIN(rs_qctran.trans_num)" }
            //    },
            //tableName: "rs_qctran",
            //fromClause: collectionLoadRequestFactory.Clause(""),
            //whereClause: collectionLoadRequestFactory.Clause("rs_qctran.rcvr_num = {0} AND UPPER(rs_qctran.stat) = 'RECEIVED'", RcvrNum));

            //this.appDB.Load(request);


            var request = collectionLoadStatementRequestFactory.SQLLoad(
                columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                        { transNum, "MIN(rs_qctran.trans_num)" }
                },
                selectStatement: collectionLoadRequestFactory.Clause("SELECT @selectList FROM rs_qctran WHERE rs_qctran.rcvr_num = {0} AND UPPER(rs_qctran.stat) = 'RECEIVED'   ", RcvrNum));

            appDB.Load(request);

            TransNum = transNum;
        }

        public void GetTransactionRecordByTransNum(QCTransNumType TransNum, out ItemType Item, out QCDocNumType Entity, out QCCharType TestType, out QCTestSeqType TestSeq, out QCRefType RefType, out QCRefNumType RefNum, out QCRefLineType RefLine, out QCRefReleaseType RefRelease, out DateType TransDate, out QCCodeType Stat, out QCCodeType DCode, out RevisionType Revision, out DateType OrigDueDate, out LotType Lot, out LotType QCLot, out SiteType OrigSite)
        {
            ItemType item = DBNull.Value;
            QCDocNumType entity = DBNull.Value;
            QCCharType testType = DBNull.Value;
            QCTestSeqType testSeq = DBNull.Value;
            QCRefType refType = DBNull.Value;
            QCRefNumType refNum = DBNull.Value;
            QCRefLineType refLine = DBNull.Value;
            QCRefReleaseType refRelease = DBNull.Value;
            DateType transDate = DBNull.Value;
            QCCodeType stat = DBNull.Value;
            QCCodeType dCode = DBNull.Value;
            RevisionType revision = DBNull.Value;
            DateType origDueDate = DBNull.Value;
            LotType lot = DBNull.Value;
            LotType qcLot = DBNull.Value;
            SiteType origSite = DBNull.Value;

            var request = collectionLoadRequestFactory.SQLLoad(
                columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                            { item,         "item" },
                            { entity,       "entity" },
                            { testType,     "test_type"},
                            { testSeq,      "test_seq" },
                            { refType,      "ref_type" },
                            { refNum,       "ref_num"},
                            { refLine,      "ref_line" },
                            { refRelease,   "ref_release" },
                            { transDate,    "trans_date"},
                            { stat,         "stat" },
                            { dCode,        "dcode" },
                            { revision,     "revision"},
                            { origDueDate,  "orig_due_date" },
                            { lot,          "lot" },
                            { qcLot,        "qc_lot"},
                            { origSite,     "orig_site"}
                },
            tableName: "rs_qctran",
            loadForChange: false,
            lockingType: LockingType.None,
            fromClause: collectionLoadRequestFactory.Clause(""),
            whereClause: collectionLoadRequestFactory.Clause("rs_qctran.trans_num = {0}", TransNum));

            this.appDB.Load(request);

            Item = item;
            Entity = entity;
            TestType = testType;
            TestSeq = testSeq;
            RefType = refType;
            RefNum = refNum;
            RefLine = refLine;
            RefRelease = refRelease;
            TransDate = transDate;
            Stat = stat;
            DCode = dCode;
            Revision = revision;
            OrigDueDate = origDueDate;
            Lot = lot;
            QCLot = qcLot;
            OrigSite = origSite;
        }

        public void InsertNewTransactionRecord(ItemType Item, QCDocNumType Entity, QCCharType TestType, QCTestSeqType TestSeq, int? RcvrNum, QCRefType RefType, QCRefNumType RefNum, QCRefLineType RefLine, QCRefReleaseType RefRelease, DateType TransDate, QCCodeType Stat, QCCodeType DCode, decimal? Qty, UserCodeType UserCode, RevisionType Revision, DateType OrigDueDate, LotType Lot, LotType QCLot)
        {
            var request = collectionInsertRequestFactory.SQLInsert(
            tableName: "rs_qctran",
            valuesByColumnToAssign:
                new Dictionary<string, object>() {
                            { "item",           Item },
                            { "entity",         Entity },
                            { "test_type",      TestType },
                            { "test_seq",       TestSeq },
                            { "rcvr_num",       RcvrNum },
                            { "ref_type",       RefType  },
                            { "ref_num",        RefNum },
                            { "ref_line",       RefLine },
                            { "ref_release",    RefRelease },
                            { "trans_date",     TransDate },
                            { "stat",           Stat },
                            { "dcode",          DCode },
                            { "reason",         "" },
                            { "cause",          "" },
                            { "qty",            Qty },
                            { "user_code",      UserCode },
                            { "revision",       Revision },
                            { "orig_due_date",  OrigDueDate  },
                            { "lot",            Lot },
                            { "qc_lot",         QCLot }});

            appDB.Insert(request);
        }
    }
}
