using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InforCollect.ERP.SL.ICSLShopFloorTrans
{
    public class Request
    {
        private List<Field> inputFieldsList;

        public List<Field> InputFieldsList
        {
            get { return inputFieldsList; }
            set { inputFieldsList = value; }
        }

        public string GetFieldValue(string fieldName)
        {
            foreach (Field field in inputFieldsList)
            {
                if (field.Name != null)//if the line/field is null then do not try to read it. jh:20111201
                {
                    if (field.Name.Equals(fieldName))
                    {
                        return field.Value;
                    }
                }
            }
            return "";
        }

        public void SetFieldValue(string fieldName, string fieldValue)
        {
            Field searchField = null;
            if (inputFieldsList != null)
            {
                foreach (Field field in inputFieldsList)
                {
                    if (field.Name != null)//if the line/field is null then do not try to read it. jh:20111201
                    {
                        if (field.Name.Equals(fieldName))
                        {
                            searchField = field;
                            break;
                        }
                    }
                }
            }
            else
            {
                inputFieldsList = new List<Field>(1);
            }


            if (searchField == null)
            {
                searchField = new Field();
                searchField.Name = fieldName;
                searchField.Value = fieldValue;
                inputFieldsList.Add(searchField);
            }
            else
            {
                searchField.Value = fieldValue;
            }
        }

        public void AddField(Field field)
        {
            if (this.InputFieldsList == null)
            {
                InputFieldsList = new List<Field>(1);
            }
            this.InputFieldsList.Add(field);
        }

        public Field GetField(string fieldName)
        {
            foreach (Field field in inputFieldsList)
            {
                if (field.Name != null)
                {
                    if (field.Name.Equals(fieldName))
                    {
                        return field;
                    }
                }
            }
            return null;
        }

        public bool GetBoolFieldValue(string fieldName)
        {
            bool returnValue = false;
            foreach (Field field in inputFieldsList)
            {
                if (field.Name != null)
                {
                    if (field.Name.Equals(fieldName))
                    {
                        if (field.Value == null || field.Value.Trim().Equals(""))
                        {
                            returnValue = false;
                            break;
                        }
                        else
                        {
                            if (field.Value.Trim().ToLower().Equals("yes"))
                            {
                                returnValue = true;
                                break;
                            }
                            else
                            {
                                returnValue = false;
                                break;
                            }
                        }
                    }
                }
            }
            return returnValue;
        }


        private string inputIdentifier;

        public string InputIdentifier
        {
            get { return inputIdentifier; }
            set { inputIdentifier = value; }
        }

        public string GetInnerFieldValue(string parentFieldName, string innerfieldName)
        {
            Field parentField = null;
            foreach (Field field in inputFieldsList)
            {
                if (field.Name.Equals(parentFieldName))
                {
                    parentField = field;
                    break;
                }
            }

            if (parentField.FieldList == null)
            {
                return null;
            }

            foreach (Field iField in parentField.FieldList)
            {
                if (iField.Name.Equals(innerfieldName))
                {
                    return iField.Value;
                }

            }
            return null;
        }

        public Field GetNestedField()
        {
            foreach (Field field in this.inputFieldsList)
            {
                if (field.FieldList != null)
                {
                    return field;
                }
            }
            return null;
        }

        public Request MemberWiseClone()
        {
            Request request = new Request();

            request.inputIdentifier = this.inputIdentifier;
            List<Field> fieldsList = new List<Field>(1);
            foreach (Field field in InputFieldsList)
            {
                Field localField = field.MemberWiseClone();
                fieldsList.Add(localField);
            }
            request.InputFieldsList = fieldsList;
            return request;
        }

    }
}
