using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        [Required]
        public string  Name { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }

        public static readonly byte Unknown = 0; //constante, n pode ser alterada no codigo
        public static readonly byte InitialPlan = 1;
        public static readonly byte SecondaryPlan = 2;
        public static readonly byte ThirdPlan = 3;
        public static readonly byte TopPlan = 4;
    }
}