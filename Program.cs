using System;
using System.Collections.Generic;
using System.IO;

namespace MiniBankSystemProject
{
    internal class Program
    {



        /* ====================== Constants ======================= */
        const double MinimumBalance = 50.0;
        const string AccountsFilePath = "accounts.txt";
        const string ReviewsFilePath = "reviews.txt";
        const string LoanRequestsFilePath = "loan_requests.txt";





        /* ====================== Global Variables (List, Queue, Stacks) ====================== */
        // Queue to store account opening requests
        public static Queue<string> accountOpeningRequests = new Queue<string>();



        //Lists to store accounts Info
        public static List<int> accountNumbersL = new List<int>();
        public static List<string> accountNamesL = new List<string>();
        public static List<double> balancesL = new List<double>();
        
        public static List<string> RejectedAccountReqL = new List<string>();
        public static List<string> LoanRequestsL = new List<string>();

        //Stack to store Reviews 
        public static Stack<string> ReviewsS = new Stack<string>();


        //Account number generator
        static int lastAccountNumber;


        //Get Account Function
        static int GetAccountIndex()
        {
            Console.Write("Enter account number: ");
            try
            {
                int accNum = Convert.ToInt32(Console.ReadLine());
                int index = accountNumbersL.IndexOf(accNum);

                if (index == -1)
                {
                    Console.WriteLine("Account not found.");
                    return -1;
                }

                return index;
            }
            catch
            {
                Console.WriteLine("Invalid input.");
                return -1;
            }
        }





        /* ====================== Main Function ====================== */
        public static void Main(string[] args)
        { 
            StartSystem();
        }






        /* ====================== Startup & Navigation Functions ====================== */

        // Displays the welcome message and handles user choice
        public static void DisplayWelcomeMessage()
        {
            Console.WriteLine("╔══════════════════════════════════════════════════════╗");
            Console.WriteLine("║         WELCOME TO KHALFANOVISKI BANK SYSTEM         ║");
            Console.WriteLine("╠══════════════════════════════════════════════════════╣");
            Console.WriteLine("║                                                      ║");
            Console.WriteLine("║ Please select an option:                             ║");
            Console.WriteLine("║                                                      ║");
            Console.WriteLine("║ 1. Admin Application                                 ║");
            Console.WriteLine("║                                                      ║");
            Console.WriteLine("║ 2. User Application                                  ║");
            Console.WriteLine("║                                                      ║");
            Console.WriteLine("║ 0. Exit Application                                  ║");
            Console.WriteLine("║                                                      ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════╝");
            Console.Write("Enter your choice: ");

            int choice;
            bool on = true;

            do
            {
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        on = false;
                        ShowMainMenuAdmin();
                        break;
                    case 2:
                        ShowMainMenuUser();
                        break;
                    case 0:
                        on = false;
                        ExitApplication();
                        break;
                    default:
                        Console.WriteLine("Invalid choice! Try again.");
                        break;
                }
            } while (on);
        }

