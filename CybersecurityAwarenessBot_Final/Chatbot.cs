using System;
using System.Threading;

public class Chatbot
{
    private User user = new User();

    public void Start()
    {
        Console.Title = "Cybersecurity Awareness Bot";
        ShowHeader();
        AudioPlayer.PlayGreeting();
        AskUserName();
        ChatLoop();
    }

    private void ShowHeader()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;

        Console.WriteLine(@"
 /$$$$$$            /$$                                 /$$                   /$$                     /$$$  
 /$$__  $$          | $$                                | $$                  | $$                    |_  $$ 
| $$  \__/ /$$   /$$| $$$$$$$   /$$$$$$   /$$$$$$       | $$$$$$$   /$$$$$$  /$$$$$$         /$$        \  $$
| $$      | $$  | $$| $$__  $$ /$$__  $$ /$$__  $$      | $$__  $$ /$$__  $$|_  $$_/        |__/         | $$
| $$      | $$  | $$| $$  \ $$| $$$$$$$$| $$  \__/      | $$  \ $$| $$  \ $$  | $$                       | $$
| $$    $$| $$  | $$| $$  | $$| $$_____/| $$            | $$  | $$| $$  | $$  | $$ /$$       /$$         /$$/
|  $$$$$$/|  $$$$$$$| $$$$$$$/|  $$$$$$$| $$            | $$$$$$$/|  $$$$$$/  |  $$$$/      | $/       /$$$/ 
 \______/  \____  $$|_______/  \_______/|__/            |_______/  \______/    \___/        |_/       |___/  
           /$$  | $$                                                                                         
          |  $$$$$$/                                                                                         
           \______/                                                                                          
");

        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("==============================================================");
        Console.WriteLine("             CYBERSECURITY AWARENESS CHATBOT");
        Console.WriteLine("==============================================================");
        Console.ResetColor();
        Console.WriteLine();

        TypeText("Welcome to the Cybersecurity Awareness Bot.");
        Console.WriteLine();
    }

    private void AskUserName()
    {
        string name = "";

        while (string.IsNullOrWhiteSpace(name))
        {
            Console.Write("Enter your name: ");
            name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Please enter a valid name.");
                Console.WriteLine();
            }
        }

        user.Name = name;
        Console.WriteLine();
        Console.WriteLine("Hello " + user.Name + ". I am here to help you stay safe online.");
        Console.WriteLine();
    }

    private void ShowQuestionList()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Choose a question from the list below or type your own question:");
        Console.ResetColor();
        Console.WriteLine("1. How are you?");
        Console.WriteLine("2. What is your purpose?");
        Console.WriteLine("3. What is phishing?");
        Console.WriteLine("4. What is malware?");
        Console.WriteLine("5. What is ransomware?");
        Console.WriteLine("6. How do I create a strong password?");
        Console.WriteLine("7. What is 2FA?");
        Console.WriteLine("8. What is social engineering?");
        Console.WriteLine("9. Is public Wi-Fi safe?");
        Console.WriteLine("10. What is a data breach?");
        Console.WriteLine("11. What does a firewall do?");
        Console.WriteLine("12. How can I browse safely online?");
        Console.WriteLine("13. How do I stay safe with emails?");
        Console.WriteLine("14. What is cybersecurity?");
        Console.WriteLine("Type 'exit' to close the program.");
        Console.WriteLine();
    }

    private void ChatLoop()
    {
        bool running = true;

        while (running)
        {
            ShowQuestionList();

            Console.Write(user.Name + ": ");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Please enter something.");
                Console.WriteLine();
                continue;
            }

            input = input.ToLower().Trim();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Bot: ");
            Console.ResetColor();

            if (input == "exit")
            {
                Console.WriteLine("Goodbye " + user.Name + ". Stay safe online.");
                running = false;
            }
            else if (input == "1" || input.Contains("how are you"))
            {
                Console.WriteLine("I am doing well and ready to help you with cybersecurity awareness.");
            }
            else if (input == "2" || input.Contains("what is your purpose") || input.Contains("your purpose"))
            {
                Console.WriteLine("My purpose is to teach users about cybersecurity and how to stay safe online.");
            }
            else if (input == "3" || input.Contains("phishing"))
            {
                Console.WriteLine("Phishing is a scam where criminals pretend to be trusted organisations to trick you into giving away personal information.");
            }
            else if (input == "4" || input.Contains("malware"))
            {
                Console.WriteLine("Malware is harmful software that can steal data, damage files or spy on your device.");
            }
            else if (input.Contains("virus"))
            {
                Console.WriteLine("A computer virus is a type of malicious program that spreads between files or systems and can damage your data.");
            }
            else if (input == "5" || input.Contains("ransomware"))
            {
                Console.WriteLine("Ransomware is malicious software that locks or encrypts your files and demands payment to restore access.");
            }
            else if (input == "6" || input.Contains("password"))
            {
                Console.WriteLine("A strong password should be long and include uppercase letters, lowercase letters, numbers and symbols. Avoid using personal information.");
            }
            else if (input == "7" || input.Contains("2fa") || input.Contains("two-factor") || input.Contains("two factor authentication"))
            {
                Console.WriteLine("Two-factor authentication adds extra security by requiring a second verification step besides your password.");
            }
            else if (input == "8" || input.Contains("social engineering"))
            {
                Console.WriteLine("Social engineering is when attackers manipulate people into revealing sensitive information or performing unsafe actions.");
            }
            else if (input.Contains("scam"))
            {
                Console.WriteLine("Be careful with unexpected messages, calls or emails asking for money, passwords, OTPs or banking details.");
            }
            else if (input.Contains("privacy"))
            {
                Console.WriteLine("Protect your privacy by limiting what you share online, checking app permissions and using secure account settings.");
            }
            else if (input == "9" || input.Contains("public wifi") || input.Contains("public wi-fi") || input.Contains("wifi"))
            {
                Console.WriteLine("Public Wi-Fi can be risky. Avoid logging into sensitive accounts on unsecured networks and use trusted connections whenever possible.");
            }
            else if (input.Contains("suspicious link") || input.Contains("link"))
            {
                Console.WriteLine("Do not click suspicious links. If you already clicked one, scan your device and change important passwords immediately.");
            }
            else if (input == "10" || input.Contains("data breach"))
            {
                Console.WriteLine("A data breach happens when confidential information is accessed, stolen or exposed without permission.");
            }
            else if (input == "11" || input.Contains("firewall"))
            {
                Console.WriteLine("A firewall helps block unwanted or suspicious traffic from entering your device or network.");
            }
            else if (input == "12" || input.Contains("safe browsing") || input.Contains("browsing"))
            {
                Console.WriteLine("Use trusted websites, avoid suspicious pop-ups, and check that sites are legitimate before entering personal details.");
            }
            else if (input == "13" || input.Contains("email safety") || input.Contains("email"))
            {
                Console.WriteLine("Do not open unknown attachments or click links from suspicious emails. Always verify the sender first.");
            }
            else if (input == "14" || input.Contains("cybersecurity"))
            {
                Console.WriteLine("Cybersecurity is the practice of protecting devices, networks and data from digital attacks and unauthorised access.");
            }
            else
            {
                Console.WriteLine("I do not understand that yet. Please choose a number from the list or ask about phishing, passwords, malware, ransomware, privacy, scams, public Wi-Fi, 2FA or safe browsing.");
            }

            Console.WriteLine();
        }
    }

    private void TypeText(string message)
    {
        foreach (char letter in message)
        {
            Console.Write(letter);
            Thread.Sleep(25);
        }

        Console.WriteLine();
    }
}
