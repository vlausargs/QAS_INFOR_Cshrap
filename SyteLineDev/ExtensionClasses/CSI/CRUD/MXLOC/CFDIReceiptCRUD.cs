using CSI.Data.CRUD;
using System;
using System.Collections.Generic;
using System.Text;
using CSI.MXLOC.Interfaces;
using CSI.MG;
using System.Data;
using CSI.Data.RecordSets;
using CSI.Data.SQL.UDDT;

namespace CSI.MXLOC
{
    
    public class CFDIReceiptCRUD : ICFDIReceiptCRUD
    {
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly IApplicationDB appDB;
        readonly ICollectionUpdateRequestFactory collectionUpdateRequestFactory;
        readonly IRecordCollectionToDataTable recordCollectionToDataTable;

        public CFDIReceiptCRUD(ICollectionLoadRequestFactory collectionLoadRequestFactory, IApplicationDB appDB, ICollectionUpdateRequestFactory collectionUpdateRequestFactory, IRecordCollectionToDataTable recordCollectionToDataTable)
        {
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.appDB = appDB;
            this.collectionUpdateRequestFactory = collectionUpdateRequestFactory;
            this.recordCollectionToDataTable = recordCollectionToDataTable;
        }

        public (int Count, string Infobar) UpdateDatabaseValue(IMXElectronicPaymentReceipt MXElectronicPaymentReceipt, string CFDIReceiptXmlFileName)
        {
            string infobar = string.Empty;

            string ArCheckNum = MXElectronicPaymentReceipt.ArPmtCheckNum;
            string PaymentDocumentApprovalStamp = MXElectronicPaymentReceipt.PaymentDocumentApprovalStamp;
            DateTime? PaymentDate = MXElectronicPaymentReceipt.PaymentDate;
            string CurrCode = MXElectronicPaymentReceipt.CurrCode;
            DateTime? SatCertificateDate = MXElectronicPaymentReceipt.SatCertificateDate;
            string ComplementDigitalStamp = MXElectronicPaymentReceipt.ComplementDigitalStamp;
            string IssuerDigitalStamp = MXElectronicPaymentReceipt.IssuerDigitalStamp;
            string SatDigitalStamp = MXElectronicPaymentReceipt.SatDigitalStamp;
            DateTime? ReceiptIssueDate = MXElectronicPaymentReceipt.ReceiptIssueDate;
            string SatCertificateSerialNumber = MXElectronicPaymentReceipt.SatCertificateSerialNumber;
            string issuerDigitalStampSerialNumber = MXElectronicPaymentReceipt.IssuerDigitalStampSerialNumber;

            #region CRUD LoadToRecord
            var MX_electronic_payment_receiptLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"payment_date","MX_electronic_payment_receipt.payment_date"},
                    {"curr_code","MX_electronic_payment_receipt.curr_code"},
                    {"sat_certificate_date","MX_electronic_payment_receipt.sat_certificate_date"},
                    {"complement_digital_stamp","MX_electronic_payment_receipt.complement_digital_stamp"},
                    {"issuer_digital_stamp","MX_electronic_payment_receipt.issuer_digital_stamp"},
                    {"sat_digital_stamp","MX_electronic_payment_receipt.sat_digital_stamp"},
                    {"receipt_issue_date","MX_electronic_payment_receipt.receipt_issue_date"},
                    {"sat_certificate_serial_number","MX_electronic_payment_receipt.sat_certificate_serial_number"},
                    {"issuer_digital_stamp_serial_number","MX_electronic_payment_receipt.issuer_digital_stamp_serial_number"},
                },
                tableName: "MX_electronic_payment_receipt",
                loadForChange: true,
                lockingType: LockingType.UPDLock,
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("arpmt_check_num = {1} AND payment_document_approval_stamp = {0}", PaymentDocumentApprovalStamp, ArCheckNum),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var MX_electronic_payment_receiptLoadResponse = this.appDB.Load(MX_electronic_payment_receiptLoadRequest);
            #endregion  LoadToRecord

