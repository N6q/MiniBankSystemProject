using System;
using System.Collections.Generic;

namespace MiniBankSystemProject
{
    internal class Program
    {
        /* ====================== Constants======================= */
        const double MinimumBalance = 100.0;
        const string AccountsFilePath = "accounts.txt";
        const string ReviewsFilePath = "reviews.txt";

        /* ====================== Global Variables (List, Queue, Stacks) ====================== */
        // Queue to store account opening requests
        public static Queue<string> accountOpeningRequests = new Queue<string>();

        //List to store accounts
        public static List <string> accountOpeningRequestsList = new List<string>();

        public static List<string> Accounts = new List<string>();
        public static List<string> RejectedAccountReq = new List<string>();
        public static List<string> LoanRequests = new List<string>();

        //List to store reviews
        public static List<string> ReviewsL = new List<string>();
        //public static 

        public static Stack<string> ReviewsS = new Stack<string>();
        //Ceate a writer to write to a file
        public static StreamWriter writer = new StreamWriter("accounts.txt", true);

        //Create a reader to read from a file
        public static StreamReader reader = new StreamReader("accounts.txt");

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
                Console.WriteLine("║ -1. Go Back                                          ║");
                Console.WriteLine("║                                                      ║");
                Console.WriteLine("║ 0. Exit Application                                  ║");
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
                            ExitApplication();
                            break;

                        /*======================== Exit Application =========================*/
                        case -1:
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
                Console.WriteLine("║ -1. Go Back                                          ║");
                Console.WriteLine("║                                                      ║");
                Console.WriteLine("║ 0. Exit Application                                  ║");
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
                        case -1:
                            goBack();
                            break;

                        /*======================== Exit Application =========================*/
                        case 0:
                            ExitApplication();
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
            Environment.Exit(0);
        }

        // Starts the system and displays the welcome message
        public static void StartSystem()
        {
            DisplayWelcomeMessage();
        }

        // Go Back
        public static void goBack()
        {
            Console.Clear();
            DisplayWelcomeMessage();

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

            foreach (var request in accountOpeningRequests)
            {
                Console.WriteLine(request);
                Console.WriteLine("Write 'a , A' to Accept Or 'r , R' to Reject");
                char k = Console.ReadKey().KeyChar;
                if (k == 'a' || k == 'A')
                {
                    Accounts.Add(request);
                    Console.WriteLine("\nAccount Accepted");
                    accountOpeningRequests.Dequeue();
                }
                else if (k == 'r' || k == 'R')
                {
                    RejectedAccountReq.Add(request);
                    Console.WriteLine("\nAccount Rejected");
                    accountOpeningRequests.Dequeue();
                }
            }
        }

        /*------------------------View Accounts---------------------*/
        public static void ViewAccounts()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                    VIEW ACCOUNTS                       ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");
            Console.WriteLine("\n");

            foreach (var acc in Accounts)
            {
                Console.WriteLine(acc);

            }

        }

        /*------------------------View Reviews---------------------*/
        public static void ViewReviews()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                    VIEW REVIEWS                       ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");
            Console.WriteLine("\n");

            foreach (var review in ReviewsList)
            {
                Console.WriteLine(review);
            }

        }

        /*------------------------Process Request---------------------*/
        public static void ProcessRequest()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                  PROCESS REQUEST                      ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");
            Console.WriteLine("\n");

        }

        /*------------------------Loan Requests---------------------*/
        public static void LoanRequestss()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                   LOAN REQUESTS                       ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");
            Console.WriteLine("\n");

        }

        /*------------------------Suspend Account---------------------*/
        public static void SuspendAccount()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                  SUSPEND ACCOUNT                      ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");
            Console.WriteLine("\n");

        }

        /*------------------------Search Account---------------------*/
        public static void SearchAccount()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                   SEARCH ACCOUNT                      ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");
            Console.WriteLine("\n");

        }

        /*------------------------Update Account Details---------------------*/
        public static void UpdateAccountDetails()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║              UPDATE ACCOUNT DETAILS                   ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");
            Console.WriteLine("\n");

        }

        /*------------------------Delete Account---------------------*/
        public static void DeleteAccount()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                   DELETE ACCOUNT                      ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");
            Console.WriteLine("\n");

        }






        /* ====================== User's Functions ====================== */

        /*------------------------Request Account Opening---------------------*/
        public static void RequestAccountOpening()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║              REQUEST ACCOUNT OPENING                  ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");
            Console.WriteLine("\n");

            Console.WriteLine("Please fill in the following details to request an account opening:");

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Phone Number: ");
            string phoneNumber = Console.ReadLine();

            Console.Write("Address: ");
            string address = Console.ReadLine();

            Console.Write("Date of Birth (dd/mm/yyyy): ");
            string dateOfBirth = Console.ReadLine();

            Console.Write("Account Type (Savings/Current): ");
            string accountType = Console.ReadLine();

            Console.Write("Initial Deposit Amount: ");
            string initialDeposit = Console.ReadLine();

            Console.Write("Preferred Username: ");
            string username = Console.ReadLine();

            Console.Write("Preferred Password: ");
            string password = Console.ReadLine();

            Console.WriteLine("\n");
            Console.WriteLine("Please review your details:");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Email: {email}");
            Console.WriteLine($"Phone Number: {phoneNumber}");
            Console.WriteLine($"Address: {address}");
            Console.WriteLine($"Date of Birth: {dateOfBirth}");
            Console.WriteLine($"Account Type: {accountType}");
            Console.WriteLine($"Initial Deposit Amount: {initialDeposit}");
            Console.WriteLine($"Preferred Username: {username}");

            accountOpeningRequests.Enqueue(name + " | " + email + " | " + phoneNumber + " | " + address + " | " + dateOfBirth + " | " + accountType + " | " + initialDeposit + " | " + username + " | " + password);


        }

        /*------------------------Deposit---------------------*/
        public static void Deposit()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                        DEPOSIT                        ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");
            Console.WriteLine("\n");

        }

        /*------------------------Withdraw---------------------*/
        public static void Withdraw()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                       WITHDRAW                        ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");
            Console.WriteLine("\n");

        }

        /*------------------------Check Balance---------------------*/
        public static void CheckBalance()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                    CHECK BALANCE                      ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");
            Console.WriteLine("\n");

        }

        /*------------------------Loan---------------------*/
        public static void Loan()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                          LOAN                         ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");
            Console.WriteLine("\n");

        }

        /*------------------------Send Money---------------------*/
        public static void SendMoney()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                      SEND MONEY                       ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");
            Console.WriteLine("\n");

        }

        /*------------------------Account Details---------------------*/
        public static void AccountDetails()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                   ACCOUNT DETAILS                     ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");
            Console.WriteLine("\n");

        }

        /*------------------------Update Account Details---------------------*/
        public static void UpdateUserAccountDetails()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║              UPDATE ACCOUNT DETAILS                   ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");
            Console.WriteLine("\n");

        }

        /*------------------------Delete Account---------------------*/
        public static void DeleteUserAccount()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                   DELETE ACCOUNT                      ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");
            Console.WriteLine("\n");

        }

        /*------------------------Make Review---------------------*/
        public static void Reviews()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                       REVIEWS                         ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");
            Console.WriteLine("\n");

            Console.WriteLine("Please write your review:");
            string review = Console.ReadLine();
            ReviewsList.Add(review);
            Console.WriteLine("Thank you for your review!");

        }

    }
}
