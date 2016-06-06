using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public abstract class ASandwich
    {
        protected ASandwich(SandwichBreadType sandwichBreadType, SandwichSauceType sandwichSauceType)
        {
            SandwichBreadType = sandwichBreadType;
            SandwichSauceType = sandwichSauceType;
        }
        protected SandwichBreadType SandwichBreadType { get; private set; }
        protected SandwichSauceType SandwichSauceType { get; private set; }
        public abstract decimal CustomSandwichProcess();
        public abstract decimal Discounts();

        public decimal GetSandwichPrice()
        {
            var sandwichPrice = 0.0M;
            sandwichPrice = getSandwichBreadPrice();
            sandwichPrice = sandwichPrice + CustomSandwichProcess();
            sandwichPrice = sandwichPrice - Discounts();
            return sandwichPrice;
        }

        private decimal getSandwichBreadPrice()
        {
            var breadPrice = 0.0M;
            switch (SandwichBreadType)
            {
                    case SandwichBreadType.WhiteBread:
                    breadPrice = 3.0M;
                    break;
                    case SandwichBreadType.ItalianBread:
                    breadPrice = 3.0M;
                    break;
                    case SandwichBreadType.WheatBread:
                    breadPrice = 3.0M;
                    break;
                    case SandwichBreadType.Unknown:
                     throw new Exception("Could not determine bread price due to unknown bread type");
                    break;
            }

            return breadPrice;
        }
    }

    public class ChickenSandwich : ASandwich
    {
        public ChickenSandwich(SandwichBreadType sandwichBreadType, SandwichSauceType sandwichSauceType)
            : base(sandwichBreadType,sandwichSauceType)
        {
        }

        public override decimal CustomSandwichProcess()
        {
            //Default for chicken sandwich
            //special chicken gravy
            //corn
            var splChickenGravy = 2.0M;
            var corn = 1.0M;

            return splChickenGravy+corn;
        }

        public override decimal Discounts()
        {
            return 0.0M;
        }
    }

    public class HamSandwich : ASandwich
    {
        public HamSandwich(SandwichBreadType sandwichBreadType, SandwichSauceType sandwichSauceType)
            : base(sandwichBreadType,sandwichSauceType)
        {
        }

        public override decimal CustomSandwichProcess()
        {
            //Default for Ham sandwich
            //special chicken gravy
            //corn
            var splHamGravy = 5.0M;
            var potato = 2.0M;
            return splHamGravy+potato;
        }

        public override decimal Discounts()
        {
            return 0.0M;
        }
    }

    public class NormalSandwich : ASandwich
    {
        public NormalSandwich(SandwichBreadType sandwichBreadType, SandwichSauceType sandwichSauceType)
            : base(sandwichBreadType, sandwichSauceType)
        {
        }

        public override decimal CustomSandwichProcess()
        {
            throw new NotImplementedException();
        }

        public override decimal Discounts()
        {
            throw new NotImplementedException();
        }
    }

    public enum SandwichBreadType
    {
        Unknown = 0,
        WhiteBread = 1,
        ItalianBread = 2,
        WheatBread=3,
    }

    public enum SandwichSauceType
    {
        Unknown = 0,
        LightMayo = 1,
        MixedMexicanMayo = 2,
        HotAndSpicy = 3,
        TomatoKetchup = 4,
    }

}
