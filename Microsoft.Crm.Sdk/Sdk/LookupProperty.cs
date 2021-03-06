using System;
using System.Xml.Serialization;

namespace Microsoft.Crm.Sdk
{
    [XmlType(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
    [Serializable]
    public class LookupProperty : Property
    {
        private Lookup valueField;

        public Lookup Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }

        internal override object GetValue()
        {
            return (object)this.Value;
        }

        internal override void SetValue(object value)
        {
            this.Value = (Lookup)value;
        }

        public LookupProperty()
        {
        }

        public LookupProperty(string name, Lookup value)
        {
            this.Name = name;
            this.Value = value;
        }
    }
}