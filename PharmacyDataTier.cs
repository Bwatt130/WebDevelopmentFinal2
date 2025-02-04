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

        public bool UpdatePatient(string patientID, string firstName, string middleInt, string lastName, DateTime dob, string gender, string phoneNumber, string email, string streetName, string city, string state, string zip, string primaryInsurance, string secondaryInsurance)
        {
            try
            {
                myConn.Open();
                cmdString.Parameters.Clear();
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
                cmdString.CommandText = "UpdatePatientInfo";
                cmdString.Parameters.AddWithValue("@PatientID", patientID);
                cmdString.Parameters.AddWithValue("@FirstName", firstName);
                cmdString.Parameters.AddWithValue("@MiddleInt", middleInt);
                cmdString.Parameters.AddWithValue("@LastName", lastName);
                cmdString.Parameters.AddWithValue("@DOB", dob);
                cmdString.Parameters.AddWithValue("@Gender", gender);
                cmdString.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                cmdString.Parameters.AddWithValue("@Email", email);
                cmdString.Parameters.AddWithValue("@StreetName", streetName);
                cmdString.Parameters.AddWithValue("@City", city);
                cmdString.Parameters.AddWithValue("@State", state);
                cmdString.Parameters.AddWithValue("@Zip", zip);
                cmdString.Parameters.AddWithValue("@PrimaryInsurance", primaryInsurance);
                cmdString.Parameters.AddWithValue("@SecondaryInsurance", secondaryInsurance);

                int rowsAffected = cmdString.ExecuteNonQuery();
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

        public bool UpdatePhysician(string physicianID, string firstName, string lastName, string middleInitial, string streetName, string city, string state, string zipCode, string phoneNumber, string email, string gender, string dob, string specialty1, string specialty2)
        {
            try
            {
                myConn.Open();
                cmdString.Parameters.Clear();
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
                cmdString.CommandText = "UpdatePhysicianInfo";
                cmdString.Parameters.AddWithValue("@PhysicianID", physicianID);
                cmdString.Parameters.AddWithValue("@FirstName", firstName);
                cmdString.Parameters.AddWithValue("@MiddleInt", middleInitial);
                cmdString.Parameters.AddWithValue("@LastName", lastName);
                cmdString.Parameters.AddWithValue("@DOB", dob);
                cmdString.Parameters.AddWithValue("@Gender", gender);
                cmdString.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                cmdString.Parameters.AddWithValue("@Email", email);
                cmdString.Parameters.AddWithValue("@StreetName", streetName);
                cmdString.Parameters.AddWithValue("@City", city);
                cmdString.Parameters.AddWithValue("@State", state);
                cmdString.Parameters.AddWithValue("@Zip", zipCode);
                cmdString.Parameters.AddWithValue("@Specialty1", specialty1);
                cmdString.Parameters.AddWithValue("@Specialty2", specialty2);

                int rowsAffected = cmdString.ExecuteNonQuery();
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

        public void PatientRegistration(string patientID, string firstName, string middleInt, string lastName, string dob, string gender, string phoneNumber, string email, string streetName, string city, string state, string zip, string primaryInsurance, string secondaryInsurance)
        {
            try
            {
                myConn.Open();
                cmdString.Parameters.Clear();
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
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

        public void PhysicianRegistration(string PhysicianID, string firstName, string middleInt, string lastName, string dob, string gender, string phoneNumber, string email, string streetName, string city, string state, string zip, string Specialty1, string Specialty2)
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

        public bool ModifyPrescription(int rxNum, string dosage, string frequency, string prescriptionDate, string administrationRoute, int refillCount)
        {
            try
            {
                myConn.Open();
                cmdString.Parameters.Clear();
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
                cmdString.CommandText = "ModifyPrescription";
                cmdString.Parameters.AddWithValue("@RXNum", rxNum);
                cmdString.Parameters.AddWithValue("@Dosage", string.IsNullOrEmpty(dosage) ? (object)DBNull.Value : dosage);
                cmdString.Parameters.AddWithValue("@Frequency", string.IsNullOrEmpty(frequency) ? (object)DBNull.Value : frequency);
                cmdString.Parameters.AddWithValue("@PrescriptionDate", string.IsNullOrEmpty(prescriptionDate) ? (object)DBNull.Value : prescriptionDate);
                cmdString.Parameters.AddWithValue("@AdministrationRoute", string.IsNullOrEmpty(administrationRoute) ? (object)DBNull.Value : administrationRoute);
                cmdString.Parameters.AddWithValue("@REFILLCOUNT", refillCount);

                int rowsAffected = cmdString.ExecuteNonQuery();
                return rowsAffected < 0;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error modifying prescription: " + ex.Message);
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
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
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

        public DataSet ListPhysicians()
        {
            try
            {
                myConn.Open();
                cmdString.Parameters.Clear();
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandText = "ListPhysicians";

                SqlDataAdapter da = new SqlDataAdapter(cmdString);
                DataSet ds = new DataSet();
                da.Fill(ds);

                return ds;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error retrieving physician list: " + ex.Message);
            }
            finally
            {
                myConn.Close();
            }
        }

        public DataSet ListPrescriptions()
        {
            try
            {
                myConn.Open();
                cmdString.Parameters.Clear();
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
                cmdString.CommandText = "ListPrescriptions";
                SqlDataAdapter da = new SqlDataAdapter(cmdString);
                DataSet ds = new DataSet();
                da.Fill(ds);

                return ds;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error retrieving prescriptions: " + ex.Message);
            }
            finally
            {
                myConn.Close();
            }
        }

        //public DataSet GetPatients(string patientID, string lastName, string dob)
        //{
        //    try
        //    {
        //        myConn.Open();
        //        cmdString.Parameters.Clear();
        //        cmdString.CommandType = CommandType.StoredProcedure;
        //        cmdString.CommandTimeout = 1500;
        //        cmdString.CommandText = "GetPatients";
        //        cmdString.Parameters.Add("@PatientID", SqlDbType.VarChar, 50).Value = patientID;
        //        cmdString.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = lastName;
        //        cmdString.Parameters.Add("@DOB", SqlDbType.VarChar, 12).Value = dob;

        //        SqlDataAdapter da = new SqlDataAdapter(cmdString);
        //        DataSet ds = new DataSet();
        //        da.Fill(ds);

        //        return ds;
        //    }

        //    catch (Exception ex)
        //    {
        //        throw new ArgumentException("Error retrieving patient data: " + ex.Message);
        //    }
        //    finally
        //    {
        //        myConn.Close();
        //    }
        //}

        public void AddPrescription(string patientid, string physicianID, string medicationID, string dosage, string frequency, string AdministrationRoute, int refillcount)
        {
            try
            {
                myConn.Open();
                cmdString.Parameters.Clear();
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
                cmdString.CommandText = "AddPrescription";
                cmdString.Parameters.AddWithValue("@PatientID", patientid);
                cmdString.Parameters.AddWithValue("@PhysicianID", physicianID);
                cmdString.Parameters.AddWithValue("@MedicationID", medicationID);
                cmdString.Parameters.AddWithValue("@Dosage", dosage);
                cmdString.Parameters.AddWithValue("@Frequency", frequency);
                cmdString.Parameters.AddWithValue("@AdministrationRoute", AdministrationRoute);
                cmdString.Parameters.AddWithValue("@RefillCount", refillcount);

                cmdString.ExecuteNonQuery();
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

        //public DataSet GetAllPatientID()
        //{
        //    try
        //    {
        //        myConn.Open();
        //        cmdString.Parameters.Clear();
        //        cmdString.CommandType = CommandType.StoredProcedure;
        //        cmdString.CommandTimeout = 1500;
        //        cmdString.CommandText = "GetAllPatientIDs";
        //        SqlDataAdapter da = new SqlDataAdapter(cmdString);
        //        DataSet ds = new DataSet();
        //        da.Fill(ds);
        //        return ds;

        //    }
        //    catch (Exception ex)
        //    {

        //        throw new ArgumentException(ex.Message);
        //    }
        //    finally
        //    {
        //        myConn.Close();
        //    }
        //}

        public DataSet GetPatientByID(string patientID)
        {
            try
            {
                myConn.Open();
                cmdString.Parameters.Clear();
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
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

        public DataSet GetPhysicianByID(string physicianID)
        {
            try
            {
                myConn.Open();
                cmdString.Parameters.Clear();
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandText = "GetPhysicianByID";
                cmdString.Parameters.AddWithValue("@PhysicianID", physicianID);

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

        public DataSet GetAllPrescriptions()
        {
            try
            {
                myConn.Open();
                cmdString.Parameters.Clear();
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
                cmdString.CommandText = "GetAllPrescriptions";
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

        public DataRow GetPrescriptionByID(int rxNum)
        {
            try
            {
                myConn.Open();
                cmdString.Parameters.Clear();
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
                cmdString.CommandText = "GetPrescriptionByID";
                cmdString.Parameters.AddWithValue("@RXNum", rxNum);

                SqlDataAdapter da = new SqlDataAdapter(cmdString);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]; // Return the first row (since RXNum is unique)
                }
                else
                {
                    return null; // No prescription found
                }  
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error retrieving prescription: " + ex.Message);
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

        public DataSet GetRefillsRXNum(int RXNum)
        {
            try
            {
                myConn.Open();
                cmdString.Parameters.Clear();
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
                cmdString.CommandText = "GetRefillsRXNum";
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
        public void AddRefill(int RXNum)
        {
            try
            {
                myConn.Open();
                cmdString.Parameters.Clear();
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
                cmdString.CommandText = "AddRefill";
                cmdString.Parameters.AddWithValue("@RXNum", RXNum);
                cmdString.ExecuteNonQuery();
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
            try
            {
                myConn.Open();
                cmdString.Parameters.Clear();
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
                cmdString.CommandText = "DeleteRefill";
                cmdString.Parameters.AddWithValue("@RXNum", RXNum);
                cmdString.ExecuteNonQuery();
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
        public DataSet ViewRefillsByPrescription(int rxNum)
        {
            try
            {
                myConn.Open();
                cmdString.Parameters.Clear();
                cmdString.Connection = myConn;
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
                cmdString.CommandText = "ViewRefillsByPrescription";
                cmdString.Parameters.AddWithValue("@RXNum", rxNum);

                SqlDataAdapter da = new SqlDataAdapter(cmdString);
                DataSet ds = new DataSet();
                da.Fill(ds);

                return ds;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error retrieving refills: " + ex.Message);
            }
            finally
            {
                myConn.Close();
            }
        }

    }
}