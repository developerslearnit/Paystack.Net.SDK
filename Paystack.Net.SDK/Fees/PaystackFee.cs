using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paystack.Net.SDK.Fees
{
    public class PaystackFee
    {
        private const double DEFAULT_PERCENTAGE = 0.015;
        private const double DEFAULT_ADDITIONAL_CHARGE = 10000;
        private const double DEFAULT_THRESHOLD = 250000;
        private const double DEFAULT_CAP = 200000;

        double percentage = DEFAULT_PERCENTAGE;
        double additionalCharge = DEFAULT_ADDITIONAL_CHARGE;
        double threshold = DEFAULT_THRESHOLD;
        double cap = DEFAULT_CAP;

        double chargeDivider = 0;
        double crossover = 0;
        double flatlinePlusCharge = 0;
        double flatline = 0;

        public PaystackFee()
        {
            chargeDivider = ChargeDivider();
            crossover = Crossover();
            flatlinePlusCharge = FlatlinePlusCharge();
            flatline = Flatline();
        }

        public void withPercentage(double percentage)
        {
            this.percentage = percentage;

        }

        public void withAdditionalCharge(double additionalCharge)
        {
            this.additionalCharge = additionalCharge;
        }

        public void withThreshold(double threshold)
        {
            this.threshold = threshold;

        }

        public void withCap(double cap)
        {
            this.cap = cap;

        }

        double ChargeDivider()
        {
            return 1 - percentage;
        }

        double Crossover()
        {
            return (threshold * chargeDivider) - additionalCharge;
        }

        double FlatlinePlusCharge()
        {
            return (cap - additionalCharge) / percentage;
        }

        double Flatline()
        {
            return flatlinePlusCharge - cap;
        }


        public int AddCharge(int _amountinkobo)
        {
            int returnAmount = 0;
            double amountinkobo = double.Parse(_amountinkobo.ToString());
            if (amountinkobo > flatline)
            {
                returnAmount = (int)(Math.Round(amountinkobo + cap));
            }
            else if (amountinkobo > crossover)
            {
                returnAmount = (int)(Math.Round((amountinkobo + additionalCharge) / chargeDivider));
            }
            else
                returnAmount = (int)(Math.Round(amountinkobo / chargeDivider));


            return returnAmount;
        }




    }
}