            #region CRUD UpdateByRecord
            foreach (var MX_electronic_payment_receiptItem in MX_electronic_payment_receiptLoadResponse.Items)
            {
                MX_electronic_payment_receiptItem.SetValue<DateTime?>("payment_date", PaymentDate);
                MX_electronic_payment_receiptItem.SetValue<string>("curr_code", CurrCode);
                MX_electronic_payment_receiptItem.SetValue<DateTime?>("sat_certificate_date", SatCertificateDate);
                MX_electronic_payment_receiptItem.SetValue<string>("complement_digital_stamp", ComplementDigitalStamp);
                MX_electronic_payment_receiptItem.SetValue<string>("issuer_digital_stamp", IssuerDigitalStamp);
                MX_electronic_payment_receiptItem.SetValue<string>("sat_digital_stamp", SatDigitalStamp);
                MX_electronic_payment_receiptItem.SetValue<DateTime?>("receipt_issue_date", ReceiptIssueDate);
                MX_electronic_payment_receiptItem.SetValue<string>("sat_certificate_serial_number", SatCertificateSerialNumber);
                MX_electronic_payment_receiptItem.SetValue<string>("issuer_digital_stamp_serial_number", issuerDigitalStampSerialNumber);
            };

            var MX_electronic_payment_receiptRequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "MX_electronic_payment_receipt",
                items: MX_electronic_payment_receiptLoadResponse.Items);

            this.appDB.Update(MX_electronic_payment_receiptRequestUpdate);
            #endregion UpdateByRecord

            int count = MX_electronic_payment_receiptLoadResponse.Items.Count;

            return (count, infobar);
        }

        public (int Count, string Infobar) UpdateDetailDatabaseValue(IMXElectronicPaymentReceiptDetail MXElectronicPaymentReceiptDetail, string CFDIReceiptXmlFileName)
        {
            string infobar = string.Empty;

            string ProFormaInvNum = MXElectronicPaymentReceiptDetail.ProFormaInvNum;
            string PaymentDocumentApprovalStampDetail = MXElectronicPaymentReceiptDetail.PaymentDocumentApprovalStamp;
            string DocumentIdStamp = MXElectronicPaymentReceiptDetail.DocumentIdStamp;
            string PaymentMethod = MXElectronicPaymentReceiptDetail.PaymentMethod;
            string CurrCodeDetail = MXElectronicPaymentReceiptDetail.CurrCode;
            int? PartialPaymentCount = MXElectronicPaymentReceiptDetail.PartialPaymentCount;
            decimal? PreviousAmount = MXElectronicPaymentReceiptDetail.PreviousAmount;
            decimal? PaidAmount = MXElectronicPaymentReceiptDetail.PaidAmount;
            decimal? BalanceAmount = MXElectronicPaymentReceiptDetail.BalanceAmount;

            #region CRUD LoadToRecord
            var MX_electronic_payment_receipt_detailLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"document_id_stamp","MX_electronic_payment_receipt_detail.document_id_stamp"},
                    {"payment_method","MX_electronic_payment_receipt_detail.payment_method"},
                    {"curr_code","MX_electronic_payment_receipt_detail.curr_code"},
                    {"partial_payment_count","MX_electronic_payment_receipt_detail.partial_payment_count"},
                    {"previous_amount","MX_electronic_payment_receipt_detail.previous_amount"},
                    {"paid_amount","MX_electronic_payment_receipt_detail.paid_amount"},
                    {"balance_amount","MX_electronic_payment_receipt_detail.balance_amount"},
                },
                tableName: "MX_electronic_payment_receipt_detail",
                loadForChange: true,
                lockingType: LockingType.UPDLock,
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("payment_document_approval_stamp = {0} AND pro_forma_inv_num = {1}", PaymentDocumentApprovalStampDetail, ProFormaInvNum),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var MX_electronic_payment_receipt_detailLoadResponse = this.appDB.Load(MX_electronic_payment_receipt_detailLoadRequest);
            #endregion  LoadToRecord

            #region CRUD UpdateByRecord
            foreach (var MX_electronic_payment_receipt_detailItem in MX_electronic_payment_receipt_detailLoadResponse.Items)
            {
                MX_electronic_payment_receipt_detailItem.SetValue<string>("document_id_stamp", DocumentIdStamp);
                MX_electronic_payment_receipt_detailItem.SetValue<string>("payment_method", PaymentMethod);
                MX_electronic_payment_receipt_detailItem.SetValue<string>("curr_code", CurrCodeDetail);
                MX_electronic_payment_receipt_detailItem.SetValue<int?>("partial_payment_count", PartialPaymentCount);
                MX_electronic_payment_receipt_detailItem.SetValue<decimal?>("previous_amount", PreviousAmount);
                MX_electronic_payment_receipt_detailItem.SetValue<decimal?>("paid_amount", PaidAmount);
                MX_electronic_payment_receipt_detailItem.SetValue<decimal?>("balance_amount", BalanceAmount);
            };

            var MX_electronic_payment_receipt_detailRequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "MX_electronic_payment_receipt_detail",
                items: MX_electronic_payment_receipt_detailLoadResponse.Items);

            this.appDB.Update(MX_electronic_payment_receipt_detailRequestUpdate);
            #endregion UpdateByRecord

            int count = MX_electronic_payment_receipt_detailLoadResponse.Items.Count;

            return (count, infobar);
        }

        public string GetWorkstationID(string Username)
        {
            StringType _WorkstationLogin = DBNull.Value;
            string WorkstationLogin = null;

            #region CRUD LoadToVariable
            var USERNAMESLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_WorkstationLogin,"WorkstationLogin"},
                },
                loadForChange: false,
                lockingType: LockingType.None,
                maximumRows: 1,
                tableName: "USERNAMES",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("USERNAME = {0}", Username),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var USERNAMESLoadResponse = this.appDB.Load(USERNAMESLoadRequest);
            if (USERNAMESLoadResponse.Items.Count > 0)
            {
                WorkstationLogin = _WorkstationLogin;
            }
            #endregion  LoadToVariable

            return WorkstationLogin;
        }

        public DataTable GetStatus(
            string BeginArCheckNum = null,
            string EndArCheckNum = null,
            DateTime? BeginPaymentDate = null,
            DateTime? EndPaymentDate = null)
        {
            #region CRUD LoadToRecord
            var ARPMTLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"PaymentApprovalStatus","arpmt.payment_approval_status"},
                    {"CFDIReceiptXmlFileName","mex.approved_xml_filename"},
                    {"ARpmtCheckNum","mex.arpmt_check_num"},
                },
                loadForChange: false,
                lockingType: LockingType.None,
                tableName: "ARPMT",
                fromClause: collectionLoadRequestFactory.Clause(" AS arpmt INNER JOIN MX_electronic_payment_receipt AS mex ON arpmt.check_num = mex.arpmt_check_num"),
                whereClause: collectionLoadRequestFactory.Clause("arpmt.check_num >= {1} AND arpmt.check_num <= {3} AND arpmt.recpt_date >= {0} AND arpmt.recpt_date <= {2}", BeginPaymentDate, BeginArCheckNum, EndPaymentDate, EndArCheckNum),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var ARPMTLoadResponse = this.appDB.Load(ARPMTLoadRequest);
            #endregion  LoadToRecord

            ICollectionLoadResponse Data = ARPMTLoadResponse;

            return recordCollectionToDataTable.ToDataTable(Data.Items);

        }

        public string GetProFormaInvNumByStamp(string IdDocumentApprovalStamp)
        {
            StringType _ProFormaInvNum = DBNull.Value;
            string ProFormaInvNum = null;

            #region CRUD LoadToVariable
            var pro_forma_inv_hdrLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_ProFormaInvNum,"pro_forma_inv_num"},
                },
                loadForChange: false,
                lockingType: LockingType.None,
                maximumRows: 1,
                tableName: "pro_forma_inv_hdr",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("pro_forma_document_approval_stamp = {0}", IdDocumentApprovalStamp),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var pro_forma_inv_hdrLoadResponse = this.appDB.Load(pro_forma_inv_hdrLoadRequest);
            if (pro_forma_inv_hdrLoadResponse.Items.Count > 0)
            {
                ProFormaInvNum = _ProFormaInvNum;
            }
            #endregion  LoadToVariable

            return ProFormaInvNum;
        }

    }
}
