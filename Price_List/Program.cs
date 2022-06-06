using System;

namespace PriceList
{
    abstract class Device
    {
        protected string name;
        protected string producer;
        protected string model;
        protected int quantity;
        protected float price;

        public Device() { }
        protected Device(string name, string producer, string model, int quantity, float price)
        {
            this.name = name;
            this.producer = producer;
            this.model = model;
            this.quantity = quantity;
            this.price = price;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Producer
        {
            get { return producer; }
            set { producer = value; }
        }
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        public float Price
        {
            get { return price; }
            set { price = value; }
        }
        public virtual void Print()
        {
            Console.WriteLine("Print info abt Device: ");
            Console.WriteLine("Device name: " + this.name);
            Console.WriteLine("Producer: " + this.producer);
            Console.WriteLine("Model: " + this.model);
            Console.WriteLine("Quantity: " + this.quantity);
            Console.WriteLine("Price: " + this.price);
        }
        public virtual void Loading()
        {
            Console.WriteLine("Loading from file");
        }
        public virtual void Save()
        {
            Console.WriteLine("Save to file");
        }
    }

    class Flash : Device
    {
        float memory;
        float usbspeed;

        public Flash() { }
        public Flash(string name, string producer, string model, int quantity, float price, float memory, float usbspeed)
            : base(name, producer, model, quantity, price)
        {
            this.Memory = memory;
            this.USBspeed = usbspeed;
        }

        public Flash(string name, string producer, string model) : this()
        {
            this.name = name;
            this.producer = producer;
            this.model = model;
        }
        public float Memory
        {
            get { return memory; }
            set { memory = value; }
        }
        public float USBspeed
        {
            get { return usbspeed; }
            set { usbspeed = value; }
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine("Flash memory volume: " + memory);
            Console.WriteLine("USB 2.0 speed: " + usbspeed);
        }
        public override void Loading()
        {
            Console.WriteLine("Loading from file to Flesh memory");
        }
        public override void Save()
        {
            Console.WriteLine("Save to file to Flash memory");
        }
        internal void AddFlash(string name, string producer, string model, int quantity, int price, float memory, float usbspeed)
        {
            throw new NotImplementedException();
        }
    }

    class HDD : Device
    {
        float size;
        float usbspeed;

        public HDD() { }
        public HDD(string name, string producer, string model, int quantity, float price, float size, float usbspeed)
            : base(name, producer, model, quantity, price)
        {
            this.size = size;
            this.usbspeed = usbspeed;
        }
        public HDD(string name, string producer, string model) : this()
        {
            this.name = name;
            this.producer = producer;
            this.model = model;
        }
        public float Size
        {
            get { return size; }
            set { size = value; }
        }
        public float USBspeed
        {
            get { return usbspeed; }
            set { usbspeed = value; }
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine("Size of HDD disc: " + size);
            Console.WriteLine("USB 2.0 speed: " + usbspeed);
        }
        public override void Loading()
        {
            Console.WriteLine("Loading from file to HDD disc");
        }
        public override void Save()
        {
            Console.WriteLine("Save to file to HDD disc");
        }
    }

    class DVD : Device
    {
        float readspeed;
        float writespeed;

        public DVD() { }
        public DVD(string name, string producer, string model, int quantity, float price, float readspeed, float writespeed)
            : base(name, producer, model, quantity, price)
        {
            this.readspeed = readspeed;
            this.writespeed = writespeed;
        }
        public DVD(string name, string producer, string model) : this()
        {
            this.name = name;
            this.producer = producer;
            this.model = model;
        }
        public float Readspeed
        {
            get { return readspeed; }
            set { readspeed = value; }
        }
        public float Writespeed
        {
            get { return writespeed; }
            set { writespeed = value; }
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine("Reading Speed: " + readspeed);
            Console.WriteLine("Writing Speed: " + writespeed);
        }
        public override void Loading()
        {
            Console.WriteLine("Loading (read) from file from DVD disc");
        }
        public override void Save()
        {
            Console.WriteLine("Save (write) to file to DVD disc");
        }
    }


    class Shop
    {
        static Random rnd = new Random();
        private List<Device> list = new List<Device>();

        public int Price { get; private set; }

        public void PrintList()
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i] + "\n");
                list[i].Print();
                Console.WriteLine();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var device = new List<Device>();
            device.Add(new Flash("Flash memory", "Apacer Technology", "AH333", 10, 296, 32, 450));
            device.Add(new HDD("HDD", "Seagate", "BarraCuda", 5, 1749, 2000, 7200));
            device.Add(new DVD("DVD", "Verbatim", "DVD-RW", 50, 32, 2, 1));
            device.Add(new Flash("Flash memory", "Kingston", "DataTraveler 100 G3", 15, 300, 32, 425));
            device.Add(new HDD("HDD", "Western Digital", "Red Pro", 5, 13012, 10000, 7200));
            device.Add(new DVD("DVD", "Lider", "DVD-RW", 100, 27, 2, 1));

            for (int i = 0; i < device.Count; i++)
            {
                device[i].Print();
            }

        }
    }
}
