using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FinalTest1
{
    public class PharmacyDataTier
    {
        static String connString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
        static SqlConnection myConn = new SqlConnection(connString);
        static System.Data.SqlClient.SqlCommand cmdString = new System.Data.SqlClient.SqlCommand();
        private object dgvPatients;

        public bool UpdatePatient(string patientID, string firstName, string middleInt, string lastName, DateTime dob, string gender, string phoneNumber, string email, string streetName, string city, string state, string zip, string primaryInsurance, string secondaryInsurance)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("UpdatePatientInfo", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PatientID", patientID);
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@MiddleInt", middleInt);
                    cmd.Parameters.AddWithValue("@LastName", lastName);
                    cmd.Parameters.AddWithValue("@DOB", dob);
                    cmd.Parameters.AddWithValue("@Gender", gender);
                    cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@StreetName", streetName);
                    cmd.Parameters.AddWithValue("@City", city);
                    cmd.Parameters.AddWithValue("@State", state);
                    cmd.Parameters.AddWithValue("@Zip", zip);
                    cmd.Parameters.AddWithValue("@PrimaryInsurance", primaryInsurance);
                    cmd.Parameters.AddWithValue("@SecondaryInsurance", secondaryInsurance);

                    try
                    {
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Database error: " + ex.Message);
                    }
                    finally
                    {
                        myConn.Close();
                    }
                }
            }
        }


        public void PatientRegistration(string patientID, string firstName, string middleInt, string lastName, string dob,
                                string gender, string phoneNumber, string email, string streetName,
                                string city, string state, string zip, string primaryInsurance,
                                string secondaryInsurance)
        {
            {
                try
                {
                    myConn.Open();
                    cmdString.Parameters.Clear();
                    cmdString.CommandType = CommandType.StoredProcedure;
                    cmdString.CommandText = "PatientRegistration";
                    cmdString.Parameters.Add("@PatientID", SqlDbType.VarChar, 50).Value = patientID;
                    cmdString.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = firstName;
                    cmdString.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = lastName;
                    cmdString.Parameters.Add("@MiddleInitial", SqlDbType.Char, 1).Value = string.IsNullOrEmpty(middleInt) ? (object)DBNull.Value : middleInt;
                    cmdString.Parameters.Add("@StreetName", SqlDbType.VarChar, 100).Value = string.IsNullOrEmpty(streetName) ? (object)DBNull.Value : streetName;
                    cmdString.Parameters.Add("@City", SqlDbType.VarChar, 50).Value = string.IsNullOrEmpty(city) ? (object)DBNull.Value : city;
                    cmdString.Parameters.Add("@State", SqlDbType.VarChar, 10).Value = string.IsNullOrEmpty(state) ? (object)DBNull.Value : state;
                    cmdString.Parameters.Add("@ZipCode", SqlDbType.VarChar, 15).Value = string.IsNullOrEmpty(zip) ? (object)DBNull.Value : zip;
                    cmdString.Parameters.Add("@PhoneNumber", SqlDbType.VarChar, 15).Value = string.IsNullOrEmpty(phoneNumber) ? (object)DBNull.Value : phoneNumber;
                    cmdString.Parameters.Add("@Email", SqlDbType.VarChar, 100).Value = string.IsNullOrEmpty(email) ? (object)DBNull.Value : email;
                    cmdString.Parameters.Add("@Gender", SqlDbType.Char, 1).Value = string.IsNullOrEmpty(gender) ? (object)DBNull.Value : gender;
                    cmdString.Parameters.Add("@DOB", SqlDbType.VarChar, 12).Value = string.IsNullOrEmpty(dob) ? (object)DBNull.Value : dob;
                    cmdString.Parameters.Add("@PrimaryInsurance", SqlDbType.VarChar, 100).Value = string.IsNullOrEmpty(primaryInsurance) ? (object)DBNull.Value : primaryInsurance;
                    cmdString.Parameters.Add("@SecondaryInsurance", SqlDbType.VarChar, 100).Value = string.IsNullOrEmpty(secondaryInsurance) ? (object)DBNull.Value : secondaryInsurance;

                    cmdString.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627 || ex.Number == 2601) 
                    {
                        throw new ArgumentException("Error: Patient ID already exists.");
                    }
                    else
                    {
                        throw new ArgumentException("Database error: " + ex.Message);
                    }
                }
                finally
                {
                    myConn.Close();
                }
            }
        }

        public void PhysicianRegistration(string PhysicianID, string firstName, string middleInt, string lastName, string dob,
                                       string gender, string phoneNumber, string email, string streetName,
                                       string city, string state, string zip, string Specialty1,
                                       string Specialty2)
        {

            {
                try
                {
                    myConn.Open();

                    cmdString.Parameters.Clear();


                    cmdString.Connection = myConn;
                    cmdString.CommandType = CommandType.StoredProcedure;
                    cmdString.CommandText = "PhysicianRegistration";

                    cmdString.Parameters.Add("@PhysicianID", SqlDbType.VarChar, 50).Value = PhysicianID;
                    cmdString.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = firstName;
                    cmdString.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = lastName;
                    cmdString.Parameters.Add("@MiddleInitial", SqlDbType.Char, 1).Value = middleInt;
                    cmdString.Parameters.Add("@StreetName", SqlDbType.VarChar, 100).Value = streetName;
                    cmdString.Parameters.Add("@City", SqlDbType.VarChar, 50).Value = city;
                    cmdString.Parameters.Add("@State", SqlDbType.VarChar, 2).Value = state;
                    cmdString.Parameters.Add("@ZipCode", SqlDbType.VarChar, 15).Value = zip;
                    cmdString.Parameters.Add("@PhoneNumber", SqlDbType.VarChar, 15).Value = phoneNumber;
                    cmdString.Parameters.Add("@Email", SqlDbType.VarChar, 100).Value = email;
                    cmdString.Parameters.Add("@Gender", SqlDbType.Char, 1).Value = gender;
                    cmdString.Parameters.Add("@DOB", SqlDbType.VarChar, 12).Value = dob;
                    cmdString.Parameters.Add("@Specialty1", SqlDbType.VarChar, 50).Value = Specialty1;
                    cmdString.Parameters.Add("@Specialty2", SqlDbType.VarChar, 50).Value = Specialty2;



                    cmdString.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new ArgumentException("Error Inserting Physician Registration: " + ex.Message);
                }
                finally
                {
                    myConn.Close();
                }
            }
        }



        public DataSet GetPatientByID(string patientID)
        {
            try
            {
                myConn.Open();
                cmdString.Parameters.Clear();
                cmdString.Connection = myConn;
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandText = "GetPatientByID";
                cmdString.Parameters.AddWithValue("@PatientID", patientID);

                SqlDataAdapter da = new SqlDataAdapter(cmdString);
                DataSet ds = new DataSet();
                da.Fill(ds);

                return ds;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error retrieving patient details: " + ex.Message);
            }
            finally
            {
                myConn.Close();
            }
        }

        public DataSet ListPatients()
        {
            try
            {
                myConn.Open();
                cmdString.Parameters.Clear();
                cmdString.Connection = myConn;
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandText = "ListPatients";

                SqlDataAdapter da = new SqlDataAdapter(cmdString);
                DataSet ds = new DataSet();
                da.Fill(ds);

                return ds;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error retrieving patient list: " + ex.Message);
            }
            finally
            {
                myConn.Close();
            }
        }
        public DataSet GetPatients(string patientID, string lastName, string dob)
        {

            {

                try
                {
                    myConn.Open();
                    cmdString.Parameters.Clear();
                    cmdString.Connection = myConn;
                    cmdString.CommandType = CommandType.StoredProcedure;
                    cmdString.CommandTimeout = 1500;
                    cmdString.CommandText = "GetPatients";
                    cmdString.Parameters.Add("@PatientID", SqlDbType.VarChar, 50).Value = patientID;
                    cmdString.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = lastName;
                    cmdString.Parameters.Add("@DOB", SqlDbType.VarChar, 12).Value = dob;





                    SqlDataAdapter da = new SqlDataAdapter(cmdString);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    return ds;
                }

                catch (Exception ex)
                {
                    throw new ArgumentException("Error retrieving patient data: " + ex.Message);
                }
                finally
                {
                    myConn.Close();
                }
            }
        }


        public void AddPrescription(string patientid, string physicianID, string medicationID, string dosage, string frequency, string AdministrationRoute, int refillcount)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;

            SqlConnection myConn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("AddPrescription", myConn);
            {
                try
                {

                    myConn.Open();
                    cmd.Parameters.Clear();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 1500;
                    cmd.Parameters.AddWithValue("@PatientID", patientid);
                    cmd.Parameters.AddWithValue("@PhysicianID", physicianID);
                    cmd.Parameters.AddWithValue("@MedicationID", medicationID);
                    cmd.Parameters.AddWithValue("@Dosage", dosage);
                    cmd.Parameters.AddWithValue("@Frequency", frequency);
                    cmd.Parameters.AddWithValue("@AdministrationRoute", AdministrationRoute);
                    cmd.Parameters.AddWithValue("@RefillCount", refillcount);




                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new ArgumentException("Error Adding Prescription: " + ex.Message);
                }
                finally
                {
                    myConn.Close();
                }



            }
        }


        public void AddRefill(int RXNum)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            SqlConnection myConn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("AddRefill", myConn);

            {
                try
                {
                    myConn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = myConn;
                    cmd.CommandTimeout = 1500;
                    cmd.Parameters.Clear();
                    cmd.CommandText = "AddRefill";
                    cmd.Parameters.AddWithValue("@RXNum", RXNum);


                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new ArgumentException(ex.Message);
                }
                finally
                {
                    myConn.Close();
                }
            }
        }
        public DataSet GetAllPatientID()
        {
            try
            {
                myConn.Open();
                cmdString.Parameters.Clear();
                cmdString.Connection = myConn;
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
                cmdString.CommandText = "GetAllPatientIDs";
                cmdString.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmdString);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }
            finally
            {
                myConn.Close();
            }
        }


        public DataSet GetAllPrescriptions()
        {
            try
            {
                myConn.Open();
                cmdString.Parameters.Clear();
                cmdString.Connection = myConn;
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
                cmdString.CommandText = "GetAllPrescriptions";
                cmdString.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmdString);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }
            finally
            {
                myConn.Close();
            }
        }

        public DataSet GetAllRefills()
        {
            try
            {
                myConn.Open();
                cmdString.Parameters.Clear();
                cmdString.Connection = myConn;
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
                cmdString.CommandText = "GetAllRefills";
                cmdString.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmdString);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }
            finally
            {
                myConn.Close();
            }
        }
        public void DeleteRefill(int RXNum)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            SqlConnection myConn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("DeleteRefill", myConn);

            {
                try
                {
                    myConn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = myConn;
                    cmd.CommandTimeout = 1500;
                    cmd.Parameters.Clear();
                    cmd.CommandText = "DeleteRefill";
                    cmd.Parameters.AddWithValue("@RXNum", RXNum);


                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new ArgumentException(ex.Message);
                }
                finally
                {
                    myConn.Close();
                }
            }
        }

        public DataSet GetRefillsRXNum(int RXNum)
        {

            try
            {
                myConn.Open();
                cmdString.Parameters.Clear();
                cmdString.Connection = myConn;
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
                cmdString.CommandText = "GetRefillsRXNum";
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.Parameters.AddWithValue("@RXNum", RXNum);
                SqlDataAdapter da = new SqlDataAdapter(cmdString);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }
            finally
            {
                myConn.Close();
            }
        }
    }
}










