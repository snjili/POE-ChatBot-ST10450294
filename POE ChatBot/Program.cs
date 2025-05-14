using System;
using System.Media;
using System.IO;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;

namespace CybersecurityChatbot
{
    class Program
    {
        static void Main(string[] args)
        {
            // Play welcome audio
            new AudioPlayer();

            // Display ASCII logo
            new AsciiLogo();
        }
    }

    // Start the chatbot interface

    namespace memory_recall
    {
        public class Program
        {
            static void Main(string[] args)
            {
                //going to create this class to have method 
                //only 
                //three method 
                /*
                 * 1: checking file and create 
                 * 2: getting what is stored in the txt file
                 * 3: adding or writing into the txt file
                 * */
                Check_writeFile check_exist = new Check_writeFile();

                //Now use the object name check_exist
                //To get the method on the check_writeFile class

                //First class method to be called is check_file
                check_exist.check_file();

                // Second one is the getting the stored vaules in the file
                List<string> memory = check_exist.return_memory();

                // now list all the memory values
                foreach (string checks in memory)
                {
                    Console.WriteLine(checks);
                }// end of foreach

                // Now lets prompt the user and save what they
                // enter
                Console.WriteLine("Enter your name and question");
                string asking = Console.ReadLine();

                // Now store into the list and save to the file
                memory.Add(asking);

                // now aslo check into the file
                check_exist.save_memory(memory);



            }
        }
    }

}



public class AudioPlayer
{
    public AudioPlayer()
    {
        string projectLocation = AppDomain.CurrentDomain.BaseDirectory;
        string updatedPath = projectLocation.Replace("bin\\Debug\\", "").Replace("bin\\Release\\", "");
        string fullPath = Path.Combine(updatedPath, "Welcome audio.wav");

        PlayWav(fullPath);
    }

    private void PlayWav(string fullPath)
    {
        try
        {
            if (File.Exists(fullPath))
            {
                using SoundPlayer player = new SoundPlayer(fullPath);
                player.PlaySync();
            }
            else
            {
                Console.WriteLine("Audio file not found at: " + fullPath);
            }
        }
        catch (Exception error)
        {
            Console.WriteLine("Error playing audio: " + error.Message);
        }
    }
}

