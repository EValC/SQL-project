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
        const string _ConnectionString = "Server=localhost;Database=Assignment1;Integrated Security=SSPI;";
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
        public static List<PersonPhoneAddress> SearchCustomers(string name, string family, string email)
        {
            List<PersonPhoneAddress> persons = new List<PersonPhoneAddress>();
            PersonPhoneAddress person;


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


            return neareststores;
        }

        #endregion
    }
}
