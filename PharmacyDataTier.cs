using ProjectName;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace FinalTest1
{
    public class PharmacyDataTier
    {
        static String connString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
        static SqlConnection myConn = new SqlConnection(connString);
        static System.Data.SqlClient.SqlCommand cmdString = new System.Data.SqlClient.SqlCommand();

        public bool UpdatePatient(string patientID, string firstName, string MiddleInitial, string lastName, DateTime dob, string gender, string phoneNumber, string email, string streetName, string city, string state, string zip, string primaryInsurance, string secondaryInsurance)
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
                cmdString.Parameters.AddWithValue("@MiddleInt", MiddleInitial);
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

        public bool UpdatePhysician(string physicianID, string firstName, string lastName,
            string middleInitial, DateTime? dob, string gender, string phoneNumber,
            string email, string streetName, string city, string state, string zipCode,
            string primarySpecialty, string secondarySpecialty)
        {
            try
            {
                myConn.Open();
                cmdString.Parameters.Clear();
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
                cmdString.CommandText = "UpdatePhysicianInformation";

                cmdString.Parameters.AddWithValue("@PhysicianID", physicianID);
                cmdString.Parameters.AddWithValue("@FirstName", firstName);
                cmdString.Parameters.AddWithValue("@LastName", lastName);
                cmdString.Parameters.AddWithValue("@MiddleInitial", string.IsNullOrEmpty(middleInitial) ? (object)DBNull.Value : middleInitial);
                cmdString.Parameters.AddWithValue("@DOB", dob);
                cmdString.Parameters.AddWithValue("@Gender", gender);
                cmdString.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                cmdString.Parameters.AddWithValue("@Email", email);
                cmdString.Parameters.AddWithValue("@StreetName", streetName);
                cmdString.Parameters.AddWithValue("@City", city);
                cmdString.Parameters.AddWithValue("@State", state);
                cmdString.Parameters.AddWithValue("@ZipCode", zipCode);
                cmdString.Parameters.AddWithValue("@Specialty1", primarySpecialty);
                cmdString.Parameters.AddWithValue("@Specialty2", secondarySpecialty);

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

        public void PhysicianRegistration(string PhysicianID, string firstName, string MiddleInitial, string lastName, string dob, string gender, string phoneNumber, string email, string streetName, string city, string state, string zip, string Specialty1, string Specialty2)
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
                    cmdString.Parameters.Add("@MiddleInitial", SqlDbType.Char, 1).Value = MiddleInitial;
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

        public bool ModifyPrescription(int rxNum, string dosage, string frequency, string medicationName, string prescriptionDate, string administrationRoute, int refillCount)
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
                cmdString.Parameters.AddWithValue("@MedicationName", string.IsNullOrEmpty(medicationName) ? (object)DBNull.Value : medicationName);
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
                cmdString.Connection = myConn;
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

        public int GetNextPatientID()
        {
            int nextID = 1;

            try
            {
                myConn.Open();
                cmdString.Parameters.Clear();
                cmdString.Connection = myConn;
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandText = "GetNextPatientID";

                object result = cmdString.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    nextID = Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error retrieving patient list: " + ex.Message);
            }
            finally
            {
                myConn.Close();
            }
            return nextID;
        }
        public int GetNextPhysicianID()
        {
            int nextID = 1;

            try
            {
                myConn.Open();
                cmdString.Parameters.Clear();
                cmdString.Connection = myConn;
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandText = "GetNextPhysicianID";

                object result = cmdString.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    nextID = Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error retrieving physician list: " + ex.Message);
            }
            finally
            {
                myConn.Close();
            }
            return nextID;
        }
        public DataSet SearchPatients(string patientID, string firstName, string lastName)
        {
            try
            {
                myConn.Open();
                cmdString.Parameters.Clear();
                cmdString.Connection = myConn;
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandText = "SearchPatients";
                cmdString.Parameters.AddWithValue("@PatientID", string.IsNullOrEmpty(patientID) ? (object)DBNull.Value : patientID);
                cmdString.Parameters.AddWithValue("@FirstName", string.IsNullOrEmpty(firstName) ? (object)DBNull.Value : firstName);
                cmdString.Parameters.AddWithValue("@LastName", string.IsNullOrEmpty(lastName) ? (object)DBNull.Value : lastName);

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

        public DataSet SearchPhysicians(string physicianID, string firstName, string lastName)
        {
            try
            {
                myConn.Open();
                cmdString.Parameters.Clear();
                cmdString.Connection = myConn;
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandText = "SearchPhysicians";
                cmdString.Parameters.AddWithValue("@PhysicianID", string.IsNullOrEmpty(physicianID) ? (object)DBNull.Value : physicianID);
                cmdString.Parameters.AddWithValue("@FirstName", string.IsNullOrEmpty(firstName) ? (object)DBNull.Value : firstName);
                cmdString.Parameters.AddWithValue("@LastName", string.IsNullOrEmpty(lastName) ? (object)DBNull.Value : lastName);

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

        public DataSet ListPrescriptionsByPatient(string patientID)
        {
            try
            {
                myConn.Open();
                cmdString.Parameters.Clear();
                cmdString.Connection = myConn;
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandText = "ListPrescriptionsByPatient";
                cmdString.Parameters.AddWithValue("@PatientID", patientID);

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

        public DataSet ListPrescriptionsByPatientInfo(string fname, string lname, string dob)
        {
            try
            {
                myConn.Open();
                cmdString.Parameters.Clear();
                cmdString.Connection = myConn;
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandText = "ListPrescriptionsByPatientInfo";
                cmdString.Parameters.AddWithValue("@FirstName", string.IsNullOrEmpty(fname) ? DBNull.Value : (object)fname);
                cmdString.Parameters.AddWithValue("@LastName", string.IsNullOrEmpty(lname) ? DBNull.Value : (object)lname);
                cmdString.Parameters.AddWithValue("@DOB", string.IsNullOrEmpty(dob) ? DBNull.Value : (object)dob);

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
        public DataSet ListPhysicians()
        {
            try
            {
                myConn.Open();
                cmdString.Parameters.Clear();
                cmdString.Connection = myConn;
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

                cmdString.Connection = myConn;
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

        public void AddPrescription(string patientid, string physicianID, string medicationName, string dosage, string frequency, string AdministrationRoute, int refillcount)
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
                cmdString.Parameters.AddWithValue("@MedicationName", medicationName);
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

        public DataSet GetPhysicianIDs()
        {
            try
            {
                myConn.Open();
                cmdString.Parameters.Clear();
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
                cmdString.CommandText = "GetPhysicianIDs";

                SqlDataAdapter da = new SqlDataAdapter(cmdString);
                DataSet ds = new DataSet();
                da.Fill(ds);

                return ds;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error retrieving physician IDs: " + ex.Message);
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

        public DataTable GetPrescriptions(string patientID, string firstName, string lastName, string dob, string sortColumn, string sortDirection)
        {
            try
            {
                myConn.Open();
                cmdString.Parameters.Clear();
                cmdString.CommandType = CommandType.StoredProcedure;
                cmdString.CommandTimeout = 1500;
                cmdString.CommandText = "GetPrescriptions";

                cmdString.Parameters.AddWithValue("@PatientID", string.IsNullOrEmpty(patientID) ? (object)DBNull.Value : patientID);
                cmdString.Parameters.AddWithValue("@FirstName", string.IsNullOrEmpty(firstName) ? (object)DBNull.Value : firstName);
                cmdString.Parameters.AddWithValue("@LastName", string.IsNullOrEmpty(lastName) ? (object)DBNull.Value : lastName);
                cmdString.Parameters.AddWithValue("@DOB", string.IsNullOrEmpty(dob) ? (object)DBNull.Value : dob);
                cmdString.Parameters.AddWithValue("@SortColumn", sortColumn);
                cmdString.Parameters.AddWithValue("@SortDirection", sortDirection);

                SqlDataAdapter da = new SqlDataAdapter(cmdString);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
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
        public bool AddRefill(int RXNum)
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

                return true;
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
        public bool SubtractRefill(int RXNum)
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
                return true;
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