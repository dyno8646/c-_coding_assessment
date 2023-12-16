using Insurance_Management_System.com.hexaware.dao;
using Insurance_Management_System.com.hexaware.entities;
using Insurance_Management_System.com.hexaware.util;
using Insurance_Management_System.com.hexaware.exception;
using System.Globalization;

internal class Program
{
    private static IPolicyService policyService = new PolicyServiceImpl(PropertyUtil.GetConnectionString());
    private static void Main(string[] args)
    {
        Console.WriteLine("\n\n------------------Insurance Management System------------------\n\n");

        while (true)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\tMENU:\n");
            Console.WriteLine("1. Create Policy\n");
            Console.WriteLine("2. Get Policy\n");
            Console.WriteLine("3. Get All Policies\n");
            Console.WriteLine("4. Update Policy\n");
            Console.WriteLine("5. Delete Policy\n");
            Console.WriteLine("6. Exit");

            Console.Write("\nEnter your choice: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        CreatePolicy();
                        break;

                    case 2:
                        GetPolicy();
                        break;

                    case 3:
                        GetAllPolicies();
                        break;

                    case 4:
                        UpdatePolicy();
                        break;

                    case 5:
                        DeletePolicy();
                        break;

                    case 6:
                        Console.WriteLine("\nExiting. Goodbye!");
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine(ColorizeText("Invalid option. Please try again.", ConsoleColor.DarkYellow));
                        break;
                }
            }
            else
            {
                Console.WriteLine(ColorizeText("Invalid input. Please enter a number.", ConsoleColor.White));
            }

