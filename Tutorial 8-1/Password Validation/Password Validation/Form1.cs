using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Password_Validation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // The NumberUpperCase method accepts a string argument
        // and returns the number of uppercase letters it contains.
        private int NumberUpperCase(string str)
        {
            int upperCase = 0;  // The number of uppercase letters
            List<char> capitalChars = new List<char>();
            foreach(char stringChar in str)
            {
                if(char.IsUpper(stringChar))
                {
                    upperCase++;
                }
            }

            // Count the uppercase characters in str.
            // look at each individual character in the str 
            // and increment the count if that char is uppercase

            // Return the number of uppercase characters.
            return upperCase;
        }

        // The NumberLowerCase method accepts a string argument
        // and returns the number of lowercase letters it contains.
        private int NumberLowerCase(string str)
        {
            int lowerCase = 0;  // The number of lowercase letters

            // Count the lowercase characters in str.
            foreach(char stringChar in str)
            {
                if(char.IsLower(stringChar))
                {
                    lowerCase++;
                }
            }

            // Return the number of lowercase characters.
            return lowerCase;
        }

        // The NumberDigits method accepts a string argument
        // and returns the number of numeric digits it contains.
        private int NumberDigits(string str)
        {
            int digits = 0;  // The number of digits

            // Count the digits in str.
            foreach(char stringChar in str)
            {
                if(char.IsNumber(stringChar))
                {
                    digits++;
                }
            }


            // Return the number of digits.
            return digits;
        }

        private void checkPasswordButton_Click(object sender, EventArgs e)
        {
            const int MIN_LENGTH = 8;  // Password's minimum length

            // Get the password from the TextBox.
            string password = passwordTextBox.Text;
            bool isCorrectPassword = false;

            // Validate the password.

            if(password.Length >= MIN_LENGTH)
            {
                if(NumberUpperCase(password) >= 1)
                {
                    if(NumberLowerCase(password) >= 1)
                    {
                        if(NumberDigits(password) >= 1)
                        {
                            isCorrectPassword = true;
                        }
                    }
                }
            }

            if (isCorrectPassword)
            {
                MessageBox.Show("The password is valid.");
            }
            else
            {
                MessageBox.Show("The password does not meet " +
                    "the requirements.");
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }
    }
}