        // Displays the main menu for admin
        public static int ShowMainMenuAdmin()
        {
            // Main menu loop
            while (true)
            {
                Console.Clear();
                Console.WriteLine("╔══════════════════════════════════════════════════════╗");
                Console.WriteLine("║     ADMIN MAIN MENU - KHALFANOVISKI BANK SYSTEM      ║");
                Console.WriteLine("╠══════════════════════════════════════════════════════╣");
                Console.WriteLine("║                                                      ║");
                Console.WriteLine("║                                                      ║");
                Console.WriteLine("║ 1. View Requests                                     ║");
                Console.WriteLine("║                                                      ║");
                Console.WriteLine("║ 2. View Accounts                                     ║");
                Console.WriteLine("║                                                      ║");
                Console.WriteLine("║ 3. View Reviews                                      ║");
                Console.WriteLine("║                                                      ║");
                Console.WriteLine("║ 4. Process Request                                   ║");
                Console.WriteLine("║                                                      ║");
                Console.WriteLine("║ 5. Loan Requests                                     ║");
                Console.WriteLine("║                                                      ║");
                Console.WriteLine("║ 6. Suspend Account                                   ║");
                Console.WriteLine("║                                                      ║");
                Console.WriteLine("║ 7. Search Account                                    ║");
                Console.WriteLine("║                                                      ║");
                Console.WriteLine("║ 8. Update Acoount Details                            ║");
                Console.WriteLine("║                                                      ║");
                Console.WriteLine("║ 9. Delete Account                                    ║");
                Console.WriteLine("║                                                      ║");
                Console.WriteLine("║ 0. Go To MAIN MENU                                   ║");
                Console.WriteLine("║                                                      ║");
                Console.WriteLine("║                                                      ║");
                Console.WriteLine("╚══════════════════════════════════════════════════════╝");

                Console.Write("Enter your choice: ");

                try
                {
                    // Get user choice
                    int choice = int.Parse(Console.ReadLine());

                    // Handle user choice
                    switch (choice)
                    {
                        /*======================== View Requests =========================*/
                        case 1:
                            ViewRequests();
                            break;

                        /*======================== View Accounts =========================*/
                        case 2:
                            ViewAccounts();
                            break;

                        /*======================== View Reviews =========================*/
                        case 3:
                            ViewReviews();
                            break;

                        /*======================== Process Request =========================*/
                        case 4:
                            ProcessRequest();
                            break;

                        /*======================== Loan Requests =========================*/
                        case 5:
                            LoanRequestss();
                            break;

                        /*======================== Suspend Account =========================*/
                        case 6:
                            SuspendAccount();
                            break;

                        /*======================== Search Account =========================*/
                        case 7:
                            SearchAccount();
                            break;

                        /*======================== Update Account Details =========================*/
                        case 8:
                            UpdateAccountDetails();
                            break;

                        /*======================== Delete Account =========================*/
                        case 9:
                            DeleteAccount();
                            break;                     

                        /*======================== Exit Application =========================*/
                        case 0:
                            goBack();
                            break;


                        // Invalid choice
                        default:
                            Console.WriteLine("Invalid choice! Try again.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    // Handle invalid input
                    Console.WriteLine("Invalid input format. Please enter a number.");
                }
                catch (Exception ex)
                {
                    // Handle unexpected errors
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }

                Console.WriteLine("\nPress Enter to Go Back To Menu...");
                Console.ReadLine();
            }
        }

        // Displays the main menu for user
        public static int ShowMainMenuUser()
        {
            // Main menu loop
            while (true)
            {
                Console.Clear();
                Console.WriteLine("╔══════════════════════════════════════════════════════╗");
                Console.WriteLine("║      USER MAIN MENU - KHALFANOVISKI BANK SYSTEM      ║");
                Console.WriteLine("╠══════════════════════════════════════════════════════╣");
                Console.WriteLine("║                                                      ║");
                Console.WriteLine("║                                                      ║");
                Console.WriteLine("║ 1. Request Account Opening                           ║");
                Console.WriteLine("║                                                      ║");
                Console.WriteLine("║ 2. Deposite                                          ║");
                Console.WriteLine("║                                                      ║");
                Console.WriteLine("║ 3. Withdraw                                          ║");
                Console.WriteLine("║                                                      ║");
                Console.WriteLine("║ 4. Check Balance                                     ║");
                Console.WriteLine("║                                                      ║");
                Console.WriteLine("║ 5. Loan                                              ║");
                Console.WriteLine("║                                                      ║");
                Console.WriteLine("║ 6. Send Money                                        ║");
                Console.WriteLine("║                                                      ║");
                Console.WriteLine("║ 7. Account Details                                   ║");
                Console.WriteLine("║                                                      ║");
                Console.WriteLine("║ 8. Update Acoount Details                            ║");
                Console.WriteLine("║                                                      ║");
                Console.WriteLine("║ 9. Delete Account                                    ║");
                Console.WriteLine("║                                                      ║");
                Console.WriteLine("║ 10. Make Review                                      ║");
                Console.WriteLine("║                                                      ║");
                Console.WriteLine("║ 0. Go To MAIN MENU                                   ║");
                Console.WriteLine("║                                                      ║");
                Console.WriteLine("║                                                      ║");
                Console.WriteLine("╚══════════════════════════════════════════════════════╝");

                Console.Write("Enter your choice: ");

                try
                {
                    // Get user choice
                    int choice = int.Parse(Console.ReadLine());

                    // Handle user choice
                    switch (choice)
                    {
                        /*======================== Request Account Opening =========================*/
                        case 1:
                            RequestAccountOpening();
                            break;

                        /*======================== Deposit =========================*/
                        case 2:
                            Deposit();
                            break;

                        /*======================== Withdraw =========================*/
                        case 3:
                            Withdraw();
                            break;

                        /*======================== Check Balance =========================*/
                        case 4:
                            CheckBalance();
                            break;

                        /*======================== Loan =========================*/
                        case 5:
                            Loan();
                            break;

                        /*======================== Send Money =========================*/
                        case 6:
                            SendMoney();
                            break;

                        /*======================== Account Details =========================*/
                        case 7:
                            AccountDetails();
                            break;

                        /*======================== Update Account Details =========================*/
                        case 8:
                            UpdateUserAccountDetails();
                            break;

                        /*======================== Delete Account =========================*/
                        case 9:
                            DeleteUserAccount();
                            break;

                        /*======================== Make Review =========================*/
                        case 10:

                            Reviews();
                            Console.WriteLine("\nPress Enter to Go Back To Menu...");
                            break;

                        /*======================== - =========================*/
                        //case 11:

                        //    Console.WriteLine("\nPress Enter to Go Back To Menu...");
                        //    break;

                        /*======================== - =========================*/
                        //case 12:

                        //    Console.WriteLine("\nPress Enter to Go Back To Menu...");
                        //    break;

                        /*======================== - =========================*/
                        //case 13:

                        //    Console.WriteLine("\nPress Enter to Go Back To Menu...");
                        //    break;

                        /*======================== Go Back =========================*/
                        case 0:
                            goBack();
                            break;                 

                        //invalid choice
                        default:
                            Console.WriteLine("Invalid choice! Try again.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    // Handle invalid input
                    Console.WriteLine("Invalid input format. Please enter a number.");
                }
                catch (Exception ex)
                {
                    // Handle unexpected errors
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }

                Console.ReadLine();
            }
        }

        // Exits the application
        public static void ExitApplication()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                  THANK YOU FOR USING                   ║");
            Console.WriteLine("║                  Khalfanoviski Bank SYSTEM             ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");
            Console.WriteLine("\nExiting the application...");

            //Save Accounts to file, Save Reeviews to file, Save Loan Requests to file
            SaveAccountsInformationToFile();
            SaveReviews();
            SaveLoanRequests();

            
            Environment.Exit(0);
        }

        // Starts the system and displays the welcome message
        public static void StartSystem()
        {
            LoadAccountsInformationFromFile();
            LoadReviews();
            LoadLoanRequests();

            DisplayWelcomeMessage();
        }

        // Go Back
        public static void goBack()
        {
            Console.Clear();
            DisplayWelcomeMessage();

        }






        /* ====================== File Handling Functions ====================== */
        static void SaveAccountsInformationToFile()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(AccountsFilePath))
                {
                    for (int i = 0; i < accountNumbersL.Count; i++)
                    {
                        string dataLine = $"{accountNumbersL[i]},{accountNamesL[i]},{balancesL[i]}";
                        writer.WriteLine(dataLine);
                    }
                }
                Console.WriteLine("Accounts saved successfully.");
            }
            catch
            {
                Console.WriteLine("Error saving file.");
            }
        }

