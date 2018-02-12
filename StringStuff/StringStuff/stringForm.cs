using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace String_Stuff
{
    public partial class stringForm : Form
    {
        public stringForm()
        {
            InitializeComponent();
        }
        //form level constant for the plain alphabet so it can be called in methods
        const string PLAIN_ALPHABET = "abcdefghijklmnopqrstuvwxyz";

        private string SwitchCase(string input)
        {
            //switch the case of each character in the string
            string output = "";
            //for each character in the string check if its an upper or a lower
            foreach(char ch in input)
            {
                if(char.IsUpper(ch))
                {
                    output = output + char.ToLower(ch);
                }
                else if(char.IsLower(ch))
                {
                    output = output + char.ToUpper(ch);
                }
                else
                {
                    output = output + ch;
                }
            }

            return output;
        }

        private string Reverse(string input)
        {
            string output = "";
            char[] charInput = input.ToCharArray();
            for(int i = input.Length-1; i >= 0; i--)
            {
                output = output + charInput[i];
            }

            return output;
        }

        private string PigLatin(string input)
        {
            //take the first char, put it at the end of each word in the input, then add ay to the end of the word
            string output = "";
            const string vowels = "AEIOUaeiou";     //vowels

            foreach (string word in input.Split(' '))
            {
                //create variables for letters and rest of the word. IndexOf the first letter out of the vowels
                char firstLetter = char.Parse(word.Substring(0, 1));
                string restOfWord = word.Substring(1, word.Length - 1);
                int spotFirstLetter = vowels.IndexOf(firstLetter);

                if(spotFirstLetter == -1)
                {
                    firstLetter = char.ToLower(firstLetter);
                    output = output + restOfWord + firstLetter + "ay ";
                }
                else
                {
                    output = output + word + "way ";
                }
            }

            return output;
        }

        private string ShiftCypher(string input, int charsToShift)
        {
            string output = "";

            //take the input and split it into an array of strings with a delimiter

            foreach (string word in input.Split(' '))
            {
                //create an array of chars from the word
                char[] shiftedWord = word.ToCharArray();
                //go through each character and shift it.
                for (int i = 0; i < shiftedWord.Length; i++)
                {
                    char letter = shiftedWord[i];
                    letter = (char)(letter + charsToShift);
                    //if statement to ensure that the letter is within the range of char
                    if(letter > 'z')
                    {
                        letter = (char)(letter - 26);
                    }
                    else if (letter < 'a')
                    {
                        letter = (char)(letter + 26);
                    }

                    shiftedWord[i] = letter;
                }
                //create a string out the newly shifted array of chars
                output = output + new string(shiftedWord) + " ";
            }
            return output;
        }

        private string SubCypher(string input, string charsToSub)
        {
            string output = "";
            //create an array of chars from the new alphabet
            char[] newAlphabet = charsToSub.ToCharArray();
            char[] oldAlphabet = PLAIN_ALPHABET.ToCharArray();

            foreach (string word in input.Split(' '))
            {
                //create an array of chars from the word
                char[] shiftedWord = word.ToCharArray();

                //for each character in the shiftedWord swap it
                //with the same index in the new alphabet
                //nested if statements to make sure that any digits and spaces pursist
                
                for(int i = 0; i < shiftedWord.Length; i++)
                {
                    char letter = shiftedWord[i];

                    if (char.IsLetter(letter))
                    {
                        int oldLetterIndex = Array.IndexOf(oldAlphabet, char.ToLower(shiftedWord[i]));
                        if (char.IsLower(letter))
                        {
                            letter = newAlphabet[oldLetterIndex];
                            shiftedWord[i] = letter;
                        }
                        else
                        {
                            letter = char.ToUpper(newAlphabet[oldLetterIndex]);
                            shiftedWord[i] = letter;
                        }
                    }

                }
                
                //save it in the output
                output = output + new string(shiftedWord) + " ";
            }

            return output;
        }

        private void transformButton_Click(object sender, EventArgs e)
        {
            string input = inputTextBox.Text;
            Random rand = new Random();
            try
            {
                switchCaseTextBox.Text = SwitchCase(input);
                reverseTextBox.Text = Reverse(input);
                pigLatinTextBox.Text = PigLatin(input);
                shiftTextBox.Text = ShiftCypher(input, rand.Next(25));
                subTextBox.Text = SubCypher(input, ShiftCypher(PLAIN_ALPHABET, rand.Next(25)));
            }
            catch(Exception ex1)
            {
                MessageBox.Show(ex1.Message);
            }
        }
    }
}
