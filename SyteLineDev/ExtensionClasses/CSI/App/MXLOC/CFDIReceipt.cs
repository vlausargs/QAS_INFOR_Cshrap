using CSI.Data;
using CSI.MG.IDM;
using CSI.MXLOC.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Xml;

namespace CSI.MXLOC
{
    public interface ICFDIReceipt
    {
        (int? Severity, string Infobar) Process(string Infobar, string Username, string TenantID, string BeginArCheckNum, string EndArCheckNum, DateTime? BeginPaymentDate, DateTime? EndPaymentDate);
    }
    public class CFDIReceipt : ICFDIReceipt
    {
        readonly IMsgApp msgApp;
        readonly IMXElectronicPaymentReceiptFactory mXElectronicPaymentReceiptFactory;
        readonly IMXElectronicPaymentReceiptDetailFactory mXElectronicPaymentReceiptDetailFactory;
        readonly ICFDIReceiptCRUD cFDIReceiptCRUD;
        readonly IIDM iDM;

        public CFDIReceipt(IIDM IDM,
        IMsgApp msgApp,
        IMXElectronicPaymentReceiptFactory mXElectronicPaymentReceiptFactory,
        IMXElectronicPaymentReceiptDetailFactory mXElectronicPaymentReceiptDetailFactory,
        ICFDIReceiptCRUD cFDIReceiptCRUD)
        {
            this.iDM = IDM;
            this.msgApp = msgApp;
            this.mXElectronicPaymentReceiptFactory = mXElectronicPaymentReceiptFactory;
            this.mXElectronicPaymentReceiptDetailFactory = mXElectronicPaymentReceiptDetailFactory;
            this.cFDIReceiptCRUD = cFDIReceiptCRUD;

        }

        public (int? Severity, string Infobar) Process(string Infobar, string Username, string TenantID, string BeginArCheckNum, string EndArCheckNum, DateTime? BeginPaymentDate, DateTime? EndPaymentDate)
        {
            int? severity = 0;
            int count = 0;

            if (BeginPaymentDate is null)
                BeginPaymentDate = Convert.ToDateTime(SqlDateTime.MinValue.Value);

            if (EndPaymentDate is null)
                EndPaymentDate = Convert.ToDateTime(SqlDateTime.MaxValue.Value);

            if (BeginArCheckNum is null)
                BeginArCheckNum = "0";
            if (EndArCheckNum is null)
                EndArCheckNum = Convert.ToString(Int32.MaxValue);


            var data = cFDIReceiptCRUD.GetStatus(BeginArCheckNum, EndArCheckNum, BeginPaymentDate, EndPaymentDate);
            if (data.Rows.Count != 0)
            {
                foreach (DataRow item in data.Rows)
                {
                    string CFDIReceiptXmlFileName = item["CFDIReceiptXmlFileName"].ToString();
                    string arPmtCheckNum = item["ARpmtCheckNum"].ToString();
                    string status = item["PaymentApprovalStatus"].ToString();

                    if (status == "S")
                    {
                        string workStationLogin = cFDIReceiptCRUD.GetWorkstationID(Username);
                        bool idmConnect = iDM.ConnectOAuth1(TenantID, workStationLogin);
                        string EntityName = "LCL_ProprietaryDocument";
                        string direction = "incoming";

                        if (idmConnect)
                        {
                            string fileContent = iDM.GetFileContent(CFDIReceiptXmlFileName, EntityName, direction);

                            if (fileContent != null)
                            {
                                var xmlString = fileContent;
                                // Map Values from XML
                                var mapValuesFromXmlToPaymentReceipt = MapValuesFromXmlToPaymentReceipt(xmlString, arPmtCheckNum);
                                var mapValuesFromXmlToPaymentReceiptDetail = MapValuesFromXmlToPaymentReceiptDetail(xmlString, arPmtCheckNum);

                                IMXElectronicPaymentReceipt mXElectronicPaymentReceipt = mapValuesFromXmlToPaymentReceipt;

                                foreach (var detail in mapValuesFromXmlToPaymentReceiptDetail)
                                {
                                    cFDIReceiptCRUD.UpdateDetailDatabaseValue(detail, CFDIReceiptXmlFileName);
                                }

                                count += cFDIReceiptCRUD.UpdateDatabaseValue(mXElectronicPaymentReceipt, CFDIReceiptXmlFileName).Count;
                                Infobar = count.ToString();
                            }
                        }
                    }
                }
            }

            return (severity, Infobar);
        }

        private IMXElectronicPaymentReceipt MapValuesFromXmlToPaymentReceipt(string xmlString, string arPmtCheckNum)
        {
            string proFormaInvNum = "";
            string paymentDocumentApprovalStamp = "";
            string paymentDate = "";
            string currCode = "";
            string satCertificateDate = "";
            string complementDigitalStamp = "";
            string issuerDigitalStamp = "";
            string satDigitalStamp = "";
            string receiptIssueDate = "";
            string satCertificateSerialNumber = "";
            string issuerDigitalStampSerialNumber = "";

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlString);

            XmlNamespaceManager nsmgr = new XmlNamespaceManager(xmlDoc.NameTable);
            nsmgr.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/3");
            nsmgr.AddNamespace("pago10", "http://www.sat.gob.mx/Pagos");
            nsmgr.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            nsmgr.AddNamespace("tfd", "http://www.sat.gob.mx/TimbreFiscalDigital");

            XmlElement root = xmlDoc.DocumentElement;
            XmlNode titleNode;

            titleNode = root.SelectSingleNode("/cfdi:Comprobante/@Folio", nsmgr);
            if (titleNode != null) proFormaInvNum = titleNode.InnerText;

