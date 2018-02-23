using System;
using System.Collections.Generic;

namespace ATM
{
    public class Account
    {
        public string name;
        public static int id = 0;
        public short pin;
        public decimal balance;

        public Account(string n, short p)
        {
            name = n;
            pin = p;
            balance = 0;
            id++;
        }

        public void deposit(decimal amount)
        {
            balance += amount;
        }

        public string withdraw(decimal amount)
        {
            if ((balance - amount) < 0)
            {
                string message = "Withdraw declined. Not enough money in balance.";
                return message;
            }
            else
            {
                balance = balance - amount;
                string message = "Amount withdrawn.";
                return message;
            }
        }

        public decimal get_balance()
        {
            return balance;
        }

        public int get_id()
        {
            return id;
        }

        public short get_pin()
        {
            return pin;
        }

        public Boolean verify_pin(int inputted_pin)
        {
            if (inputted_pin == pin)
                return true;
            else
                return false;
        }
    }

    public class Bank
    {
        Dictionary<int,Account> accounts = new Dictionary<int,Account>();

        public void add_account(Account acc)
        {
            accounts[acc.get_id()] = acc;
        }

        public Account get_account_by_id(int x)
        {
            return accounts[x];
        }
    }

}