public class AsciiLogo
{
    public AsciiLogo()
    {
        string projectPath = AppDomain.CurrentDomain.BaseDirectory;
        string updatedPath = projectPath.Replace("bin\\Debug\\", "").Replace("bin\\Release\\", "");
        string fullPath = Path.Combine(updatedPath, "logo.jpg");

        try
        {
            if (File.Exists(fullPath))
            {
                using (Bitmap image = new Bitmap(fullPath))
                {
                    // Resize image for better ASCII display
                    Bitmap resizedImage = new Bitmap(image, new Size(100, 50));

                    Console.ForegroundColor = ConsoleColor.DarkGreen;

                    for (int height = 0; height < resizedImage.Height; height++)
                    {
                        for (int width = 0; width < resizedImage.Width; width++)
                        {
                            Color pixelColor = resizedImage.GetPixel(width, height);
                            int grayValue = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                            char asciiChar = GetAsciiChar(grayValue);
                            Console.Write(asciiChar);
                        }
                        Console.WriteLine();
                    }

                    Console.ResetColor();
                }
            }
            else
            {
                Console.WriteLine("Logo image not found at: " + fullPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error generating ASCII logo: " + ex.Message);
        }
    }

    private char GetAsciiChar(int grayValue)
    {
        // ASCII character gradient from darkest to lightest
        char[] asciiChars = { '@', '#', '8', '&', 'o', ':', '*', '.', ' ' };
        int index = grayValue * (asciiChars.Length - 1) / 255;
        return asciiChars[index];
    }
}



public class Chatbot
{
    private CyberSecurityBot bot;

    public void Run()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\nWelcome to the Cybersecurity Awareness Chatbot!");
        Console.ResetColor();

        Console.Write("\nPlease enter your name: ");
        string userName = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(userName))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Please enter a valid name.");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Please enter your name: ");
            userName = Console.ReadLine();
        }

        // Initialize the bot with the user's name
        bot = new CyberSecurityBot(userName);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\nHello, {userName}! How can I help you with cybersecurity today?");
        Console.ResetColor();

        bool continueChat = true;
        while (continueChat)
        {
            DisplayMenu();
            string input = Console.ReadLine()?.ToLower() ?? "";

            if (input == "exit")
            {
                continueChat = false;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nThank you for using the Cybersecurity Chatbot.");
                Console.ResetColor();
            }

        }
    }

    private void DisplayMenu()
    {
        throw new NotImplementedException();
    }

    class CyberSecurityBot
    {
        private ArrayList questions = new ArrayList();
        private ArrayList answers = new ArrayList();

        public CyberSecurityBot(string userName)
        {
            questions.Add("how are you");
            answers.Add(new ArrayList {
            $"I'm just a bot, {userName}, but I'm here to help you stay safe online!",
            "I'm functioning at optimal efficiency! How can I assist you today?"
        });

            questions.Add("purpose");
            answers.Add(new ArrayList {
            "My purpose is to educate you about cybersecurity and help you stay safe online.",
            "I'm here to provide tips and answer questions related to online safety and security."
        });

            questions.Add("password");
            answers.Add(new ArrayList {
            "A strong password should be at least 12 characters long, with a mix of letters, numbers, and symbols.",
            "Avoid using easily guessable passwords like '123456' or your name.",
            "Use a password manager to generate and store complex passwords securely."
        });

            questions.Add("phishing");
            answers.Add(new ArrayList {
            "Be cautious of emails asking for personal information. Scammers often disguise themselves as trusted organizations.",
            "Check the sender's email address and avoid clicking on suspicious links.",
            "Phishing emails often create a sense of urgency to trick you into revealing personal data."
        });

            questions.Add("safe browsing");
            answers.Add(new ArrayList {
            "Always check for 'https://' in the URL and avoid clicking on suspicious links.",
            "Keep your browser updated to protect against known vulnerabilities.",
            "Use trusted antivirus and anti-malware extensions for safer browsing."
        });

            questions.Add("vpn");
            answers.Add(new ArrayList {
            "A VPN encrypts your internet traffic, making it safer from hackers.",
            "VPNs help you maintain online privacy, especially on public Wi-Fi.",
            "Choose a reputable VPN service that doesn't log your data."
        });

            questions.Add("browsing");
            answers.Add(new ArrayList {
            "A browser is an application program that provides a way to look at and interact with all the information on the World Wide Web.",
            "Popular browsers include Chrome, Firefox, Safari, and Edge.",
            "Browsers can be enhanced with extensions to improve security and functionality."
        });

            questions.Add("social engineering");
            answers.Add(new ArrayList {
            "Social engineering manipulates victims to control systems or steal personal and financial data.",
            "Be cautious of people asking for sensitive info over the phone or via email.",
            "Attackers often impersonate authority figures to trick targets."
        });

            questions.Add("software attacks");
            answers.Add(new ArrayList {
            "Software attacks include malware, phishing, and SQL injection, compromising systems and data.",
            "Ensure your software is updated to patch known vulnerabilities.",
            "Firewalls and antivirus programs help detect and block software attacks."
        });

            questions.Add("computer security");
            answers.Add(new ArrayList {
            "Computer security is the protection of computer systems and networks from threats that lead to unauthorized access, theft, or damage.",
            "Implementing strong authentication methods is part of good computer security.",
            "Regular system updates and user awareness are key to computer security."
        });

            questions.Add("malware");
            answers.Add(new ArrayList {
            "Malware is intrusive software created by cybercriminals to steal data and damage or destroy computer systems. Examples include viruses.",
            "Avoid downloading software from untrusted sources to reduce the risk of malware.",
            "Use antivirus software to detect and remove malware threats."
        });
        }

        public void ProcessInput(string input)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            input = input.ToLower();

            bool found = false;

            for (int i = 0; i < questions.Count; i++)
            {
                if (input == questions[i].ToString().ToLower())
                {
                    ArrayList responseList = (ArrayList)answers[i];
                    foreach (string response in responseList)
                    {
                        Console.WriteLine(response);
                    }
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nI didn't understand that. Please ask a valid cybersecurity question.");
            }

            Console.ResetColor();
        }
    }
}