            titleNode = root.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/tfd:TimbreFiscalDigital/@UUID", nsmgr);
            if (titleNode != null) paymentDocumentApprovalStamp = titleNode.InnerText;

            titleNode = root.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/pago10:Pagos/pago10:Pago/@FechaPago", nsmgr);
            if (titleNode != null) paymentDate = titleNode.InnerText;

            titleNode = root.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/pago10:Pagos/pago10:Pago/@MonedaP", nsmgr);
            if (titleNode != null) currCode = titleNode.InnerText;

            titleNode = root.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/tfd:TimbreFiscalDigital/@FechaTimbrado", nsmgr);
            if (titleNode != null) satCertificateDate = titleNode.InnerText;

            titleNode = root.SelectSingleNode("/cfdi:Comprobante/@Sello", nsmgr);
            if (titleNode != null) complementDigitalStamp = titleNode.InnerText;

            titleNode = root.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/tfd:TimbreFiscalDigital/@SelloCFD", nsmgr);
            if (titleNode != null) issuerDigitalStamp = titleNode.InnerText;

            titleNode = root.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/tfd:TimbreFiscalDigital/@SelloSAT", nsmgr);
            if (titleNode != null) satDigitalStamp = titleNode.InnerText;

            titleNode = root.SelectSingleNode("/cfdi:Comprobante/@Fecha", nsmgr);
            if (titleNode != null) receiptIssueDate = titleNode.InnerText;

            titleNode = root.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/tfd:TimbreFiscalDigital/@NoCertificadoSAT", nsmgr);
            if (titleNode != null) satCertificateSerialNumber = titleNode.InnerText;

            titleNode = root.SelectSingleNode("/cfdi:Comprobante/@NoCertificado", nsmgr);
            if (titleNode != null) issuerDigitalStampSerialNumber = titleNode.InnerText;

            var mXElectronicPaymentReceipt = mXElectronicPaymentReceiptFactory.Create(proFormaInvNum, arPmtCheckNum, paymentDocumentApprovalStamp, Convert.ToDateTime(paymentDate), currCode, Convert.ToDateTime(satCertificateDate), complementDigitalStamp, issuerDigitalStamp, satDigitalStamp, Convert.ToDateTime(receiptIssueDate), satCertificateSerialNumber, issuerDigitalStampSerialNumber);


            return mXElectronicPaymentReceipt;
        }

        private List<IMXElectronicPaymentReceiptDetail> MapValuesFromXmlToPaymentReceiptDetail(string xmlString, string arPmtCheckNum)
        {
            List<IMXElectronicPaymentReceiptDetail> mXElectronicPaymentReceiptDetails = new List<IMXElectronicPaymentReceiptDetail>();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlString);

            XmlNamespaceManager nsmgr = new XmlNamespaceManager(xmlDoc.NameTable);
            nsmgr.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/3");
            nsmgr.AddNamespace("pago10", "http://www.sat.gob.mx/Pagos");
            nsmgr.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            nsmgr.AddNamespace("tfd", "http://www.sat.gob.mx/TimbreFiscalDigital");

            XmlElement root = xmlDoc.DocumentElement;
            XmlNode titleNode;
            XmlNodeList xmlNodeList;

            string proFormaInvNum = "";
            string paymentDocumentApprovalStamp = "";

            titleNode = root.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/tfd:TimbreFiscalDigital/@UUID", nsmgr);
            if (titleNode != null) paymentDocumentApprovalStamp = titleNode.InnerText;

            string documentIdStamp = "";
            string paymentMethod = "";
            string currCodeDetail = "";
            int partialPaymentCount = 0;
            decimal previousAmount = 0;
            decimal paidAmount = 0;
            decimal balanceAmount = 0;

            xmlNodeList = root.SelectNodes("/cfdi:Comprobante/cfdi:Complemento/pago10:Pagos/pago10:Pago/pago10:DoctoRelacionado", nsmgr);

            foreach (XmlNode xmlNode in xmlNodeList)
            {
                titleNode = xmlNode.SelectSingleNode("@IdDocumento", nsmgr);
                if (titleNode != null) documentIdStamp = titleNode.InnerText;

                titleNode = xmlNode.SelectSingleNode("@MetodoDePagoDR", nsmgr);
                if (titleNode != null) paymentMethod = titleNode.InnerText;

                titleNode = xmlNode.SelectSingleNode("@MonedaDR", nsmgr);
                if (titleNode != null) currCodeDetail = titleNode.InnerText;

                titleNode = xmlNode.SelectSingleNode("@NumParcialidad", nsmgr);
                if (titleNode != null) partialPaymentCount = Convert.ToInt32(titleNode.InnerText);

                titleNode = xmlNode.SelectSingleNode("@ImpSaldoAnt", nsmgr);
                if (titleNode != null) previousAmount = Convert.ToDecimal(titleNode.InnerText);

                titleNode = xmlNode.SelectSingleNode("@ImpPagado", nsmgr);
                if (titleNode != null) paidAmount = Convert.ToDecimal(titleNode.InnerText);

                titleNode = xmlNode.SelectSingleNode("@ImpSaldoInsoluto", nsmgr);
                if (titleNode != null) balanceAmount = Convert.ToDecimal(titleNode.InnerText);

                proFormaInvNum = cFDIReceiptCRUD.GetProFormaInvNumByStamp(documentIdStamp);

                var mXElectronicPaymReceiptDetail = mXElectronicPaymentReceiptDetailFactory.Create(proFormaInvNum, paymentDocumentApprovalStamp, documentIdStamp, paymentMethod, currCodeDetail, partialPaymentCount, previousAmount, paidAmount, balanceAmount);

                mXElectronicPaymentReceiptDetails.Add(mXElectronicPaymReceiptDetail);
            }

            return mXElectronicPaymentReceiptDetails;
        }
    }
}
