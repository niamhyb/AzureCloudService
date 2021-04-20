using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

using System.Threading.Tasks;

namespace AzureData.Models
{
    //public enum RedundancyTypes {Geographically, Locally }
    public class DataStorage
    {
        public static String[] RedundancyTypes
        {
            get
            {
                return new String[] { "Geographically", "Locally" };
            }
        }
        const double GeoFirst = 0.125;
        const double GeoAfter = 0.11;
        const double LocFirst = 0.093;
        const double LocAfter= 0.083;
        // storaged used
        [Required(ErrorMessage = "Required field!")]
        [Range(2, Int32.MaxValue, ErrorMessage = "GB value must be > 0")]
        [DisplayName("Monthly Usage")]
        public int StoragedUsed { get; set; }
        // The size of the instance
        [Required(ErrorMessage = "Required field!")]
        [DisplayName("Redundancy Type")]
        public string RedundancyType { get; set; }
        [DataType(DataType.Currency)]
        [DisplayName("Storage Cost (€)")]
        public double StorageCost
        {
            get
            {
                double cost = 0.0;
                if(RedundancyType=="Geographically")
                {
                    if(StoragedUsed>1000)
                    {
                        cost = ((GeoFirst * 1000) + ((StoragedUsed - 1000) * GeoAfter));
                    }
                    else
                    {
                        cost = StoragedUsed * GeoFirst;
                    }
                }
                else
                {
                    if (StoragedUsed>1000)
                    {
                        cost = ((1000 * LocFirst) + ((StoragedUsed - 1000) * LocAfter));
                    }
                    else
                    {
                        cost = StoragedUsed * LocFirst;
                    }
                }
                return cost;
            }
        }
    }
}
