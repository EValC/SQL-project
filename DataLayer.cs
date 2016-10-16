using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Assignment.Object_Classes;
using Assignment.ViewModelClasses;
using System.Windows;

namespace Assignment
{
    class DataLayer
    {
        //Alter Database name
        const string _ConnectionString = "Server=EshVal\\MYSQL;Database=Assignment1;Integrated Security=SSPI;";
        private static SqlConnection _Connection;

        #region Connections
        private static bool Connect()
        {
            //Initialzing the connecion object
            if (_Connection == null)
                _Connection = new SqlConnection(_ConnectionString);

            //checking th state of connection -> close/open
            if (_Connection.State == System.Data.ConnectionState.Open)
                return true;

                //not connected
            else
            {
                // trying to get connected
                try
                {
                    _Connection.Open();
                    return true;
                }
                catch (Exception ex) { return false; }
            }
        }

        private bool Disconnect()
        {
            if (_Connection == null)
                return true;

            else if (_Connection.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    _Connection.Close();
                    return true;
                }
                catch (Exception ex) { return false; }
            }
            //Connection is already closed
            else
                return true;
        }
        #endregion

       
        #region Persons
    
        /*
        #####################################################################
        Q1
                        person._Person._PERSONCODE
                        person._Person._ADDRESSCODE
                        person._Person._FIRSTNAME
                        person._Person._LASTNAME
                        person._Person._EMAIL
                        person._Person._DOB

                        person._Address._ADDRESSCODE
                        person._Address._STREET_NO
                        person._Address._STREET_ADDRESS
                        person._Address._CITY
                        person._Address._STATE
                        person._Address._ZIP
                        person._Address._X
                        person._Address._Y

                        person._Phone._PERSONCODE
                        person._Phone._PHONENUMBER
                        person._Phone._TYPE
        #####################################################################
         */
        public static List<PersonPhoneAddress> SearchPersons(string name, string family, string email)
        {
            List<PersonPhoneAddress> persons = new List<PersonPhoneAddress>();
            PersonPhoneAddress person;

            if (Connect())
            {
                using (SqlCommand sqlCommand = new SqlCommand("Q1", _Connection))
                {

                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "sp_SearchPersons";
                    sqlCommand.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
                    sqlCommand.Parameters.Add("@family", SqlDbType.VarChar).Value = family;
                    sqlCommand.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                    SqlDataReader reader;
                    try
                    {
                        reader = sqlCommand.ExecuteReader();
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                    while (reader.Read())
                    {
                        person = new PersonPhoneAddress();
                        person._Person._PERSONCODE=Convert.ToInt32(reader[0]);
                        person._Person._ADDRESSCODE=Convert.ToInt32(reader[1]);
                        person._Person._FIRSTNAME=Convert.ToString(reader[2]);
                        person._Person._LASTNAME=Convert.ToString(reader[3]);
                        person._Person._EMAIL=Convert.ToString(reader[4]);
                        person._Person._DOB=Convert.ToString(reader[5]);

                        person._Address._ADDRESSCODE=Convert.ToInt32(reader[1]);
                        person._Address._STREET_NO=Convert.ToString(reader[6]);
                        person._Address._STREET_ADDRESS=Convert.ToString(reader[7]);
                        person._Address._CITY=Convert.ToString(reader[8]);
                        person._Address._ZIP=Convert.ToString(reader[9]);
                        person._Address._X=Convert.ToString(reader[10]);
                        person._Address._Y=Convert.ToString(reader[11]);

                        person._Phone._PERSONCODE=Convert.ToInt32(reader[0]);
                        person._Phone._PHONENUMBER=Convert.ToString(reader[12]);
                        person._Phone._TYPE = Convert.ToString(reader[13]);
                        persons.Add(person); 
                    }
                    reader.Close();
                 
                }
            }
            else
                return null;


            return persons;
        }


        /*
        #####################################################################
         Q2
                        customerCity._City
                        customerCity._Quantity
        #####################################################################
         */
        public static List<CustomersCities> GetCustomersCities()
        {
            List<CustomersCities> customerCities = new List<CustomersCities>();
            CustomersCities customerCity;
            if (Connect())
            {
                using (SqlCommand sqlCommand = new SqlCommand("Q2", _Connection))
                {

                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "sp_GetPersonsCities";
                    SqlDataReader reader;
                    try
                    {
                        reader = sqlCommand.ExecuteReader();
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                    while (reader.Read())
                    {
                        customerCity = new CustomersCities();
                        customerCity._City = Convert.ToString(reader[0]);
                        customerCity._Quantity = Convert.ToInt32(reader[1]);
                        customerCities.Add(customerCity);
                    }
                    reader.Close();
                }


            }
            else
                return null;


            return customerCities;  
        }


        /*
       #####################################################################
        Q3
                       cityBOD._MinDOB
                       cityBOD._MaxDOB
       #####################################################################
        */
        public static List<CityBOD> GetCityDOB(string city)
        {
            List<CityBOD> cityBODs = new List<CityBOD>();
            CityBOD cityBOD;
            if (Connect())
            {
                using (SqlCommand sqlCommand = new SqlCommand("Q3", _Connection))
                {

                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "sp_GetCustomersCities";
                    sqlCommand.Parameters.Add("@city", SqlDbType.VarChar).Value = city;
                    SqlDataReader reader;
                    try
                    {
                        reader = sqlCommand.ExecuteReader();
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                    while (reader.Read())
                    {
                        cityBOD = new CityBOD();
                        cityBOD._MinDOB = Convert.ToString(reader[0]);
                        cityBOD._MaxDOB = Convert.ToString(reader[1]);
                        cityBODs.Add(cityBOD);
                    }
                    reader.Close();
                   
                }
            }
            else
                return null;
            return cityBODs;
        }

        #endregion Persons

        #region Items

        /*
        #####################################################################
        Q4
                        item._Item._ITEMCODE
                        item._Item._NAME
                        item._Item._BRAND
                        item._Item._PRICE 
                        item._Item._DESCRIPTION
        #####################################################################
         */
        public static List<ItemPhoto> SearchItems(string name, string brand)
        {
            List<ItemPhoto> items = new List<ItemPhoto>();
            ItemPhoto item;

            if (Connect())
            {
                using (SqlCommand sqlCommand = new SqlCommand("Q4", _Connection))
                {

                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "SearchItems";
                    sqlCommand.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
                    sqlCommand.Parameters.Add("@brand", SqlDbType.VarChar).Value = brand;
                    SqlDataReader reader;
                    try
                    {
                        reader = sqlCommand.ExecuteReader();
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                    while (reader.Read())
                    {
                        item = new ItemPhoto();
                        item._Item._ITEMCODE=Convert.ToInt32(reader[0]);
                        item._Item._NAME=Convert.ToString(reader[1]);
                        item._Item._BRAND=Convert.ToString(reader[2]);
                        item._Item._PRICE =Convert.ToInt32(reader[3]);
                        item._Item._DESCRIPTION = Convert.ToString(reader[4]);
                        items.Add(item);
                    }
                    reader.Close();

                }
            }
            

            return items;
        }


        /*
        #####################################################################
        Q5
                        itemStoreSold._ITEMCODE
                        itemStoreSold._STORECODE
                        itemStoreSold._SOLD
        #####################################################################
         */
        public static List<ItemStoreSold> GetItemsStoresSold()
        {
            List<ItemStoreSold> itemStoreSolds = new List<ItemStoreSold>();
            ItemStoreSold itemStoreSold;
            if (Connect())
            {
                using (SqlCommand sqlCommand = new SqlCommand("Q5", _Connection))
                {

                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "GetItemsStoresSold";
                   
                    SqlDataReader reader;
                    try
                    {
                        reader = sqlCommand.ExecuteReader();
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                    while (reader.Read())
                    {
                        itemStoreSold = new ItemStoreSold();
                        itemStoreSold._STORECODE = Convert.ToInt32(reader[0]);
                        itemStoreSold._ITEMCODE=Convert.ToInt32(reader[1]);
                       itemStoreSold._SOLD = Convert.ToInt32(reader[2]);

                        itemStoreSolds.Add(itemStoreSold);
                    }
                    reader.Close();

                }
            }
            

            return itemStoreSolds;
        }

        /*
        #####################################################################
        Q6
                        existsIn._STORECODE
                        existsIn._ITEMCODE
                        existsIn._QUANTITY
        #####################################################################
         */
        public static List<Exists_In> FindRunnuingOutItems()
        {
            List<Exists_In> existIns = new List<Exists_In>();
            Exists_In existsIn;
            if (Connect())
            {
                using (SqlCommand sqlCommand = new SqlCommand("Q6", _Connection))
                {

                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "sp_FindRunnuingOutItems";

                    SqlDataReader reader;
                    try
                    {
                        reader = sqlCommand.ExecuteReader();
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                    while(reader.Read())
                    {
                        existsIn= new Exists_In();
                        existsIn._STORECODE = Convert.ToInt32(reader[0]);
                        existsIn._ITEMCODE=Convert.ToInt32(reader[1]);
                        existsIn._QUANTITY = Convert.ToInt32(reader[2]);
                        existIns.Add(existsIn);
                    }
                    reader.Close();

                }
            }

            return existIns;
        }


        /*
        #####################################################################
        Q7
                        bestSeller._ItemName
                        bestSeller._Quantity
        #####################################################################
         */
        public static Best_Seller GetBestSeller()
        {
            Best_Seller bestSeller = new Best_Seller();
            if (Connect())
            {
                using (SqlCommand sqlCommand = new SqlCommand("Q7", _Connection))
                {

                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "sp_GetBestSeller";

                    SqlDataReader reader;
                    try
                    {
                        reader = sqlCommand.ExecuteReader();
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                    while (reader.Read())
                    {
                        bestSeller = new Best_Seller();
                        bestSeller._ItemName=Convert.ToString(reader[0]);
                        bestSeller._Quantity = Convert.ToInt32(reader[1]);
                     }
                    reader.Close();

                }
            }

            return bestSeller;

        }


        /*
        #####################################################################
        Q8
                        mostPopular._Brand
                        mostPopular._Quantity
        #####################################################################
         */
        public static Most_Popular GetMostPopular()
        {
            Most_Popular mostPopular = new Most_Popular();
            if (Connect())
            {
                using (SqlCommand sqlCommand = new SqlCommand("Q8", _Connection))
                {

                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "sp_GetMostPopular";

                    SqlDataReader reader;
                    try
                    {
                        reader = sqlCommand.ExecuteReader();
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                    while (reader.Read())
                    {
                        mostPopular=new Most_Popular();
                         mostPopular._Brand=Convert.ToString(reader[0]);
                        mostPopular._Quantity=Convert.ToInt32(reader[1]);


                    }
                    reader.Close();
                
                }
            }

            return mostPopular;
        }

        #endregion //Items

        #region Transactions

        /*
        #####################################################################
        Q9
                        transactionPerson._Transaction._TRANSACTIONCODE
                        transactionPerson._FirstName
                        transactionPerson._LastName
                        transactionPerson._Transaction._STORECODE
                        transactionPerson._Transaction._TRANSACTION_DATE
                        transactionPerson._Transaction._PAYMENT_METHOD
        #####################################################################
         */
        public static List<TransactionPerson> SearchTransactions(string personFamily, string paymentMethod)
        {
            List<TransactionPerson> transactionsPersons = new List<TransactionPerson>();
            TransactionPerson transactionPerson;
            if (Connect())
            {
                using (SqlCommand sqlCommand = new SqlCommand("Q9", _Connection))
                {

                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "sp_SearchTransactions";
                    sqlCommand.Parameters.Add("@family", SqlDbType.VarChar).Value =personFamily;
                    sqlCommand.Parameters.Add("@paymentmethod", SqlDbType.VarChar).Value =paymentMethod ;
                    SqlDataReader reader;
                    try
                    {
                        reader = sqlCommand.ExecuteReader();
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                    while (reader.Read())
                    {
                        transactionPerson = new TransactionPerson();
                        transactionPerson._Transaction._TRANSACTIONCODE=Convert.ToInt32(reader[0]);
                        transactionPerson._FirstName=Convert.ToString(reader[1]);
                        transactionPerson._LastName=Convert.ToString(reader[2]);
                        transactionPerson._Transaction._STORECODE=Convert.ToInt32(reader[3]);
                        transactionPerson._Transaction._TRANSACTION_DATE=Convert.ToDateTime(reader[4]);
                        transactionPerson._Transaction._PAYMENT_METHOD = Convert.ToString(reader[5]);
                        transactionsPersons.Add(transactionPerson);
                    }
                    reader.Close();

                }
            }

            return transactionsPersons;
        }

        /*
        #####################################################################
        Q10
                        itemInclude._Item._NAME
                        itemInclude._Quantity
                        itemInclude._Item._PRICE
                        itemInclude._Total
        #####################################################################
         */
        public static List<Item_Include> GetItemDeatils(int transactionCode)
        {
            List<Item_Include> itemsIncludes = new List<Item_Include>();
            Item_Include itemInclude;
            if (Connect())
            {
                using (SqlCommand sqlCommand = new SqlCommand("Q10", _Connection))
                {

                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "sp_GetItemDeatils";
                    sqlCommand.Parameters.Add("@transactioncode", SqlDbType.VarChar).Value = transactionCode;
                    SqlDataReader reader;
                    try
                    {
                        reader = sqlCommand.ExecuteReader();
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                    while (reader.Read())
                    {
                       itemInclude  = new Item_Include();
                         itemInclude._Item._NAME=Convert.ToString(reader[0]);
                        itemInclude._Quantity=Convert.ToInt32(reader[1]);
                        itemInclude._Item._PRICE=Convert.ToInt32(reader[2]);
                        itemInclude._Total = Convert.ToInt32(reader[3]);
                        itemsIncludes.Add(itemInclude);


                    }
                    reader.Close();

                }
            }

            return itemsIncludes;
        }

        /*
        #####################################################################
        Q11
                        transactionCity._City
                        transactionCity._Quantity
        #####################################################################
        */
        public static List<TransactionsCities> TransactionsCities()
        {
            List<TransactionsCities> transactionsCities = new List<TransactionsCities>();
            TransactionsCities transactionCity;
            if (Connect())
            {
                using (SqlCommand sqlCommand = new SqlCommand("Q11", _Connection))
                {

                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "sp_TransactionsCities";
                   // sqlCommand.Parameters.Add("@transactioncode", SqlDbType.VarChar).Value = transactionCode;
                    SqlDataReader reader;
                    try
                    {
                        reader = sqlCommand.ExecuteReader();
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                    while (reader.Read())
                    {
                        transactionCity = new TransactionsCities();
                        transactionCity._City=Convert.ToString(reader[0]);
                        transactionCity._Quantity = Convert.ToInt32(reader[1]);
                        transactionsCities.Add(transactionCity);


                    }
                    reader.Close();

                }
            }
            
                    return transactionsCities;
        }

        #endregion Transactions
       
       
        #region Map

        /*
        #####################################################################
        Q12
                        storeLocation._STORECODE
                        storeLocation._Distance
                        storeLocation._X
                        storeLocation._Y
        #####################################################################
        */

        public static List<StoreDistance> FindNearestStore(double X, double Y)
        {
            List<StoreDistance> neareststores = new List<StoreDistance>();
            StoreDistance storeLocation;
            if (Connect())
            {
                using (SqlCommand sqlCommand = new SqlCommand("Q12", _Connection))
                {

                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "SP_FindNearestStore";
                    sqlCommand.Parameters.Add("@X", SqlDbType.VarChar).Value = X;
                    sqlCommand.Parameters.Add("@Y", SqlDbType.VarChar).Value = Y;
                    SqlDataReader reader;
                    try
                    {
                        reader = sqlCommand.ExecuteReader();
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                    while (reader.Read())
                    {
                        storeLocation=new StoreDistance();
                        storeLocation._STORECODE=Convert.ToInt32(reader[0]);
                        storeLocation._Distance=Convert.ToString(reader[1]);
                        storeLocation._X=Convert.ToInt32(reader[2]);
                        storeLocation._Y = Convert.ToInt32(reader[3]);
                        neareststores.Add(storeLocation);
                    }
                    reader.Close();

                }
            }
            
                    return neareststores;
        }


        /*
        #####################################################################
        Q13
                        storeLocation._STORECODE
                        storeLocation._Distance
                        storeLocation._X
                        storeLocation._Y
        #####################################################################
        */
        public static List<StoreDistance> FindStoresInRange(double X, double Y, int range)
        {
            List<StoreDistance> neareststores = new List<StoreDistance>();
            StoreDistance storeLocation;
            if (Connect())
            {
                using (SqlCommand sqlCommand = new SqlCommand("Q13", _Connection))
                {

                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "sp_FindStoresInRange";
                    sqlCommand.Parameters.Add("@X", SqlDbType.VarChar).Value = X;
                    sqlCommand.Parameters.Add("@Y", SqlDbType.VarChar).Value = Y;
                    sqlCommand.Parameters.Add("@RANGE", SqlDbType.VarChar).Value = range;
                    SqlDataReader reader;
                    try
                    {
                        reader = sqlCommand.ExecuteReader();
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                    while (reader.Read())
                    {
                        storeLocation = new StoreDistance();
                        storeLocation._STORECODE = Convert.ToInt32(reader[0]);
                        storeLocation._Distance = Convert.ToString(reader[1]);
                        storeLocation._X = Convert.ToInt32(reader[2]);
                        storeLocation._Y = Convert.ToInt32(reader[3]);
                        neareststores.Add(storeLocation);
                    }
                    reader.Close();

                }
            }
            
            return neareststores;
        }

        #endregion
    }
}
