using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryClient.mvvm
{
    public class MainViewModel : BindableBase
    {
        public User ForAddUser { get; private set; } = new User();


        public string UserId { get; set; }
        public string ids { get; set; }

        public DelegateCommand AddUserCommand { get; }

        public DelegateCommand AddOrderCommand { get; }

        public List<User> Users { get; private set; }
        public List<Book> Books { get; private set; }
        public List<Orders> Orders { get; private set; }

        public MainViewModel()
        {
            using (mydbContext db = new mydbContext())
            {
                // получаем объекты из бд и выводим на консоль
                Users = db.User.ToList();
                Books = db.Book.ToList();
                Orders = db.Orders.ToList();
             
            }

            AddOrderCommand = new DelegateCommand(AddOrder);
            AddUserCommand = new DelegateCommand(AddUser);
        }

        private void AddOrder()
        {
            using (mydbContext db = new mydbContext())
            {
                
            }
        }
    

        private void AddUser()
        {
            try
            {
                using (mydbContext db = new mydbContext())
                {

                    db.User.Add(ForAddUser);
                    Users.Add(ForAddUser);
                    db.SaveChanges();
                    ForAddUser = new User(); 
                }
            }
            catch(Exception e)
            {

            }
           
        }
    }
}
