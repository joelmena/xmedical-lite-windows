using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XMedicalLite_Windows.Tools
{
    public class Utility
    {

        public int Age(DateTime dateOfBirth)
        {
            int currentAge = DateTime.Now.Year - dateOfBirth.Year;
            currentAge = ((currentAge * 12) - Math.Abs(DateTime.Now.Month - dateOfBirth.Month)) / 12;
            if (DateTime.Now.Day == dateOfBirth.Day && DateTime.Now.Month == dateOfBirth.Month) { currentAge++; }
            return currentAge;
        }

        public int Age(DateTime dateOfBirth, DateTime dateOfExpedient)
        {
            int currentAge = DateTime.Now.Year - dateOfBirth.Year;
            currentAge = ((currentAge * 12) - Math.Abs(DateTime.Now.Month - dateOfBirth.Month)) / 12;
            if (DateTime.Now.Day == dateOfBirth.Day && DateTime.Now.Month == dateOfBirth.Month) { currentAge++; }
            int beforeAge = currentAge - (DateTime.Now.Year - dateOfExpedient.Year);
            return beforeAge;
        }
    }
}