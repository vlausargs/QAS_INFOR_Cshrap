using CSI.Data;
using System;
using System.Xml;
using CSI.MXLOC.Objects;
using System.Data;
using CSI.MXLOC.Interfaces;
using System.Data.SqlTypes;
using CSI.MG.IDM;

namespace CSI.MXLOC
{
    public interface IApprovedXML
    {
        (int? Severity, string Infobar) Process(string Infobar, string Username, string TenantID, string BeginProFormaInvNum, string EndProFormaInvNum, DateTime? BegiProFormaInvDate = null, DateTime? EndProFormaInvDate = null);
    }
    public class ApprovedXML : IApprovedXML
    {
        readonly IMsgApp msgApp;
        readonly IMXElectronicInvFactory mXElectronicInvFactory;
        readonly IApprovedXMLCRUD approvedXMLCRUD;
        readonly IIDM iDM;

        public ApprovedXML(IIDM IDM,
        IMsgApp msgApp,
        IMXElectronicInvFactory mXElectronicInvFactory,
        IApprovedXMLCRUD approvedXMLCRUD)
        {
            this.iDM = IDM;
            this.msgApp = msgApp;
            this.mXElectronicInvFactory = mXElectronicInvFactory;
            this.approvedXMLCRUD = approvedXMLCRUD;
        }

        public (int? Severity, string Infobar) Process(string Infobar, string Username, string TenantID, string BeginProFormaInvNum, string EndProFormaInvNum, DateTime? BeginProFormaInvDate, DateTime? EndProFormaInvDate)
        {
            int? severity = 0;
            int count = 0;

            if (BeginProFormaInvDate is null)
                BeginProFormaInvDate = Convert.ToDateTime(SqlDateTime.MinValue.Value);

            if (EndProFormaInvDate is null)
                EndProFormaInvDate = Convert.ToDateTime(SqlDateTime.MaxValue.Value);

            var data = approvedXMLCRUD.GetStatus(BeginProFormaInvDate, EndProFormaInvDate, BeginProFormaInvNum, EndProFormaInvNum);
            if (data.Rows.Count != 0)
            {
                foreach (DataRow item in data.Rows)
                {
                    string approvedXmlFileName = item["ApprovedXmlFileName"].ToString();
                    string status = item["ApprovalStatus"].ToString();

                    if (status == "S")
                    {
                        string workStationLogin = approvedXMLCRUD.GetWorkstationID(Username);
                        bool idmConnect = iDM.ConnectOAuth1(TenantID, workStationLogin);
                        string EntityName = "LCL_ProprietaryDocument";
                        string direction = "incoming";

                        if (idmConnect)
                        {
                            var fileObject = iDM.GetFileContent(approvedXmlFileName, EntityName, direction);
                            if (fileObject != null)
                            {
                                var xmlString = fileObject;
                                var mXElectronicInv = MapValuesFromXmlToObject(xmlString);

                                count += approvedXMLCRUD.UpdateDatabaseValue(mXElectronicInv, approvedXmlFileName).Count;
                                Infobar = count.ToString();
                            }
                        }
                        
                    }
                }
            }
            else
            {
                var msgNotApprovedStatus = msgApp.MsgAppSp(null, "MXNoApprovedStatusProcess", null);
                Infobar = msgNotApprovedStatus.Infobar;
                severity = msgNotApprovedStatus.ReturnCode;
            }
            return (severity, Infobar);
        }

        private IMXElectronicInv MapValuesFromXmlToObject(string xmlString)
        {
            string certificateDate = string.Empty;
            string digitalStampComplement = string.Empty;
            string digitalStampIssuer = string.Empty;
            string digitalStampSat = string.Empty;
            string proFormaInvNum = string.Empty;
            string receiptIssueDate = string.Empty;
            string satCertificateSerialNumber = string.Empty;
            string digitalStampSerialNumberIssuer = string.Empty;

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlString);

            XmlNamespaceManager nsmgr = new XmlNamespaceManager(xmlDoc.NameTable);
            nsmgr.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/3");
            nsmgr.AddNamespace("leyendasFisc", "http://www.sat.gob.mx/leyendasFiscales");
            nsmgr.AddNamespace("cce11", "http://www.sat.gob.mx/ComercioExterior11");
            nsmgr.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            nsmgr.AddNamespace("tfd", "http://www.sat.gob.mx/TimbreFiscalDigital");

            XmlElement root = xmlDoc.DocumentElement;
            XmlNode titleNode;

            titleNode = root.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/tfd:TimbreFiscalDigital/@FechaTimbrado", nsmgr);
            certificateDate = titleNode.InnerText;

            titleNode = root.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/tfd:TimbreFiscalDigital/@SelloCFD", nsmgr);
            digitalStampIssuer = titleNode.InnerText;

            titleNode = root.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/tfd:TimbreFiscalDigital/@SelloSAT", nsmgr);
            digitalStampSat = titleNode.InnerText;

            titleNode = root.SelectSingleNode("/cfdi:Comprobante/@Folio", nsmgr);
            proFormaInvNum = titleNode.InnerText;

            titleNode = root.SelectSingleNode("/cfdi:Comprobante/@Fecha", nsmgr);
            receiptIssueDate = titleNode.InnerText;

            titleNode = root.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/tfd:TimbreFiscalDigital/@NoCertificadoSAT", nsmgr);
            satCertificateSerialNumber = titleNode.InnerText;

            titleNode = root.SelectSingleNode("/cfdi:Comprobante/@NoCertificado", nsmgr);
            digitalStampSerialNumberIssuer = titleNode.InnerText;

            #region Get Sello/DigitalStampComplement Value
            string version = root.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/tfd:TimbreFiscalDigital/@Version", nsmgr).InnerText;
            string uuid = root.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/tfd:TimbreFiscalDigital/@UUID", nsmgr).InnerText;
            string fechaTimbrado = certificateDate;
            string rfcProvCertif = root.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/tfd:TimbreFiscalDigital/@RfcProvCertif", nsmgr).InnerText;
            string selloCFD = digitalStampIssuer;
            string noCertificadoSAT = satCertificateSerialNumber;

            #endregion

            string delimiter = "|";
            digitalStampComplement = "||" + version + delimiter + uuid + delimiter + fechaTimbrado + delimiter + rfcProvCertif + delimiter + selloCFD + delimiter + noCertificadoSAT + "||";
 
            var mXElectronicInv = mXElectronicInvFactory.Create(proFormaInvNum, Convert.ToDateTime(certificateDate), digitalStampComplement, digitalStampIssuer, digitalStampSat, Convert.ToDateTime(receiptIssueDate), satCertificateSerialNumber, digitalStampSerialNumberIssuer);

            return mXElectronicInv;
        }
    }
}
