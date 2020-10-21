using System;

namespace LoanApplication
{
    class Loan
    {
        private double loanAmount;
        private double rate;
        private int numPayments;
        private double balance;
        private double totalInterestPaid;
        private double paymentAmount;
        private double principle;
        private double monthInterest;


        //Defult constructor
        public Loan()
        {

        }
        // constructor 
        public Loan(double loan, double interestRate , int years)
        {
            loanAmount = loan;
            if (interestRate < 1)
            {
                rate = interestRate;
            }
            else // In case direction aren't followed 
                rate = interestRate / 100; // convert to decimal.
            numPayments = 12 * years;
            totalInterestPaid = 0;
            DeterminePaymentAmount();
        }
        // Property accessing payment amount
        public double PaymentAmount
        {
            get
            {
                return paymentAmount;
            }
        }
        // Property setting and returning loan amount
        public double LoanAmount
        {
            set
            {
               loanAmount = value;
            }
            get
            {
                return loanAmount;
            }
        }
        // property setting and returning rate 
        
        
        public int Age
        {
            set
            {
                Age = value 

            }
            get
            {
                return Age
            }
        }
        
        public double Rate
        {
            set
            {
                rate = value;
            }
            get
            {
                return rate;
            }

        }
        public double Rate
        {
            set
            {
                rate = value;
            }
            get
            {
                return rate;
            }
            
        }
        // Property to set the numPayment , given years to finance  .
        // Returns the number of years using number of payment .
        public int Years
        {
            set
            {
                numPayments = value * 12;
            }
            get
            {
                return numPayments / 12;
            }

        }
        // Property for accessing total interst to be paid 
        public double TotalInterestPaid
        {
            get
            {
                return totalInterestPaid;
            }
        }
        // Determine payment amount based on number of years ,
        // loan amount , and rate .
        public void DeterminePaymentAmount()
        {
            double term;

            term = Math.Pow((1 + rate / 12.0), numPayments);
            paymentAmount = (loanAmount * rate / 12.0 * term)
                / (term - 1.0);
        }
        // Returns a string containing an amortization table.
        public string ReturnAmortizationSchedule()
        {
            string aSchedul = "Month\t\tINt.\t\tPrin.\t\tNew";
            aSchedul += "\nNo.\t\tPd.\t\tPd.\t\tBalacne\n";
            aSchedul += "----------\t\t-----------\t\t------\t-----\n";

            balance = loanAmount;
            for (int month = 1; month <= numPayments; month++)
            {
                CalculteMonthCharges(month, numPayments);
                aSchedul += month
                    + "\t"
                    + monthInterest.ToString("N2")
                    + "\t"
                    + principle.ToString("C")
                    + balance.ToString("C")
                    + "\n";
            }

            return aSchedul;

        }
        // Calculte monthly interest and new balance.
        public void CalculteMonthCharges(int month , int numPayments)
        {
            double payment = paymentAmount;
            monthInterest = rate / 12 * balance;
            if (month == numPayments)
            {
                principle = balance;
                payment = balance + monthInterest;

            }
            else
            {
                principle = payment - monthInterest;
            }
            balance -= principle;
        }
        // Calculate interset paid over the life of the loan 
        public void DetermineTotalIntersetPaid()
        {
            totalInterestPaid = 0;
            balance = loanAmount;
            for (int month = 1; month <= numPayments; month++)
            {
                CalculteMonthCharges(month, numPayments);
                totalInterestPaid += monthInterest;
            }
        }
        // Return information about the loan 
        public override string ToString()
        {
            return "\nLoan Amount : " +
                loanAmount.ToString("C") +
                "\nInterset Rate : " + rate +
                "\nNumber of Years for Loan : " +
                (numPayments / 12) +
                "\nMonthly payment : " +
                paymentAmount.ToString("C");
        }

    }

    
    
    class Program
    {
        static void Main(string[] args)
        {
            int years;
            double loanAmount;
            double intersetRate;
            string inValue;
            char anotherLoan = 'N';

            do
            {
                GetInputValues(out loanAmount,
                    out intersetRate, out years);
                Loan ln = new Loan(loanAmount, intersetRate, years);
                Console.WriteLine();
                Console.Clear();
                Console.WriteLine( );

                Console.WriteLine( ln.ReturnAmortizationSchedule());
                Console.WriteLine("Payment Amount : { 0:C}",
                    ln.PaymentAmount);
                Console.WriteLine("Interset Paid over life",
                    "of Loan : {0:C}",
                    ln.TotalInterestPaid);
                Console.Write("Do anouther Calculation? (Y or N");
                inValue = Console.ReadLine();
                anotherLoan = Convert.ToChar(inValue);
            } while ((anotherLoan =='Y')||(anotherLoan =='y'));                      
        }
        // Prompts user for loan data 
        public static void GetInputValues(out double loanAmount ,
            out double interestRate,
            out int years)
        {
            Console.Clear();
            loanAmount = GetLoanAmount();
            interestRate = GetInterstRate();
            years = GetYears();
        }
        public static double GetLoanAmount()
        {
            string sValue;
            double loanAmount;

            Console.Write("Please enter the loan amount : ");
            sValue = Console.ReadLine();
            while (double.TryParse(sValue, out loanAmount) == false)
            {
                Console.WriteLine("Invalid data entered " + 
                    "for loan amount ");
                Console.Write("\nPlease re-enter the loan amount : ");
                sValue = Console.ReadLine();
            }
            return loanAmount;
        }
        public static double GetInterstRate()
        {
            string sValue;
            double interestRate;

            Console.Write("Please enter interest Rate (as a decimal " +
                "value - i.e . .06): ");
            sValue = Console.ReadLine();
            while (double.TryParse(sValue, out interestRate) == false)
            {
                Console.WriteLine("Invalid data entered " +
                    "for loan amount ");
                Console.Write("\nPlease re-enter the interest rate : ");
                sValue = Console.ReadLine();
            }
            return interestRate;
        }
        public static int GetYears()
        {
            string sValue;
            int years;

            Console.Write("PLease enter the number of years for the loan : ");
            sValue = Console.ReadLine();
            while (int.TryParse(sValue, out years) == false)
            {
                Console.WriteLine("Invalid data entered " +
                    "for loan amount ");
                Console.Write("\nPlease re-enter the years : ");
                sValue = Console.ReadLine();
            }
            return years;
        }        
    }
}
