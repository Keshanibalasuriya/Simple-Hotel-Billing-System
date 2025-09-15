using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HotelBillingSystem
{
    public partial class AddCustomer : Form
    {
        public AddCustomer()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Iroom room = null;
            string roomType = null;
            int no = CustomerList.GetNextCustomerNo();

            if (checkBox1.Checked)
            {
                room = new StandardRoom();
                roomType = "Standard";
            }
            else if (checkBox3.Checked)
            {
                room = new DoubleRoom();
                roomType = "Double";
            }
            else if (checkBox2.Checked) { 
                room = new DeluxeRoom();
                roomType = "Deluxe";
            }


            //Taking Values From text boxes
            string name = textBox1.Text;
            double barLoungeCharge = double.Parse(textBox2.Text);
            double restaurantCharge = double.Parse(textBox3.Text);
            double wellnessCharge = double.Parse(textBox4.Text);
            double airPortPickupCharge = double.Parse(textBox5.Text);

            //Passing them To deco's
            room = new BarLongueDecorator(room, barLoungeCharge);
            room = new RestaurantDecorator(room ,restaurantCharge);
            room = new WellnessDecorator(room, wellnessCharge);
            room = new AirPortPickupDecorator(room , airPortPickupCharge);

            double netPayment = room.getPrice();

            /* MessageBox.Show(

                 name + roomType + barLoungeCharge + restaurantCharge + wellnessCharge + wellnessCharge + airPortPickupCharge

                 ); */

            CustomerList customerList = new CustomerList();

            Customer customer = new Customer
            {
                No =  Convert.ToString(no),
                Name = name,
                checkInDate = DateTime.Today,
                RoomType = roomType,
                BarLoungeCharge = barLoungeCharge,
                RestaurantCharges = restaurantCharge,
                WellnessCharges = wellnessCharge,
                AirportPickupCharges = airPortPickupCharge,
                NetPaymentCharges = netPayment
            };

            CustomerList.AddCustomer(customer);

           // MessageBox.Show("Added");


            this.Hide();
            CheckOut checkOut = new CheckOut();
            checkOut.ShowDialog();




        }

        private void Standerd_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();

        }
    }

    public interface Iroom {
        string getDescription();

        double getPrice();

    }

    public class StandardRoom : Iroom {
        public string getDescription() {
            return "Standerd";
        }
     public double getPrice() {
            return 15000;
          }
    }

    public class DoubleRoom : Iroom {
        public string getDescription() {
            return "Double";
        }

        public double getPrice() {
            return 30000;
        }
    }

    public class DeluxeRoom : Iroom
    {
        public string getDescription()
        {
            return "Deluxe";
        }
        public double getPrice()
        {
            return 30000;
        }

    }


    //Decorator class
    public class RoomDecorator : Iroom {

        protected Iroom room;

        public RoomDecorator(Iroom room) {
            this.room = room;
        }

        public virtual string getDescription() => room.getDescription();
        public virtual double getPrice ()=> room.getPrice();
    }

    //Concrete decorator classes
    public class BarLongueDecorator : RoomDecorator
    {
        private double price;

        public BarLongueDecorator(Iroom room, double price) :base(room){
            this.price= price;
        }

        public override string getDescription() => room.getDescription() + "Bar Lounge Added";
        public override double getPrice() => room.getPrice() + 5000;
    }


    public class RestaurantDecorator : RoomDecorator {
        private double price;

        public RestaurantDecorator(Iroom room,double price) : base(room)
        {
            this.price = price;
        }
        public override string getDescription() => room.getDescription() + "Restaurant added";
        public override double getPrice () => room.getPrice() + price;
    }

    public class WellnessDecorator : RoomDecorator
    {
        private double price;

        public WellnessDecorator(Iroom room, double price) : base(room)
        {
            this.price = price;
        }
        public override string getDescription() => room.getDescription() + "Wellness charge added";
        public override double getPrice() => room.getPrice() + price;
    }
    public class AirPortPickupDecorator : RoomDecorator
    {
        private double price;

        public AirPortPickupDecorator(Iroom room, double price) : base(room)
        {
            this.price = price;
        }
        public override string getDescription() => room.getDescription() + "AirPortPickup charge added";
        public override double getPrice() => room.getPrice() + price;
    }

    
}
