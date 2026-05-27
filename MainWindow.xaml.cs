using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Cyberbot___st10493347_
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<MessageItem> Messages { get; set; }

        private readonly Random random = new Random();

        private string userName = "";
        private string favouriteTopic = "";
        private string lastTopic = "";
        private bool waitingForName = true;

        private readonly Dictionary<string, List<string>> responses = new Dictionary<string, List<string>>
        {
            {
                "password",
                new List<string>
                {
                    "A password is a secret word or phrase that protects your accounts from unauthorised access. A strong password should include uppercase letters, lowercase letters, numbers, and symbols.",
                    "Good password safety means not using personal details like your name, surname, birthday, school name, or phone number because those can be guessed easily.",
                    "A strong password should be long, unique, and difficult to guess. You should also avoid using the same password on many accounts because one hacked account can expose the others."
                }
            },
            {
                "phishing",
                new List<string>
                {
                    "Phishing is when criminals send fake messages, emails, or links to trick people into giving away private information such as passwords, OTPs, or banking details.",
                    "A phishing message may look like it comes from a bank, school, delivery company, or social media platform, but the goal is to steal your information.",
                    "Phishing attacks often use fear or urgency. For example, they may say your account will be blocked unless you click a link immediately."
                }
            },
            {
                "malware",
                new List<string>
                {
                    "Malware is harmful software designed to damage your device, steal information, spy on your activity, or give attackers control of your system.",
                    "Malware can enter a device through unsafe downloads, fake apps, infected email attachments, or cracked software.",
                    "To reduce malware risks, only download files from trusted sources, keep your system updated, and avoid opening suspicious attachments."
                }
            },
            {
                "scam",
                new List<string>
                {
                    "A scam is a dishonest trick used to steal money, personal information, or account access from someone.",
                    "Scams often use pressure, fake rewards, fear, or emotional manipulation to make people act quickly without thinking.",
                    "A common scam may say you won a prize, but you must pay a small fee first. That is usually a warning sign."
                }
            },
            {
                "privacy",
                new List<string>
                {
                    "Online privacy means controlling what personal information you share and who can see it.",
                    "Protecting your privacy is important because criminals can use personal details to guess passwords, impersonate you, or target you with scams.",
                    "Good privacy habits include using private account settings, limiting what you post, checking app permissions, and avoiding sharing your location publicly."
                }
            },
            {
                "safe browsing",
                new List<string>
                {
                    "Safe browsing means using the internet carefully so that you avoid fake websites, unsafe downloads, pop-ups, and suspicious links.",
                    "When browsing, check that websites use HTTPS before entering private information like passwords or banking details.",
                    "Avoid clicking random pop-ups, fake download buttons, and links from unknown messages because they can lead to scams or malware."
                }
            },
            {
                "ransomware",
                new List<string>
                {
                    "Ransomware is a type of malware that locks or encrypts your files and then demands payment to unlock them.",
                    "Ransomware is dangerous because it can stop people or businesses from accessing important files, school work, or company systems.",
                    "The best protection against ransomware is regular backups, updated software, antivirus protection, and avoiding suspicious attachments."
                }
            },
            {
                "2fa",
                new List<string>
                {
                    "Two-factor authentication, also called 2FA, adds an extra security step after your password.",
                    "With 2FA, even if someone gets your password, they still need a second code or approval to access your account.",
                    "You should enable 2FA on important accounts such as email, banking, social media, and school portals."
                }
            },
            {
                "public wifi",
                new List<string>
                {
                    "Public Wi-Fi can be risky because other people on the same network may try to monitor traffic or trick users with fake networks.",
                    "Avoid logging into banking apps or private accounts on public Wi-Fi unless you are sure the connection is safe.",
                    "When using public Wi-Fi, avoid entering sensitive details and make sure websites use HTTPS."
                }
            },
            {
                "firewall",
                new List<string>
                {
                    "A firewall is a security tool that controls what network traffic is allowed to enter or leave your device.",
                    "Firewalls help block suspicious connections and reduce the chances of attackers reaching your device.",
                    "You should keep your firewall enabled, especially when using unfamiliar networks."
                }
            }
        };

        private readonly Dictionary<string, string> whyResponses = new Dictionary<string, string>
        {
            {
                "password",
                "Passwords are important because they act like keys to your accounts. If a password is weak or stolen, someone can access your email, social media, school portal, banking apps, or private files. Strong passwords reduce the chance of unauthorised access."
            },
            {
                "phishing",
                "Phishing is dangerous because it attacks the user directly instead of only attacking the computer. A fake message can trick someone into giving away their password or OTP, even if the device itself is not hacked."
            },
            {
                "malware",
                "Malware is dangerous because it can work silently in the background. It can steal passwords, damage files, slow down your device, record activity, or allow attackers to control your system."
            },
            {
                "scam",
                "Scams are dangerous because they manipulate people emotionally. Scammers often use fear, urgency, love, fake prizes, or pressure to make victims act quickly before thinking clearly."
            },
            {
                "privacy",
                "Privacy matters because personal information can be used against you. Criminals can use your birthday, location, school, phone number, or family details to guess passwords, impersonate you, or target you with more convincing scams."
            },
            {
                "safe browsing",
                "Safe browsing is important because many cyberattacks begin with one careless click. A fake website, pop-up, or download button can lead to stolen passwords, malware infections, or financial loss."
            },
            {
                "ransomware",
                "Ransomware is dangerous because it can block access to important files. For businesses, schools, and individuals, losing access to documents, projects, or records can cause serious disruption."
            },
            {
                "2fa",
                "2FA is important because passwords alone are not always enough. If someone steals your password, 2FA gives your account an extra layer of protection."
            },
            {
                "public wifi",
                "Public Wi-Fi is risky because you do not control the network. Attackers may create fake Wi-Fi networks or try to intercept information from users connected to the same network."
            },
            {
                "firewall",
                "Firewalls are important because they reduce unwanted network access. They help protect your device by blocking suspicious traffic before it reaches your system."
            }
        };

        private readonly Dictionary<string, string> howResponses = new Dictionary<string, string>
        {
            {
                "password",
                "To protect your passwords, create long passwords, avoid reusing them, never share them, and use 2FA where possible. A password manager can also help you store strong passwords safely."
            },
            {
                "phishing",
                "To avoid phishing, check the sender address, avoid urgent links, look for spelling mistakes, do not share OTPs, and confirm directly with the real company before entering details."
            },
            {
                "malware",
                "To avoid malware, download only from trusted websites, avoid cracked software, keep your antivirus updated, update your operating system, and never open unknown attachments."
            },
            {
                "scam",
                "To avoid scams, slow down before responding, verify the person or company, avoid sending money quickly, and never share private details with someone who contacted you unexpectedly."
            },
            {
                "privacy",
                "To protect your privacy, set accounts to private, limit personal posts, check app permissions, avoid public location sharing, and think before posting sensitive information."
            },
            {
                "safe browsing",
                "To browse safely, use trusted websites, check for HTTPS, avoid pop-ups, do not click fake download buttons, and avoid entering passwords on suspicious websites."
            },
            {
                "ransomware",
                "To protect yourself from ransomware, back up important files, avoid suspicious attachments, keep your software updated, and use reliable antivirus protection."
            },
            {
                "2fa",
                "To use 2FA, go to your account security settings and enable two-factor authentication. An authenticator app is usually safer than SMS because phone numbers can be targeted by SIM swap scams."
            },
            {
                "public wifi",
                "To stay safer on public Wi-Fi, avoid banking, avoid entering passwords, use HTTPS websites, and do not connect to networks with suspicious names."
            },
            {
                "firewall",
                "To use a firewall safely, keep it turned on, allow only trusted apps through it, and avoid disabling it unless you know exactly why."
            }
        };

        private readonly Dictionary<string, string> exampleResponses = new Dictionary<string, string>
        {
            {
                "password",
                "Example: A weak password is 'Thabiso123' because it uses a name and simple numbers. A stronger password would be longer, less predictable, and not connected to personal information."
            },
            {
                "phishing",
                "Example: You receive an email saying your bank account will be blocked unless you click a link. The link opens a fake website that looks like your bank. If you enter your login details, criminals steal them."
            },
            {
                "malware",
                "Example: You download a free game from an unknown website. The file secretly installs malware that steals saved passwords from your browser."
            },
            {
                "scam",
                "Example: Someone messages you saying you won a prize, but you must pay a small delivery fee first. That is a common scam technique."
            },
            {
                "privacy",
                "Example: If you publicly post your location, school, birthday, and daily routine, strangers or scammers can learn too much about you."
            },
            {
                "safe browsing",
                "Example: A fake website may look like a real login page, but the address is slightly different. If you enter your password there, attackers can steal it."
            },
            {
                "ransomware",
                "Example: You open a fake invoice attachment from an email. It installs ransomware and locks your files, then demands payment to unlock them."
            },
            {
                "2fa",
                "Example: Someone steals your Instagram password. If 2FA is enabled, they still cannot log in unless they also have your verification code."
            },
            {
                "public wifi",
                "Example: You connect to a free Wi-Fi network called 'Mall Free WiFi', but it is actually controlled by an attacker trying to capture user information."
            },
            {
                "firewall",
                "Example: If an unknown program tries to connect to the internet, a firewall can warn you or block that connection."
            }
        };

        public MainWindow()
        {
            InitializeComponent();

            try
            {
                // play greeting
                SoundPlayer sound = new SoundPlayer("Greeting.wav");
                sound.PlaySync();
            }
            catch
            {
                MessageBox.Show("Greeting.wav could not be played. Check the file name and make sure it is copied to the output folder.");
            }

            Messages = new ObservableCollection<MessageItem>();
            DataContext = this;

            StartChat();
        }

        private void StartChat()
        {
            AddBotMessage("Hey 👋 I am Cyber Bot.");
            AddBotMessage("Welcome to your Cybersecurity Awareness Assistant.");
            AddBotMessage("Enter your name:");
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            SendMessage();
        }

        private void txtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SendMessage();
            }
        }

        private void SendMessage()
        {
            string userMessage = txtMessage.Text.Trim();

            if (string.IsNullOrWhiteSpace(userMessage) || userMessage == "Text Message ....")
            {
                AddBotMessage("Please type a message so I can help you.");
                ClearInputAndScroll();
                return;
            }

            AddUserMessage(userMessage);

            if (waitingForName)
            {
                userName = ExtractName(userMessage);
                waitingForName = false;

                AddBotMessage("Nice to meet you, " + userName + ".");
                AddBotMessage("Now we can continue. You can ask me about passwords, phishing, malware, scams, privacy, safe browsing, ransomware, 2FA, public Wi-Fi, or firewalls.");
                AddBotMessage("You can also ask follow-up questions like 'why?', 'how?', 'give me an example', or 'tell me more'.");

                ClearInputAndScroll();
                return;
            }

            string reply = GetBotResponse(userMessage);
            AddBotMessage(reply);

            ClearInputAndScroll();
        }

        private string GetBotResponse(string message)
        {
            string input = message.ToLower().Trim();
            string sentiment = DetectSentiment(input);

            if (input == "bye" || input == "exit" || input == "quit")
            {
                return "Goodbye " + userName + ". Stay safe online.";
            }

            if (input.Contains("what do you remember") || input.Contains("remember about me"))
            {
                return GetMemoryResponse();
            }

            if (input.Contains("my name"))
            {
                return "Your name is " + userName + ". I remembered it from our conversation.";
            }

            if (input == "why" || input == "why?" || input.Contains("why is") || input.Contains("why does") || input.Contains("why should"))
            {
                if (!string.IsNullOrWhiteSpace(lastTopic) && whyResponses.ContainsKey(lastTopic))
                {
                    return whyResponses[lastTopic] + " You can also ask 'how?' if you want to know how to protect yourself.";
                }

                return "Tell me which topic you mean. For example, you can ask: why is phishing dangerous?";
            }

            if (input == "how" || input == "how?" || input.Contains("how can") || input.Contains("how do") || input.Contains("how to"))
            {
                if (!string.IsNullOrWhiteSpace(lastTopic) && howResponses.ContainsKey(lastTopic))
                {
                    return howResponses[lastTopic] + " You can also ask for an example if you want to understand it better.";
                }

                return "Tell me which topic you want help with. For example, you can ask: how can I avoid phishing?";
            }

            if (input.Contains("example") || input.Contains("give me an example"))
            {
                if (!string.IsNullOrWhiteSpace(lastTopic) && exampleResponses.ContainsKey(lastTopic))
                {
                    return exampleResponses[lastTopic];
                }

                return "Ask me about a topic first, then I can give you an example. For example: what is phishing?";
            }

            if (input.Contains("more") || input.Contains("another tip") || input.Contains("tell me more") || input.Contains("explain more"))
            {
                if (!string.IsNullOrWhiteSpace(lastTopic) && responses.ContainsKey(lastTopic))
                {
                    return sentiment + GetRandomResponse(lastTopic) + " You can ask 'why?', 'how?', or 'give me an example' for deeper understanding.";
                }

                return "Tell me which topic you want more information about, such as phishing, passwords, privacy, malware, scams, or safe browsing.";
            }

            if (input.Contains("how are you"))
            {
                return "I am doing well, " + userName + ". I am ready to help you understand cybersecurity in a simple way.";
            }

            if (input.Contains("purpose") || input.Contains("what do you do"))
            {
                return "My purpose is to teach users about cybersecurity. I explain online risks, show safe habits, and help users understand how to protect their information.";
            }

            string topic = DetectTopic(input);

            if (!string.IsNullOrWhiteSpace(topic))
            {
                lastTopic = topic;

                if (string.IsNullOrWhiteSpace(favouriteTopic))
                {
                    favouriteTopic = topic;
                }

                return sentiment + GetRandomResponse(topic) + " You can ask 'why?', 'how?', 'give me an example', or 'tell me more' for deeper understanding.";
            }

            return "I am not sure I understand that yet, " + userName + ". Try asking about passwords, phishing, malware, scams, privacy, safe browsing, ransomware, 2FA, public Wi-Fi, or firewalls.";
        }

        private string DetectTopic(string input)
        {
            if (input.Contains("password"))
            {
                return "password";
            }

            if (input.Contains("phishing"))
            {
                return "phishing";
            }

            if (input.Contains("malware") || input.Contains("virus"))
            {
                return "malware";
            }

            if (input.Contains("scam"))
            {
                return "scam";
            }

            if (input.Contains("privacy"))
            {
                return "privacy";
            }

            if (input.Contains("safe browsing") || input.Contains("browser"))
            {
                return "safe browsing";
            }

            if (input.Contains("ransomware"))
            {
                return "ransomware";
            }

            if (input.Contains("2fa") || input.Contains("two factor") || input.Contains("two-factor"))
            {
                return "2fa";
            }

            if (input.Contains("public wifi") || input.Contains("public wi-fi") || input.Contains("wifi"))
            {
                return "public wifi";
            }

            if (input.Contains("firewall"))
            {
                return "firewall";
            }

            return "";
        }

        private string GetRandomResponse(string topic)
        {
            List<string> topicResponses = responses[topic];
            int index = random.Next(topicResponses.Count);
            return topicResponses[index];
        }

        private string DetectSentiment(string input)
        {
            string[] worriedWords = { "worried", "scared", "afraid", "anxious", "nervous", "stressed", "panic" };
            string[] confusedWords = { "confused", "lost", "do not understand", "don't understand", "unsure", "not sure" };
            string[] curiousWords = { "curious", "interested", "want to know", "teach me", "explain" };

            if (worriedWords.Any(word => input.Contains(word)))
            {
                return "It is understandable to feel worried, " + userName + ". Here is something that can help: ";
            }

            if (confusedWords.Any(word => input.Contains(word)))
            {
                return "No stress, " + userName + ". I will explain it simply: ";
            }

            if (curiousWords.Any(word => input.Contains(word)))
            {
                return "Great question, " + userName + ". ";
            }

            return "";
        }

        private string GetMemoryResponse()
        {
            string memory = "";

            if (!string.IsNullOrWhiteSpace(userName))
            {
                memory += "I remember your name is " + userName + ". ";
            }

            if (!string.IsNullOrWhiteSpace(favouriteTopic))
            {
                memory += "I also remember that you are interested in " + favouriteTopic + ".";
            }

            if (string.IsNullOrWhiteSpace(memory))
            {
                return "I do not have any saved details yet.";
            }

            return memory;
        }

        private string ExtractName(string value)
        {
            string name = value.Trim();

            if (name.ToLower().Contains("my name is "))
            {
                name = name.Substring(name.ToLower().IndexOf("my name is ") + 11).Trim();
            }

            if (name.ToLower().StartsWith("i am "))
            {
                name = name.Substring(5).Trim();
            }

            if (name.ToLower().StartsWith("i'm "))
            {
                name = name.Substring(4).Trim();
            }

            return Capitalise(name);
        }

        private string Capitalise(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return "";
            }

            value = value.Trim();

            if (value.Length == 1)
            {
                return value.ToUpper();
            }

            return char.ToUpper(value[0]) + value.Substring(1);
        }

        private void AddUserMessage(string text)
        {
            Messages.Add(new MessageItem
            {
                Sender = string.IsNullOrWhiteSpace(userName) ? "You" : userName,
                Text = text,
                Time = DateTime.Now.ToString("HH:mm"),
                Alignment = HorizontalAlignment.Right,
                BubbleBackground = new SolidColorBrush(Color.FromRgb(220, 248, 198)),
                BubbleCornerRadius = new CornerRadius(16, 16, 3, 16),
                SenderColor = new SolidColorBrush(Color.FromRgb(7, 94, 84))
            });
        }

        private void AddBotMessage(string text)
        {
            Messages.Add(new MessageItem
            {
                Sender = "Cyber Bot",
                Text = text,
                Time = DateTime.Now.ToString("HH:mm"),
                Alignment = HorizontalAlignment.Left,
                BubbleBackground = Brushes.White,
                BubbleCornerRadius = new CornerRadius(16, 16, 16, 3),
                SenderColor = new SolidColorBrush(Color.FromRgb(37, 58, 236))
            });
        }

        private void ClearInputAndScroll()
        {
            txtMessage.Text = "";
            txtMessage.Focus();

            if (MessagesList.Items.Count > 0)
            {
                MessagesList.ScrollIntoView(MessagesList.Items[MessagesList.Items.Count - 1]);
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtMessage_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtMessage.Text == "Text Message ....")
            {
                txtMessage.Text = "";
                txtMessage.Foreground = Brushes.Black;
            }
        }

        private void txtMessage_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMessage.Text))
            {
                txtMessage.Text = "Text Message ....";
                txtMessage.Foreground = new SolidColorBrush(Color.FromRgb(90, 84, 84));
            }
        }
    }

    public class MessageItem
    {
        public string Sender { get; set; } = "";
        public string Text { get; set; } = "";
        public string Time { get; set; } = "";
        public HorizontalAlignment Alignment { get; set; }
        public Brush BubbleBackground { get; set; } = Brushes.White;
        public CornerRadius BubbleCornerRadius { get; set; }
        public Brush SenderColor { get; set; } = Brushes.Black;
    }
}