            Console.WriteLine();
        }
    }
    private static string ColorizeText(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        return text;
    }
    private static void CreatePolicy()
    {
        Console.WriteLine("\nCreating a new policy.");

        // Gather policy details from the user
        Console.Write("Enter Policy Number: ");
        string policyNumber = Console.ReadLine();

        Console.Write("Enter Policy Type: ");
        string policyType = Console.ReadLine();

        Console.Write("Enter Coverage Amount: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal coverageAmount))
        {
            Console.Write("Enter Premium Amount: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal premiumAmount))
            {
                Console.Write("Enter Start Date (YYYY-MM-DD): ");
                if (DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime startDate))
                {
                    Console.Write("Enter End Date (YYYY-MM-DD): ");
                    if (DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime endDate))
                    {
                        Policies newPolicy = new Policies
                        {
                            PolicyNumber = policyNumber,
                            PolicyType = policyType,
                            CoverageAmount = coverageAmount,
                            PremiumAmount = premiumAmount,
                            StartDate = startDate,
                            EndDate = endDate
                        };
                        bool result = policyService.CreatePolicy(newPolicy);

                        if (result)
                        {
                            Console.WriteLine("Policy created successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Error creating policy.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid End Date format. Please enter a valid date (YYYY-MM-DD).");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Start Date format. Please enter a valid date (YYYY-MM-DD).");
                }
            }
            else
            {
                Console.WriteLine("Invalid Premium Amount. Please enter a valid decimal number.");
            }
        }
        else
        {
            Console.WriteLine("Invalid Coverage Amount. Please enter a valid decimal number.");
        }
    }

    private static void GetPolicy()
    {
        Console.Write("\nEnter the Policy ID to get details: ");

        if (int.TryParse(Console.ReadLine(), out int policyId))
        {
            try {
                Policies policy = policyService.GetPolicy(policyId);

                if (policy != null)
                {
                    Console.WriteLine("| Policy ID |  Policy Number |   Policy Type   |   Coverage Amount   | Premium Amount |  Start Date       | End Date         |");
                    Console.WriteLine("|-----------|----------------|-----------------|---------------------|-----------------|------------------|------------------|");
                    Console.WriteLine($"| {policy.PolicyId,-9} | {policy.PolicyNumber,-14} | {policy.PolicyType,-11} | {policy.CoverageAmount,-11} | {policy.PremiumAmount,-15} | {policy.StartDate.ToString("dd/MM/yyyy"),-16} | {policy.EndDate.ToString("dd/MM/yyyy"),-16}");
                    Console.WriteLine("|-----------|----------------|-----------------|----------------------|-----------------|------------------|------------------|");
                }
                else
                {
                    Console.WriteLine($"Policy with ID {policyId} not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting policy: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid Policy ID (numeric value).");
        }
    }

    private static void GetAllPolicies()
    {
        List<Policies> policies = policyService.GetAllPolicies();

        if (policies.Count > 0)
        {
            Console.WriteLine("\nAll Policies:");
             
            Console.WriteLine("| Policy ID |  Policy Number |   Policy Type   |   Coverage Amount   | Premium Amount | Start Date       | End Date         |");
            Console.WriteLine("|-----------|----------------|-----------------|---------------------|-----------------|------------------|------------------|");

            // Iterate through policies and display values
            foreach (var policy in policies)
            {
                Console.WriteLine($"| {policy.PolicyId,-9} | {policy.PolicyNumber,-14} | {policy.PolicyType,-11} | {policy.CoverageAmount,-16} | {policy.PremiumAmount,-15} | {policy.StartDate.ToString("dd/MM/yyyy"),-16} | {policy.EndDate.ToString("dd/MM/yyyy"),-16}");
            }

            Console.WriteLine("|-----------|----------------|-----------------|------------------|-----------------|------------------|------------------|");


        }
        else
        {
            Console.WriteLine("No policies found.");
        }
    }

    private static void UpdatePolicy()
    {
        Console.Write("Enter the Policy ID to update: ");
        if (int.TryParse(Console.ReadLine(), out int policyId))
        {
            Policies existingPolicy = policyService.GetPolicy(policyId);

            if (existingPolicy != null)
            {
                Console.WriteLine("Enter the updated policy details:");

                Console.Write("Policy Type: ");
                string policyType = Console.ReadLine();

                Console.Write("Coverage Amount: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal coverageAmount))
                {
                    Console.Write("Premium Amount: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal premiumAmount))
                    {
                        Console.Write("Start Date (YYYY-MM-DD): ");
                        if (DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime startDate))
                        {
                            Console.Write("End Date (YYYY-MM-DD): ");
                            if (DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime endDate))
                            {
                                Policies updatedPolicy = new Policies
                                {
                                    PolicyId = existingPolicy.PolicyId,
                                    PolicyNumber = existingPolicy.PolicyNumber,
                                    PolicyType = policyType,
                                    CoverageAmount = coverageAmount,
                                    PremiumAmount = premiumAmount,
                                    StartDate = startDate,
                                    EndDate = endDate
                                };

                                bool isUpdated = policyService.UpdatePolicy(updatedPolicy);

                                if (isUpdated)
                                {
                                    Console.WriteLine($"Policy with ID {policyId} updated successfully.");
                                }
                                else
                                {
                                    Console.WriteLine($"Error updating policy with ID {policyId}.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid End Date format. Please enter a valid date.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid Start Date format. Please enter a valid date.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Premium Amount format. Please enter a valid decimal value.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Coverage Amount format. Please enter a valid decimal value.");
                }
            }
            else
            {
                Console.WriteLine($"Policy with ID {policyId} not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid Policy ID.");
        }
    }

    private static void DeletePolicy()
    {
        Console.Write("Enter the Policy ID to delete: ");
        if (int.TryParse(Console.ReadLine(), out int policyId))
        {
            Policies existingPolicy = policyService.GetPolicy(policyId);

            if (existingPolicy != null)
            {
                Console.WriteLine("Are you sure you want to delete this policy? (Y/N)");
                string confirmation = Console.ReadLine();

                if (confirmation.ToUpper() == "Y")
                {
                    bool isDeleted = policyService.DeletePolicy(policyId);

                    if (isDeleted)
                    {
                        Console.WriteLine($"Policy with ID {policyId} deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine($"Error deleting policy with ID {policyId}.");
                    }
                }
                else
                {
                    Console.WriteLine("Policy deletion canceled.");
                }
            }
            else
            {
                Console.WriteLine($"Policy with ID {policyId} not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid Policy ID.");
        }
    }


}