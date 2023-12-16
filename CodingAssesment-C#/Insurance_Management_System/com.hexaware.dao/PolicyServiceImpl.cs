using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insurance_Management_System.com.hexaware.entities;
using System.Data.SqlClient;
using Insurance_Management_System.com.hexaware.exception;
using Insurance_Management_System.com.hexaware.util;

namespace Insurance_Management_System.com.hexaware.dao
{
    public class PolicyServiceImpl : IPolicyService
    {
        private readonly string connectionString;

        public PolicyServiceImpl(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool CreatePolicy(Policies policy)
        {
            using (SqlConnection connection = DBConnection.GetConnection())
            {
                try
                {
                    //connection.Open();

                    string insertQuery = "INSERT INTO Policies (policy_number, policy_type, coverage_amount, premium_amount, start_date, end_date) " +
                                         "VALUES (@PolicyNumber, @PolicyType, @CoverageAmount, @PremiumAmount, @StartDate, @EndDate)";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@PolicyNumber", policy.PolicyNumber);
                        cmd.Parameters.AddWithValue("@PolicyType", policy.PolicyType);
                        cmd.Parameters.AddWithValue("@CoverageAmount", policy.CoverageAmount);
                        cmd.Parameters.AddWithValue("@PremiumAmount", policy.PremiumAmount);
                        cmd.Parameters.AddWithValue("@StartDate", policy.StartDate);
                        cmd.Parameters.AddWithValue("@EndDate", policy.EndDate);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        return rowsAffected > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error creating policy: {ex.Message}");
                    return false;
                }
            }
        }

        public Policies GetPolicy(int policyId)
        {
            using (SqlConnection connection = DBConnection.GetConnection())
            {
                try
                {
                    //connection.Open();
                    string selectQuery = "SELECT * FROM Policies WHERE policy_id = @PolicyId";

                    using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@PolicyId", policyId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return MapDataReaderToPolicy(reader);
                            }
                            else
                            {
                                throw new PolicyNumberNotFoundException($"Policy with ID {policyId} not found.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error getting policy: {ex.Message}");
                    return null;
                }
            }
        }

        public List<Policies> GetAllPolicies()
        {
            List<Policies> policies = new List<Policies>();

            using (SqlConnection connection = DBConnection.GetConnection())
            {
                try
                {
                    //connection.Open();

                    string selectAllQuery = "SELECT * FROM Policies";

                    using (SqlCommand cmd = new SqlCommand(selectAllQuery, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                policies.Add(MapDataReaderToPolicy(reader));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error getting all policies: {ex.Message}");
                }
            }

            return policies;
        }

        public bool UpdatePolicy(Policies policy)
        {
            using (SqlConnection connection = DBConnection.GetConnection())
            {
                try
                {
                    //connection.Open();

                    string updateQuery = "UPDATE Policies SET policy_type = @PolicyType, " +
                                         "coverage_amount = @CoverageAmount, premium_amount = @PremiumAmount, " +
                                         "start_date = @StartDate, end_date = @EndDate " +
                                         "WHERE policy_id = @PolicyId";

                    using (SqlCommand cmd = new SqlCommand(updateQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@PolicyId", policy.PolicyId);
                        cmd.Parameters.AddWithValue("@PolicyType", policy.PolicyType);
                        cmd.Parameters.AddWithValue("@CoverageAmount", policy.CoverageAmount);
                        cmd.Parameters.AddWithValue("@PremiumAmount", policy.PremiumAmount);
                        cmd.Parameters.AddWithValue("@StartDate", policy.StartDate);
                        cmd.Parameters.AddWithValue("@EndDate", policy.EndDate);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        return rowsAffected > 0;
                    }
                }
                catch (Exception ex)
                {
                    // Handle the exception (log, throw, etc.)
                    Console.WriteLine($"Error updating policy: {ex.Message}");
                    return false;
                }
            }
        }

        public bool DeletePolicy(int policyId)
        {
            using (SqlConnection connection = DBConnection.GetConnection())
            {
                try
                {
                    //connection.Open();

                    string deleteQuery = "DELETE FROM Policies WHERE policy_id = @PolicyId";

                    using (SqlCommand cmd = new SqlCommand(deleteQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@PolicyId", policyId);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        return rowsAffected > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deleting policy: {ex.Message}");
                    return false;
                }
            }
        }

        private Policies MapDataReaderToPolicy(SqlDataReader reader)
        {
            return new Policies
            {
                PolicyId = Convert.ToInt32(reader["policy_id"]),
                PolicyNumber = Convert.ToString(reader["policy_number"]),
                PolicyType = Convert.ToString(reader["policy_type"]),
                CoverageAmount = Convert.ToDecimal(reader["coverage_amount"]),
                PremiumAmount = Convert.ToDecimal(reader["premium_amount"]),
                StartDate = Convert.ToDateTime(reader["start_date"]),
                EndDate = Convert.ToDateTime(reader["end_date"])
            };
        }
    }
}
