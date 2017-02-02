using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Globalization;

using PropertyChanged;

namespace ExchangeRates.Models
{
    [ImplementPropertyChanged]
    public class ValCurs
    {
        public ValCurs()
        {
        }

        [XmlAttribute(AttributeName = "Date")]
        public string DateString { get; set; }

        [XmlIgnore]
        public DateTime Date
        {
            get
            {
                return DateTime.Parse(DateString);
            }
            set
            {
                DateString = value.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture);
            }
        }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "Valute")]
        public Valute[] Valutes { get; set; }
    }
}
