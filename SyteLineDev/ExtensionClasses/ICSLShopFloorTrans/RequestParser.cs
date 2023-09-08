using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml;
using System.IO;

namespace InforCollect.ERP.SL.ICSLShopFloorTrans
{
    class RequestParser
    {
        public Request parseRequest(String requestInputStr)
        {
            Request request = new Request();
            XmlDocument rootDoc = new XmlDocument();
            rootDoc.LoadXml(requestInputStr.Replace("&", "&amp;"));
            //rootDoc.LoadXml(requestInputStr);
            //Console.WriteLine("root Node " + rootDoc.Name + " coount of children = " + rootDoc.ChildNodes.Count);
            if (rootDoc.HasChildNodes)
            {
                XmlNode inputsNode = rootDoc.ChildNodes.Item(0);
                request.InputFieldsList = GetFields(inputsNode);
            }
            return request;
        }

        private List<Field> GetFields(XmlNode childNode)
        {
            List<Field> fieldsList = new List<Field>(1);
            if (childNode.HasChildNodes)
            {
                XmlNodeList fieldNodeList = childNode.ChildNodes;

                foreach (XmlNode fieldListNode in fieldNodeList)
                {
                    Field field = new Field();
                    foreach (XmlNode fieldvaluesNode in fieldListNode.ChildNodes)
                    {
                        if (fieldvaluesNode.NodeType.Equals(XmlNodeType.Element))
                        {
                            if (fieldvaluesNode.Name.Equals("name"))
                            {
                                field.Name = fieldvaluesNode.FirstChild.Value;
                            }
                            else if (fieldvaluesNode.Name.Equals("value"))
                            {
                                if (fieldvaluesNode.HasChildNodes)
                                {
                                    if (fieldvaluesNode.FirstChild == null || fieldvaluesNode.FirstChild.Value == null || fieldvaluesNode.InnerXml.StartsWith("Hours"))
                                    {
                                        field.Value = fieldvaluesNode.InnerXml;
                                    }
                                    else
                                    {
                                        field.Value = fieldvaluesNode.FirstChild.Value;
                                    }
                                }
                                else
                                {
                                    field.Value = "";
                                }
                            }
                            else if (fieldvaluesNode.Name.Equals("inputs"))
                            {
                                XmlAttributeCollection attributesCollection = fieldvaluesNode.Attributes;
                                foreach (XmlAttribute attribute in attributesCollection)
                                {
                                    if (attribute.Name.Equals("name"))
                                    {
                                        field.Name = attribute.Value;
                                        break;
                                    }
                                }
                                field.FieldList = GetFields(fieldvaluesNode);
                            }
                        }
                    }

                    fieldsList.Add(field);
                }
            }
            return fieldsList;
        }
    }
}


