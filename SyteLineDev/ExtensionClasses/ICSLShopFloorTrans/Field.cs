using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InforCollect.ERP.SL.ICSLShopFloorTrans
{
    public class Field
    {

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string value;

        public string Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        private List<Field> fieldList = null;

        //internal List<Field> FieldList
        public List<Field> FieldList
        {
            get { return fieldList; }
            set { fieldList = value; }
        }

        public Field MemberWiseClone()
        {
            Field newField = new Field();
            newField.Name = this.Name;
            newField.Value = this.Value;

            if (this.FieldList != null)
            {
                List<Field> innerFieldList = new List<Field>(1);
                foreach (Field innerField in this.FieldList)
                {
                    Field innerLocalField = new Field();
                    innerLocalField.Name = innerField.Name;
                    innerLocalField.Value = innerField.Value;
                    innerFieldList.Add(innerLocalField);
                }
                newField.FieldList = innerFieldList;
            }
            return newField;
        }
    }
}
