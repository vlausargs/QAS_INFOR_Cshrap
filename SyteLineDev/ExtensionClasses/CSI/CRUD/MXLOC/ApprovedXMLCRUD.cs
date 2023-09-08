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
    
    public class ApprovedXMLCRUD : IApprovedXMLCRUD
    {
        ICollectionLoadRequestFactory collectionLoadRequestFactory;
        IApplicationDB appDB;
        ICollectionUpdateRequestFactory collectionUpdateRequestFactory;
        IRecordCollectionToDataTable recordCollectionToDataTable;

        public ApprovedXMLCRUD(ICollectionLoadRequestFactory collectionLoadRequestFactory, IApplicationDB appDB, ICollectionUpdateRequestFactory collectionUpdateRequestFactory, IRecordCollectionToDataTable recordCollectionToDataTable)
        {
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.appDB = appDB;
            this.collectionUpdateRequestFactory = collectionUpdateRequestFactory;
            this.recordCollectionToDataTable = recordCollectionToDataTable;
        }

        public (int Count, string Infobar) UpdateDatabaseValue(IMXElectronicInv mXElectronicInv, string ApprovedXmlFileName)
        {
            int count = 0;
            string infobar = string.Empty;
            #region CRUD LoadToRecord MX_electronic_inv
            var MX_electronic_inv_mstLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
            {
            {"sat_certificate_date","MX_electronic_inv.sat_certificate_date"},
            {"issuer_digital_stamp","MX_electronic_inv.issuer_digital_stamp"},
            {"sat_digital_stamp","MX_electronic_inv.sat_digital_stamp"},
            {"receipt_issue_date","MX_electronic_inv.receipt_issue_date"},
            {"sat_certificate_serial_number","MX_electronic_inv.sat_certificate_serial_number"},
            {"issuer_digital_stamp_serial_number","MX_electronic_inv.issuer_digital_stamp_serial_number"},
            {"complement_digital_stamp","MX_electronic_inv.complement_digital_stamp"},
            },
            tableName: "MX_electronic_inv", 
            loadForChange: true, 
            lockingType: LockingType.UPDLock,
            fromClause: collectionLoadRequestFactory.Clause(""),
        whereClause: collectionLoadRequestFactory.Clause("pro_forma_inv_num = {1} AND approved_xml_filename = {0}", ApprovedXmlFileName, mXElectronicInv.ProFormaInvNum),
            orderByClause: collectionLoadRequestFactory.Clause(""));
            var MX_electronic_inv_mstLoadResponse = this.appDB.Load(MX_electronic_inv_mstLoadRequest);
            #endregion  LoadToRecord

            #region CRUD UpdateByRecord MX_electronic_inv
            foreach (var MX_electronic_inv_mstItem in MX_electronic_inv_mstLoadResponse.Items)
            {
                MX_electronic_inv_mstItem.SetValue<DateTime?>("sat_certificate_date", mXElectronicInv.SatCertificateDate);
                MX_electronic_inv_mstItem.SetValue<string>("issuer_digital_stamp", mXElectronicInv.DigitalStampIssuer);
                MX_electronic_inv_mstItem.SetValue<string>("sat_digital_stamp", mXElectronicInv.DigitalStampSat);
                MX_electronic_inv_mstItem.SetValue<DateTime?>("receipt_issue_date", mXElectronicInv.ReceiptIssueDate);
                MX_electronic_inv_mstItem.SetValue<string>("sat_certificate_serial_number", mXElectronicInv.SatCertificateSerialNumber);
                MX_electronic_inv_mstItem.SetValue<string>("issuer_digital_stamp_serial_number", mXElectronicInv.DigitalStampSerialNumberIssuer);
                MX_electronic_inv_mstItem.SetValue<string>("complement_digital_stamp", mXElectronicInv.DigitalStampComplement);
            };

            var MX_electronic_inv_mstRequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "MX_electronic_inv",
            items: MX_electronic_inv_mstLoadResponse.Items);

            this.appDB.Update(MX_electronic_inv_mstRequestUpdate);
            #endregion UpdateByRecord

            #region CRUD LoadToRecord pro_forma_inv_hdr
            var pro_forma_inv_hdrLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
            {
            {"electronic_inv_printed","pro_forma_inv_hdr.electronic_inv_printed"},
            },
            tableName: "pro_forma_inv_hdr", 
            loadForChange: true, 
            lockingType: LockingType.UPDLock,
            fromClause: collectionLoadRequestFactory.Clause(""),
        whereClause: collectionLoadRequestFactory.Clause("pro_forma_inv_num = {0}", mXElectronicInv.ProFormaInvNum),
            orderByClause: collectionLoadRequestFactory.Clause(""));
            var pro_forma_inv_hdrLoadResponse = this.appDB.Load(pro_forma_inv_hdrLoadRequest);
            #endregion  LoadToRecord

            #region CRUD UpdateByRecord pro_forma_inv_hdr
            foreach (var pro_forma_inv_hdrItem in pro_forma_inv_hdrLoadResponse.Items)
            {
                pro_forma_inv_hdrItem.SetValue<int?>("electronic_inv_printed", 1);
            };

            var pro_forma_inv_hdrRequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "pro_forma_inv_hdr",
            items: pro_forma_inv_hdrLoadResponse.Items);

            this.appDB.Update(pro_forma_inv_hdrRequestUpdate);
            #endregion UpdateByRecord

            count = MX_electronic_inv_mstLoadResponse.Items.Count;

            return (count, infobar);
        }
        public DataTable GetStatus(
            DateTime? BeginProFormaInvDate = null,
            DateTime? EndProFormaInvDate = null,
            string BeginProFormaInvNum = null,
            string EndProFormaInvNum = null)
        {
            ICollectionLoadResponse Data = null;

            #region CRUD LoadToRecord
            var pro_forma_inv_hdrLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
            {
            {"ApprovalStatus","A.pro_forma_approval_status"},
            {"ProFormaInvNum","A.pro_forma_inv_num"},
            {"ApprovedXmlFileName","B.approved_xml_filename"},
            },
            loadForChange: false, 
            lockingType: LockingType.None,
            tableName: "pro_forma_inv_hdr",
            fromClause: collectionLoadRequestFactory.Clause(" AS A INNER JOIN MX_electronic_inv AS B ON A.pro_forma_inv_num = B.pro_forma_inv_num"),
        whereClause: collectionLoadRequestFactory.Clause("(A.pro_forma_inv_date >= {0} AND A.pro_forma_inv_date <= {2}) AND (B.pro_forma_inv_num >= {1} AND B.pro_forma_inv_num <= {3})", BeginProFormaInvDate, BeginProFormaInvNum, EndProFormaInvDate, EndProFormaInvNum),
            orderByClause: collectionLoadRequestFactory.Clause(""));
            var pro_forma_inv_hdrLoadResponse = this.appDB.Load(pro_forma_inv_hdrLoadRequest);
            #endregion  LoadToRecord

            Data = pro_forma_inv_hdrLoadResponse;

            return recordCollectionToDataTable.ToDataTable(Data.Items);

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
    }
}