        static void LoadAccountsInformationFromFile()
        {
            try
            {
                if (!File.Exists(AccountsFilePath))
                {
                    Console.WriteLine("No saved data found.");
                    return;
                }

                accountNumbersL.Clear();
                accountNamesL.Clear();
                balancesL.Clear();
                //transactions.Clear();

                using (StreamReader reader = new StreamReader(AccountsFilePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        int accNum = Convert.ToInt32(parts[0]);
                        accountNumbersL.Add(accNum);
                        accountNamesL.Add(parts[1]);
                        balancesL.Add(Convert.ToDouble(parts[2]));

                        if (accNum > lastAccountNumber)
                            lastAccountNumber = accNum;
                    }
                }

                Console.WriteLine("Accounts loaded successfully.");
            }
            catch
            {
                Console.WriteLine("Error loading file.");
            }

        }

        static void SaveReviews()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(ReviewsFilePath))
                {
                    foreach (var review in ReviewsS)
                    {
                        writer.WriteLine(review);
                    }
                }
            }
            catch
            {
                Console.WriteLine("Error saving reviews.");
            }
        }

        static void LoadReviews()
        {
            try
            {
                if (!File.Exists(ReviewsFilePath)) return;

                using (StreamReader reader = new StreamReader(ReviewsFilePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        ReviewsS.Push(line);
                    }
                }
            }
            catch
            {
                Console.WriteLine("Error loading reviews.");
            }
        }

        static void SaveLoanRequests()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter("loan_requests.txt"))
                {
                    foreach (var request in LoanRequestsL)
                    {
                        writer.WriteLine(request);
                    }
                }
            }
            catch
            {
                Console.WriteLine("Error saving loan requests.");
            }
        }

        static void LoadLoanRequests()
        {
            try
            {
                if (!File.Exists("loan_requests.txt")) return;
                using (StreamReader reader = new StreamReader("loan_requests.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        LoanRequestsL.Add(line);
                    }
                }
            }
            catch
            {
                Console.WriteLine("Error loading loan requests.");
            }
        }




        /* ====================== Admin's Functions ====================== */

        /*------------------------View Requests---------------------*/
        public static void ViewRequests()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                     VIEW REQUESTS                      ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");
            Console.WriteLine("\n");

            if (accountOpeningRequests.Count == 0)
            {
                Console.WriteLine("No pending account requests.");
                return;
            }
            Console.WriteLine("Pending Account Opening Requests:");
            foreach (var request in accountOpeningRequests)
            {
                Console.WriteLine("- " + request);
            }
            Console.WriteLine("\n");      


        }

        /*------------------------View Accounts---------------------*/
        public static void ViewAccounts()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                    VIEW ACCOUNTS                       ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");
            Console.WriteLine("\n");

            for (int i = 0; i < accountNumbersL.Count; i++)
            {
                Console.WriteLine($"Account Number: {accountNumbersL[i]} | Account Name: {accountNamesL[i]} | Balance: {balancesL[i]}");
            }

        }

        /*------------------------View Reviews---------------------*/
        public static void ViewReviews()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                    VIEW REVIEWS                        ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");
            Console.WriteLine("\n");

            if (ReviewsS.Count == 0)
            {
                Console.WriteLine("No reviews or FeedBacks submitted yet.");
                return;
            }

            Console.WriteLine("Recent Reviews/FeedBacks (most recent first):");
            foreach (string Reviews in ReviewsS)
            {
                Console.WriteLine("- " + Reviews);
            }

        }

        /*------------------------Process Request---------------------*/
        public static void ProcessRequest()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                  PROCESS REQUEST                       ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");
            Console.WriteLine("\n");

            if (accountOpeningRequests.Count == 0)
            {
                Console.WriteLine("No pending account requests.");
                return;
            }

            // Process each request safely
            while (accountOpeningRequests.Count > 0)
            {
                string request = accountOpeningRequests.Peek();  // Look at first without removing
                Console.WriteLine(request);
                Console.WriteLine("Write 'a , A' to Accept Or 'r , R' to Reject");
                char k = Console.ReadKey().KeyChar;
                Console.WriteLine();  // Move to next line after key press

                if (k == 'a' || k == 'A')
                {
                    string request1 = accountOpeningRequests.Dequeue();
                    string[] parts = request1.Split('|');
                    string name = parts[0];
                    string nationalID = parts[1];

                    int newAccountNumber = lastAccountNumber + 1;

                    accountNumbersL.Add(newAccountNumber);
                    accountNamesL.Add($"{name} ");
                    balancesL.Add(0.0);

                    lastAccountNumber = newAccountNumber;

                    Console.WriteLine($"Account created for {name} with Account Number: {newAccountNumber}");
                }
                else if (k == 'r' || k == 'R')
                {
                    RejectedAccountReqL.Add(accountOpeningRequests.Dequeue());
                    Console.WriteLine("Account Rejected");
                }
                else
                {
                    Console.WriteLine("Invalid input. Skipping request...");
                }

                Console.WriteLine(); 
            }
        }


        /*------------------------Loan Requests---------------------*/
        public static void LoanRequestss()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                   LOAN REQUESTS                        ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");
            Console.WriteLine("\n");

            if (LoanRequestsL.Count == 0)
            {
                Console.WriteLine("No pending loan requests.");
                return;
            }

            Console.WriteLine("Pending Loan Requests:");
            foreach (var request in LoanRequestsL)
            {
                Console.WriteLine("- " + request);
            }
            Console.WriteLine("\n");

            Console.WriteLine("Press Enter to Go Back To Menu...");
        }

        /*------------------------Suspend Account---------------------*/
        public static void SuspendAccount()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                  SUSPEND ACCOUNT                       ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");
            Console.WriteLine("\n");

        }

        /*------------------------Search Account---------------------*/
        public static void SearchAccount()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                   SEARCH ACCOUNT                       ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");
            Console.WriteLine("\n");

            int index = GetAccountIndex();
            if (index == -1) return;

            Console.WriteLine($"Account Number: {accountNumbersL[index]}");
            Console.WriteLine($"Account Name: {accountNamesL[index]}");
            Console.WriteLine($"Balance: {balancesL[index]}");

        }

        /*------------------------Update Account Details---------------------*/
        public static void UpdateAccountDetails()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║              UPDATE ACCOUNT DETAILS                    ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");
            Console.WriteLine("\n");

        }

        /*------------------------Delete Account---------------------*/
        public static void DeleteAccount()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                   DELETE ACCOUNT                       ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");
            Console.WriteLine("\n");

                int index = GetAccountIndex();
                if (index == -1) return;
            Console.WriteLine($"Account Number: {accountNumbersL[index]}");

            Console.WriteLine("Are you sure you want to delete your account? (y/n)");

            char choice = Console.ReadKey().KeyChar;
            if (choice == 'y' || choice == 'Y')
            {
                accountNumbersL.RemoveAt(index);
                accountNamesL.RemoveAt(index);
                balancesL.RemoveAt(index);
                Console.WriteLine("\nAccount deleted successfully.");
            }
            else
            {
                Console.WriteLine("\nAccount deletion cancelled.");
            }


        }

        /*------------------------Rejected Accounts---------------------*/
        public static void RejectedAccounts()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                REJECTED ACCOUNTS                      ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");
            Console.WriteLine("\n");
            if (RejectedAccountReqL.Count == 0)
            {
                Console.WriteLine("No rejected account requests.");
                return;
            }
            Console.WriteLine("Rejected Account Opening Requests:");
            foreach (var request in RejectedAccountReqL)
            {
                Console.WriteLine("- " + request);
            }
            Console.WriteLine("\n");
            Console.WriteLine("Press Enter to Go Back To Menu...");
        }






        /* ====================== User's Functions ====================== */

        /*------------------------Request Account Opening---------------------*/
        public static void RequestAccountOpening()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║              REQUEST ACCOUNT OPENING                   ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");
            Console.WriteLine("\n");

            Console.WriteLine("Please fill in the following details to request an account opening:");

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("National ID: ");
            string nationalID = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Phone Number: ");
            string phoneNumber = Console.ReadLine();

            Console.Write("Address: ");
            string address = Console.ReadLine();

            Console.Write("Date of Birth (dd/mm/yyyy): ");
            string dateOfBirth = Console.ReadLine();

            Console.Write("Initial Deposit Amount: ");
            string initialDeposit = Console.ReadLine();

            Console.Write("Preferred Username: ");
            string username = Console.ReadLine();

            Console.Write("Preferred Password: ");
            string password = Console.ReadLine();

            DateTime RequestDate = DateTime.Now;

            Console.WriteLine("\n");
            Console.WriteLine("Please review your details:");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Email: {email}");
            Console.WriteLine($"Phone Number: {phoneNumber}");
            Console.WriteLine($"Address: {address}");
            Console.WriteLine($"Date of Birth: {dateOfBirth}");
            Console.WriteLine($"Initial Deposit Amount: {initialDeposit}");
            Console.WriteLine($"Preferred Username: {username}");
            Console.WriteLine("Your account request has been submitted.");

            accountOpeningRequests.Enqueue(name + " | " + nationalID + " | " + email + " | " + phoneNumber + " | " + address + " | " + dateOfBirth +  " | " + initialDeposit + " | " + username + " | " + password);


        }

        /*------------------------Deposit---------------------*/
        public static void Deposit()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                        DEPOSIT                         ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");
            Console.WriteLine("\n");


            int index = GetAccountIndex();
            if (index == -1) return;

            try
                {
                    Console.WriteLine("Please enter the amount you want to deposit:");
                    double depositAmount;
                    while (!double.TryParse(Console.ReadLine(), out depositAmount) || depositAmount <= 0)
                    {
                        Console.WriteLine("Invalid amount. Please enter a positive number:");
                    }

                    if (depositAmount <= 0)
                    {
                        Console.WriteLine("Amount must be positive.");
                        return;
                    }

                    balancesL[index] += depositAmount;
                    Console.WriteLine($"Successfully deposited {depositAmount} to account number {accountNumbersL[index]}.");
                    Console.WriteLine($"New balance: {balancesL[index]}");
                }
                catch
                {
                    Console.WriteLine("Invalid amount.");
                }
                Console.WriteLine("Press Enter to Go Back To Menu..."); 

        }

        /*------------------------Withdraw---------------------*/
        public static void Withdraw()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                       WITHDRAW                         ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");
            Console.WriteLine("\n");

            int index = GetAccountIndex();
            if (index == -1) return;

            try
            {
                Console.WriteLine("Please enter the amount you want to withdraw:");
                double withdrawAmount;
                while (!double.TryParse(Console.ReadLine(), out withdrawAmount) || withdrawAmount <= 0)
                {
                    Console.WriteLine("Invalid amount. Please enter a positive number:");
                }
                if (withdrawAmount > balancesL[index])
                {
                    Console.WriteLine("HAHA Do You Think We Are Foul!.");
                    return;
                }
                if (balancesL[index] - withdrawAmount < MinimumBalance)
                {
                    Console.WriteLine($"Withdrawal denied. Minimum balance of {MinimumBalance} must be maintained.");
                    return;
                }
                balancesL[index] -= withdrawAmount;
                Console.WriteLine($"Successfully withdrew {withdrawAmount} from account number {accountNumbersL[index]}.");
                Console.WriteLine($"New balance: {balancesL[index]}");
            }
            catch
            {
                Console.WriteLine("Invalid amount.");
            }
        }

        /*------------------------Check Balance---------------------*/
        public static void CheckBalance()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                    CHECK BALANCE                       ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");
            Console.WriteLine("\n");

            int index = GetAccountIndex();
            if (index == -1) return;
            Console.WriteLine($"Account Number: {accountNumbersL[index]}");
            Console.WriteLine($"Account Name: {accountNamesL[index]}");
            Console.WriteLine($"Balance: {balancesL[index]}");
            Console.WriteLine("\n");

        }

        /*------------------------Loan---------------------*/
        public static void Loan()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                          LOAN                          ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");
            Console.WriteLine("\n");

        }

        /*------------------------Send Money---------------------*/
        public static void SendMoney()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                      SEND MONEY                        ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");
            Console.WriteLine("\n");

        }

        /*------------------------Account Details---------------------*/
        public static void AccountDetails()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                   ACCOUNT DETAILS                      ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");
            Console.WriteLine("\n");


        }

        /*------------------------Update Account Details---------------------*/
        public static void UpdateUserAccountDetails()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║              UPDATE ACCOUNT DETAILS                    ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");
            Console.WriteLine("\n");


        }

        /*------------------------Delete Account---------------------*/
        public static void DeleteUserAccount()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                   DELETE ACCOUNT                       ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");
            Console.WriteLine("\n");





        }

        /*------------------------Make Review---------------------*/
        public static void Reviews()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                       REVIEWS                          ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");
            Console.WriteLine("\n");

            Console.WriteLine("Please write your review:");
            string review = Console.ReadLine();
            ReviewsS.Push(review);
            
            Console.WriteLine("Your review has been submitted.");

            Console.WriteLine("Thank you for your review!");
            Console.WriteLine("Press Enter to Go Back To Menu...");


        }

    }
}
