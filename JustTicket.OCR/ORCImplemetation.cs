using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace JustTicket.OCR
{
    public class ORCImplemetation
    {
        /// <summary>
        /// 灰度化
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public double Grayize(double r, double g, double b)
        {
            return 0.229 * r + 0.587 * g + 0.114 * b;
        }

        /// <summary>
        /// 二值化
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public int BiValueize(double val)
        {
            return 0;
        }
    }
}
