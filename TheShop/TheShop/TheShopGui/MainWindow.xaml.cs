using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Dapper;
using Npgsql;
using System.Collections.ObjectModel;
namespace TheShopGui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Store> ListOfStores = new List<Store>();
        
        List<Inventory> ListOfInventories = new List<Inventory>();
        
        ObservableCollection<Store> storeList;
        ObservableCollection<Inventory> InventoryLList;

        List<Store> storeslist = new List<Store>();
        List<Inventory> invlist = new List<Inventory>();

        public MainWindow()
        {
            InitializeComponent();
            ListOfStores = GetStoresFromDatabase();
            ListOfInventories = GetInventoriesFromDatabase();
            storeList = new ObservableCollection<Store>(ListOfStores);
            InventoryLList = new ObservableCollection<Inventory>(ListOfInventories);
            dgridStoresInCity.ItemsSource = storeList;
            dgridInventory.ItemsSource = InventoryLList;
            
        }

        private List<Inventory> GetInventoriesFromDatabase()
        {
            List<Inventory> inventories;
            string connectionStringInv = "Server=127.0.0.1;Port=5432;Database=shopDb;User Id=postgres;Password=admin;";
            
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionStringInv))
            {
                string selectFromDatabase = $"SELECT storename, productname, quantity, date, unitcost FROM shop.inventory; ";

                inventories = connection.Query<Inventory>(selectFromDatabase).AsList();
                foreach (Inventory i in inventories)
                {
                    Console.Write(i.StoreName + ",");
                    Console.Write(i.ProductName + ",");
                    Console.Write(i.Quantity + ",");
                    Console.Write(i.Date + ",");
                    Console.Write(i.UnitCost + "\n");

                }
            }

            return inventories;
        }

        private List<Store> GetStoresFromDatabase()
        {
            List<Store> stores;
            string connectionStringcity = "Server=127.0.0.1;Port=5432;Database=shopDb;User Id=postgres;Password=admin;";
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionStringcity))
            {
                string selectFromDatabase = $"SELECT nameofcity, storename, address FROM shop.stores; ";
                stores = connection.Query<Store>(selectFromDatabase).AsList();
                foreach (Store s in stores)
                {
                    Console.Write(s.NameOfCity + ",");
                    Console.Write(s.StoreName + ",");
                    Console.Write(s.Address + "\n");

                }

            }
            
            return stores;
        }

        public void btnAddNewStore_Click(object sender, RoutedEventArgs e)
        {
            Store addNewStoreTemp = new Store(tfCityName.Text, tfStoreName.Text, tfStoreAddress.Text);
            storeslist.Add(addNewStoreTemp);
        }

        private void btnFinishStoreAdding_Click(object sender, RoutedEventArgs e)
        {

            foreach (Store s in storeslist)
            {
                string connectionString = "Server=127.0.0.1;Port=5432;Database=shopDb;User Id=postgres;Password=admin;";
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    string insertIntoStores = $"INSERT INTO shop.stores(nameofcity, storename, address)VALUES('{s.NameOfCity}','{s.StoreName}','{s.Address}');";
                    connection.Execute(insertIntoStores);
                }
            }

            
        }
       

        private void btnAddNewInventoryItem_Click(object sender, RoutedEventArgs e)
        {
            
            Inventory inventory = new Inventory(tfStoreName2.Text, tfProductName.Text, Int32.Parse(tfQuantity.Text), DateTime.Now,tfunitcost.Text);
            invlist.Add(inventory); 
        }

        private void btnFinishInventoring_Click(object sender, RoutedEventArgs e)
        {
            foreach (Inventory i in invlist)
            {
                string connectionString = "Server=127.0.0.1;Port=5432;Database=shopDb;User Id=postgres;Password=admin;";
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    string insertIntoInventory = $"INSERT INTO shop.inventory(storename, productname, quantity, date, unitcost)VALUES('{i.StoreName}', '{i.ProductName}', '{i.Quantity}','{DateTime.Now}', '{i.UnitCost}');";
                    connection.Execute(insertIntoInventory);
                }
            }

            
            
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dgridStoresInCity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void tfunitcost_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
