using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Builder
{
   public class Resident
    {
        //address
        public string StreetAddress, Postcode, City;
        //employment
        public string CompanyName, Position;
        public int AnnualIncome;

        public override string ToString()
        {
            return $"{nameof(StreetAddress)}: {StreetAddress}, {nameof(Postcode)}: {Postcode}, {nameof(City)}: {City}, {nameof(CompanyName)}: {CompanyName}, {nameof(Position)}: {Position}, {nameof(AnnualIncome)}: {AnnualIncome}"; 
        }
    }

    public class ResidentBuilder // facade
    {
        // reference!
        protected Resident resident = new Resident();

        public ResidentJobBuilder Works => new ResidentJobBuilder(resident);
        public ResidentAddressBuilder Lives => new ResidentAddressBuilder(resident);

        public static implicit operator Resident(ResidentBuilder rb)
        {
            return rb.resident;
        }
    }

    public class ResidentJobBuilder : ResidentBuilder
    {
        public ResidentJobBuilder(Resident resident)
        {
            this.resident = resident;
        }

        public ResidentJobBuilder At(string companyName)
        {
            resident.CompanyName = companyName;
            return this;
        }

        public ResidentJobBuilder AsA(string position)
        {
            resident.Position = position;
            return this;
        }

        public ResidentJobBuilder Earning(int amount)
        {
            resident.AnnualIncome = amount;
            return this;
        }
    }

    public class ResidentAddressBuilder : ResidentBuilder
    {
        public ResidentAddressBuilder(Resident resident)
        {
            this.resident = resident;
        }

        public ResidentAddressBuilder At(string addressName)
        {
            resident.StreetAddress = addressName;
            return this;
        }

        public ResidentAddressBuilder WithPostcode(string postcode)
        {
            resident.Postcode = postcode;
            return this;
        }

        public ResidentAddressBuilder In(string city)
        {
            resident.City = city;
            return this;
        }
    }
}
