using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PasswordGeneratorApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Optional: If you want to execute something when the form loads, you can add this method.
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnGeneratePassword_Click(object sender, EventArgs e)
        {
            
            txtPassword.Text = GeneratePassword();
        }

     
        private string GeneratePassword()
        {
            // Fixed components of the password
            string digits = "002";  // 2 digits from your registration number
            string lettersFromName = "im";  // Second letters from "Nida" and "Eman"
            string movieChars = "TO";  // Example characters from "THE FORT MUSTANG"
            string specialChars = "@$!&";  // Special characters excluding '#'

            // Pool of characters excluding '#'
            string characterPool = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789" + specialChars;

            // Random number generator
            Random random = new Random();
            StringBuilder passwordBuilder = new StringBuilder(digits + lettersFromName + movieChars);

            // Add remaining random characters to make the password 14 characters long
            while (passwordBuilder.Length < 14)
            {
                char nextChar = characterPool[random.Next(characterPool.Length)];
                if (nextChar != '#') // Exclude '#'
                {
                    passwordBuilder.Append(nextChar);
                }
            }

            // Shuffle the password for better randomness
            string password = Shuffle(passwordBuilder.ToString());

            // Validate password with regex to ensure it meets requirements (14 characters and no '#')
            if (Regex.IsMatch(password, @"^(?!.*#).{14}$"))
            {
                return password;
            }
            else
            {
                return "Password generation failed.";
            }
        }

        // Method to shuffle the characters in the string
        private string Shuffle(string input)
        {
            char[] array = input.ToCharArray();
            Random random = new Random();
            for (int i = array.Length - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                // Swap characters
                var temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
            return new string(array);
        }
    }
}
