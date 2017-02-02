using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

using PropertyChanged;

namespace ExchangeRates.Models
{
    [ImplementPropertyChanged]
    public class Valute
    {
        public Valute()
        {
        }

        [XmlAttribute]
        public string ID { get; set; }
        public int NumCode { get; set; }
        public string CharCode { get; set; }
        public int Nominal { get; set; }
        public string Name { get; set; }

        [XmlElement(ElementName = "Value")]
        public string ValueString { get; set; }

        [XmlIgnore]
        public decimal Value
        {
            get
            {
                return decimal.Parse(ValueString);
            }
            set
            {
                ValueString = value.ToString();
            }
        }
    }
}
