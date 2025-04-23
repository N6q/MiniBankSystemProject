using System;
using System.Collections.Generic;

namespace MiniBankSystemProject
{
    internal class Program
    {
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
                            LoanRequests();
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

                        /*======================== - =========================*/
                        //case 10:

                        //    Console.WriteLine("\nPress Enter to Go Back To Menu...");
                        //    break;

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



        /* ====================== Admin's Functions ====================== */


        /*------------------------View Accounts---------------------*/
        public static void ViewAccounts()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                    VIEW ACCOUNTS                      ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");
            Console.WriteLine("\n");

        }

        /*------------------------View Reviews---------------------*/
        public static void ViewReviews()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                    VIEW REVIEWS                       ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");
            Console.WriteLine("\n");

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
        public static void LoanRequests()
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

    }


}
