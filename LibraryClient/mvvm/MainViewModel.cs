using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryClient.mvvm
{
    public class MainViewModel : BindableBase
    {

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
        }
    }
}
