using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ATM
{
    //Francesca and Julia wrote this class
    public class Account
    {
        public int accNum;
        private string name;
        private int pin;
        private decimal balance;

        public Account(int AccountNumber, string n, int p)
        {
            accNum = AccountNumber;
            name = n;
            pin = p;
            balance = 0;
        }

        public Account(int AccountNumber, string n, int p, decimal b)
        {
            accNum = AccountNumber;
            name = n;
            pin = p;
            balance = b;
        }

        public void deposit(decimal amount)
        {
            balance += amount;
        }

        public Boolean withdraw(decimal amount)
        {
            if ((balance - amount) < 0)
            {
                return false;
            }
            else
            {
                balance = balance - amount;
                return true;
            }
        }

        public decimal get_balance()
        {
            return balance;
        }

        public string get_name()
        {
            return name;
        }

        public int get_acc_num()
        {
            return accNum;
        }

        public Boolean verify_pin(int inputted_pin)
        {
            if (inputted_pin == pin)
                return true;
            else
                return false;
        }

        public string toString()
        {
            string account_string = $"{accNum.ToString()},{name},{pin.ToString()},{balance.ToString()}";
            return account_string;
        }
    }

    //Francesca and Julia wrote this class
    public class Bank
    {
        Dictionary<int, Account> accounts = new Dictionary<int, Account>();

        public Bank()
        {
           
        }

        public void add_account(Account acc)
        {
            accounts[acc.accNum] = acc;
        }

        public Account get_account_by_number(int AccountNumber)
        {
            try
            {
                return accounts[AccountNumber];
            }
            catch
            {
                return null;
            }
        }

        public void update_file()
        {
            StreamWriter sw = new StreamWriter("BankRecords.txt", false);
            foreach (KeyValuePair<int, Account> entry in accounts)
            {
                sw.WriteLine(entry.Value.toString());
            }
            sw.Close();
        }

        public void restore_file()
        {
            /*
             * Restores account data from text file
             */

            StreamReader sr = new StreamReader("BankRecords.txt");
            string[] lines = System.IO.File.ReadAllLines("BankRecords.txt");
            foreach (string line in lines)
            {
                try
                {
                    //Seperates line into fields deliminated by commas
                    string[] lineArray = line.Split(',');
                    int acc_num = Convert.ToInt32(lineArray[0]);
                    string name = lineArray[1];
                    int pin = Convert.ToInt32(lineArray[2]);
                    decimal balance = Convert.ToDecimal(lineArray[3]);

                    //Adds account with specified fields to the bank dictionary
                    Account new_account = new Account(acc_num, name, pin, balance);
                    accounts[new_account.get_acc_num()] = new_account;
                }
                catch { }
            }
            sr.Close();
        }
    }
}
