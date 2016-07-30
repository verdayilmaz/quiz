using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz1_30072016
{
    public class Kahve:Icecekler
    {
        public string SutCesidi { get; set; }

        public string shot { get; set; }

        public IcecekBoyutu boyutu { get; set; }

        public decimal CalculateMoney (decimal shotParasi)
        {
            decimal boyutCarpani = 0;
            decimal sum;
            decimal sutToplami = 0;

            if (boyutu.IcecekBoyutuIsmı == "Tall")
            {
                boyutCarpani = 1;
            }
            else if (boyutu.IcecekBoyutuIsmı == "Grande")
            {
                boyutCarpani = 1.25m;
            }
            else if (boyutu.IcecekBoyutuIsmı == "Venti")
            {
                boyutCarpani = 1.75m;
            }

            if (SutCesidi == "Soya")
            {
                sutToplami = 0.5m;
            }
            else if (SutCesidi == "Yagsiz")
            {
                sutToplami = 0.5m;
            }
            else
            {
                sutToplami = 0;
            }

            sum = ((mainMoney * adet) * (boyutCarpani) + (adet * sutToplami) + (shotParasi * adet));
            return sum;
        }

        public override string ToString()
        {
            return IcecekIsmı;
        }
    }
}
