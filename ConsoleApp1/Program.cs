// See https://aka.ms/new-console-template for more information


using System.Linq.Expressions;

class Program
{
    static void Main(String[] args)
    {

        List<List<Container>> ships = new List<List<Container>>();

        List<Container> ship = new List<Container>();
        
        ships.Add(ship);

        while (true)
        {
            Console.WriteLine("Select the option:\n[1] Container for liquid\n" +
                              "[2] Container for gas \n" +
                              "[3] Cold container\n" +
                              "[4] Show all containers\n" +
                              "[5] Loading a list of containers onto the ship\n"+
                              "[6] Unload and remove containers\n"+
                              "[7] Replacing a container with another container\n"+
                              "[8] Show information about the selected container\n"+
                              "[9] Move a container from one ship to another\n"+
                              "[10] Show all ships\n"+
                              "[11] Exit");

            string input = Console.ReadLine();

            if (int.TryParse(input, out int number))
            {
                switch (number)
                {
                    case 1:
                        AddLiquidContainer();
                        Console.WriteLine("The current container has been added to the ship");
                        break;
                    case 2:
                        AddGasContainer();
                        Console.WriteLine("The current container has been added to the ship");
                        break;
                    case 3:
                        AddColdContainer();
                        Console.WriteLine("The current container has been added to the ship");
                        break;
                    case 4:
                        if (ship.Count == 0)
                        {
                            Console.WriteLine("List is empty.");
                        }
                        foreach (var container in ship)
                        {
                            Console.WriteLine(container.ToString());
                        }
                        break;
                    case 5:
                        Console.WriteLine("Select the type of containers:\n" +
                                          "[1] Container for liquid\n"+
                                          "[2] Container for gas \n"+
                                          "[3] Cold container");
                        string ch = Console.ReadLine();
                        Console.WriteLine("How many containers do you want to create?");
                        string containers = Console.ReadLine();
                        int.TryParse(containers, out int nums);
                        switch (ch)
                        {
                            case "1":
                                Console.WriteLine("Enter the item for your shipment:");
                                string item = Console.ReadLine();
                                Console.WriteLine("Enter the weight of your shipment in kg:");
                                string num = Console.ReadLine();
                                int.TryParse(num, out int weightOfItem);
                                for (int i = 0; i < nums; i++)
                                {
                                    ContainersForLiquids containersForLiquids = new ContainersForLiquids(200,
                                        weightOfItem,
                                        TypeOfContainer.A,
                                        50, 140, 95, item);
                                    ship.Add(containersForLiquids);
                                }
                                Console.WriteLine(nums + " Containers were loaded and added to the ship.");
                                break;
                            case "2":
                                Console.WriteLine("Enter the item for your shipment:");
                                string item1 = Console.ReadLine();
                                Console.WriteLine("Enter the weight of your shipment in kg:");
                                string num1 = Console.ReadLine();
                                int.TryParse(num1, out int weightOfItem1);
                                Console.WriteLine("Enter the atmospheric pressure of the gas :");
                                string tmp = Console.ReadLine();
                                int.TryParse(tmp, out int pressure);
                                for (int i = 0; i < nums; i++)
                                {
                                    ContrainersForGas contrainersForGas = new ContrainersForGas(250, weightOfItem1,
                                        TypeOfContainer.B,
                                        70, 200, pressure, 80, item1);
                                    ship.Add(contrainersForGas);
                                }
                                Console.WriteLine(nums + " Containers were loaded and added to the ship.");
                                break;
                            case "3":
                                Console.WriteLine("Enter the item for your shipment:");
                                string item2 = Console.ReadLine();
                                Console.WriteLine("Enter the weight of your shipment in kg:");
                                string num2 = Console.ReadLine();
                                int.TryParse(num2, out int weightOfItem2);
                                Console.WriteLine("Enter the temperature required in the container :");
                                string count = Console.ReadLine();
                                double.TryParse(count, out double temperature);
                                for (int i = 0; i < nums; i++)
                                {
                                    ColdContrainers coldContrainers = new ColdContrainers(170, weightOfItem2,
                                        TypeOfContainer.C,
                                        65, 100, temperature, 90, item2);
                                    ship.Add(coldContrainers);
                                }
                                Console.WriteLine(nums + " Containers were loaded and added to the ship.");
                                break;
                        }
                        break;
                    case 6:
                        Console.WriteLine("Choose option:\n"+
                                          "[1] Unload and remove all containers\n"+
                                          "[2] Unload and delete the selected container");
                        string temp = Console.ReadLine();
                        switch (temp)
                        {
                            case "1":
                                DeleteAllContainers();
                                break;
                            case "2":
                                DeleteSelectedContainer();
                                break;
                        }
                        break;
                    
                    case 7:
                        ChangeContainer();
                        break;
                    
                    case 8:
                        ShowInfContainer();
                        break;
                    
                    case 9:
                        List<Container> list = CreateNewShip();
                        if (list == null)
                        {
                            break;
                        }
                        MoveContainersBetweenShips(list);
                        break;
                    case 10:
                        ShowAllShips();
                        break;
                    case 11:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }



            }
            else
            {
                Console.WriteLine("Incorrect input format.");
            }
        }

        void AddLiquidContainer()
        {
            Console.WriteLine("Enter the item for your shipment:");
            string item = Console.ReadLine();
            Console.WriteLine("Enter the weight of your shipment in kg:");
            string num = Console.ReadLine();
            int.TryParse(num, out int weightOfItem);
            ContainersForLiquids containersForLiquids = new ContainersForLiquids(200, weightOfItem,
                TypeOfContainer.A,
                50, 140, 95, item);
            containersForLiquids.Loading();
            ship.Add(containersForLiquids);
        }

        void AddGasContainer()
        {
            Console.WriteLine("Enter the item for your shipment:");
            string item1 = Console.ReadLine();
            Console.WriteLine("Enter the weight of your shipment in kg:");
            string num1 = Console.ReadLine();
            int.TryParse(num1, out int weightOfItem1);
            Console.WriteLine("Enter the atmospheric pressure of the gas :");
            string tmp = Console.ReadLine();
            int.TryParse(tmp, out int pressure);
            ContrainersForGas contrainersForGas = new ContrainersForGas(250, weightOfItem1,
                TypeOfContainer.B,
                70, 200, pressure, 80, item1);
            contrainersForGas.Loading();
            ship.Add(contrainersForGas);
        }

        void AddColdContainer()
        {
            Console.WriteLine("Enter the item for your shipment:");
            string item2 = Console.ReadLine();
            Console.WriteLine("Enter the weight of your shipment in kg:");
            string num2 = Console.ReadLine();
            int.TryParse(num2, out int weightOfItem2);
            Console.WriteLine("Enter the temperature required in the container :");
            string count = Console.ReadLine();
            double.TryParse(count, out double temperature);
            ColdContrainers coldContrainers = new ColdContrainers(170, weightOfItem2, TypeOfContainer.C,
                65, 100, temperature, 90, item2);
            coldContrainers.Loading();
            ship.Add(coldContrainers);
        }

        void DeleteAllContainers()
        {
            ship.Clear();
            Console.WriteLine("All containers have been unloaded and removed.");
            
        }

        void DeleteSelectedContainer()
        {
            List<Container> shipCopy = new List<Container>(ship);
            Console.WriteLine("Enter the container type and number with separator [,]: ");
            string line = Console.ReadLine();
            string[] parts = line.Split(",");
            string tmp = "KON-" + parts[0] + "-" + parts[1];
            foreach (Container container in shipCopy)
            { 
                if (tmp.Equals(container.number))
                {
                    container.Emptying();
                    ship.Remove(container);
                }
            }
            shipCopy.Clear();
        }

        void ChangeContainer()
        {
            if (ship.Count == 0)
            {
                Console.WriteLine("The ship is empty");
                return ;
            }
            List<Container> shipCopy = new List<Container>(ship);
            Console.WriteLine("Enter the type and number of the container you want to change with a separator [,]");
            string line = Console.ReadLine();
            string[] parts = line.Split(",");
            string tmp = "KON-" + parts[0] + "-" + parts[1];
            bool found = false;
            foreach (var container in shipCopy)
            {
                if (tmp.Equals(container.number))
                {
                    found = true;
                    ship.Remove(container);
                }
                
            }
            if (found == false)
            {
                Console.WriteLine("No such container exists.");
            }
            else
            {
                Console.WriteLine("Select a new container:\n"+
                                  "[1] Container for liquid\n"+
                                  "[2] Container for gas \n"+
                                  "[3] Cold container");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddLiquidContainer();
                        break;
                    case "2":
                        AddGasContainer();
                        break;
                    case "3":
                        AddColdContainer();
                        break;
                }
                
            }
            
            shipCopy.Clear();
            
            
        }

        void ShowInfContainer()
        {
            if (ship.Count == 0)
            {
                Console.WriteLine("The ship is empty");
                return ;
            }
            Console.WriteLine("Enter the container type and number with separator [,]: ");
            string line = Console.ReadLine();
            string[] parts = line.Split(",");
            string tmp = "KON-" + parts[0] + "-" + parts[1];
            foreach (var container in ship)
            {
                if (tmp.Equals(container.number))
                {
                    Console.WriteLine(container.ToString());
                }
            }
            
        }

        List<Container> CreateNewShip()
        {
            if (ship.Count == 0)
            {
                Console.WriteLine("It is not possible to create a new ship without filling in the original ship");
                return null;
            }

            if (ships.Count == 2)
            {
                Console.WriteLine("You can create no more than two ships");
                return null;
            }
            
                List<Container> newShip = new List<Container>();
                ships.Add(newShip);
                Console.WriteLine("The new ship was created");
                return newShip;
            
        }

        void MoveContainersBetweenShips(List<Container> newShip)
        {
            if (ships.Count < 2)
            {
                Console.WriteLine("You must have a minimum of 2 Ships to move the container.");
                
            }

            ships.Remove(ship);
            ships.Remove(newShip);
            Console.WriteLine("Enter the container type and number with separator [,]: ");
            string line = Console.ReadLine();
            string[] parts = line.Split(",");
            string tmp = "KON-" + parts[0] + "-" + parts[1];
            Container containerToMove = ship.Find(container => container.number.Equals(tmp));
            if (containerToMove != null)
            {
                ship.Remove(containerToMove);
                newShip.Add(containerToMove);
                Console.WriteLine("The container was transferred to the new ship");
            }
            else
            {
                Console.WriteLine("No such container exists.");
            }
            ships.Add(ship);
            ships.Add(newShip);
            
        }

        void ShowAllShips()
        {
            if (ships.Count == 1)
            {
                Console.WriteLine("You must have a minimum of 2 Ships to move the container");
                return;
            }
            for (int i = 0; i < ships.Count; i++)
            {
                Console.WriteLine("Ship " + i);
                foreach (var container in ships[i])
                {
                    Console.WriteLine(container.ToString());
                }
                Console.WriteLine();
            }
            
        }


    }
}


public abstract class Container
{
    
    public static int CountOfContainers { get; private set; } = 0;
    protected int weight { get; set; }

    protected int height { get; set; }


    protected TypeOfContainer _typeOfContainer { get; set; }

    protected int weightOfContainer { get; set; }

    protected double depth { get; set; }

    protected double MaxPayload { get; set; }

    public string number { get; set; }

    protected string typeOfItem { get; set; }

    protected Container(int height,int weight, TypeOfContainer typeOfContainer, int weightOfContainer, int depth, int maxPayload, string typeOfItem)
    {
        this.weight = weight;
        this.height = height;
        this.typeOfItem = typeOfItem;
        _typeOfContainer = typeOfContainer;
        this.weightOfContainer = weightOfContainer;
        this.depth = depth;
        MaxPayload = maxPayload;
        number = "KON"+"-"+_typeOfContainer+"-"+CountOfContainers;
        CountOfContainers++;
    }
    


    public virtual void Emptying()
    {
        for (int i = 0; i <= 100; i+=10)
        {
            Console.WriteLine("Please wait, the container's getting thin ..." + i +"%");
            Thread.Sleep(500);
            
        }
        
        Console.WriteLine("Container unloaded");

    }


    public virtual void Loading()
    {
        if (weight > MaxPayload)
        {
            throw new OverfillException("The cargo mass exceeds the capacity of the container.");
        }

    }


    public override string ToString()
    {
        return $"{nameof(weight)}: {weight}, {nameof(height)}: {height}, {nameof(_typeOfContainer)}: {_typeOfContainer}, {nameof(weightOfContainer)}: {weightOfContainer}, {nameof(depth)}: {depth}, {nameof(MaxPayload)}: {MaxPayload}, {nameof(number)}: {number}, {nameof(typeOfItem)}: {typeOfItem}";
    }
}

public enum TypeOfContainer
{
    A,
    B,
    C
}

public class OverfillException : Exception
{
    public OverfillException(string message) : base(message) { }
}

class ContainersForLiquids : Container,IHazardNotifier
{
    
    
    public ContainersForLiquids(int height, int weight, TypeOfContainer typeOfContainer, int weightOfContainer, int depth, int maxPayload,string typeOfItem) : base(height, weight, typeOfContainer, weightOfContainer, depth, maxPayload,typeOfItem)
    {
        this.height = height;
        this.weight = weight;
        this.weightOfContainer = weightOfContainer;
        _typeOfContainer = typeOfContainer;
        this.typeOfItem = typeOfItem;
        this.depth = depth;
        MaxPayload = MaxPayload;
        Console.WriteLine("The liquid container was created. Number is: " + base.number);
    }


    

    public override void Loading()
    {
        base.Loading();
        
        
        if (typeOfItem.Equals("paliwo"))
        {
            for (int i = 0; i <= 50; i+=10)
            {
                Console.WriteLine("Please wait the container is being loaded ..." + i + "%");
                Thread.Sleep(500);
            }
            Console.WriteLine("The container is loaded");
        }
        else
        {
            for (int i = 0; i <= 90; i+=10)
            {
                Console.WriteLine("Please wait the container is being loaded ..." + i + "%");
                Thread.Sleep(500);
            }
            Console.WriteLine("The container is loaded");
        }
        
    }

    

    public void NotifyDanger(string containerNumber)
    {
        throw new NotImplementedException("Dangerous situation in the container: " + containerNumber);
    }
    
}

interface IHazardNotifier
{
    void NotifyDanger(string containerNumber);
    
}

class ContrainersForGas : Container, IHazardNotifier
{
    
    public int Pressure { get; }
    
    public ContrainersForGas(int height, int weight, TypeOfContainer typeOfContainer, int weightOfContainer, int depth,int pressure, int maxPayload, string typeOfItem) : base(height, weight, typeOfContainer, weightOfContainer, depth, maxPayload, typeOfItem)
    {
        this.height = height;
        Pressure = pressure;
        this.weight = weight;
        _typeOfContainer = typeOfContainer;
        this.weightOfContainer = weightOfContainer;
        this.depth = depth;
        MaxPayload = maxPayload;
        this.typeOfItem = typeOfItem;
        Console.WriteLine("The gas container was created. Number is: " + base.number);
    }

    public override void Emptying()
    {
        for (int i = 0; i < 95; i+=5)
        {
            Console.WriteLine("Please wait, the container's getting thin ..." + i +"%");
            Thread.Sleep(500);
            
            
        }
        Console.WriteLine("The container is unloaded");
        
    }
    
    

    public override void Loading()
    {
        base.Loading();
        for (int i = 0; i <= 100; i+=10)
        {
            Console.WriteLine("Please wait the container is being loaded ..." + i + "%");
            Thread.Sleep(500);
        }
        Console.WriteLine("The container is loaded");
        
    }

    public void NotifyDanger(string containerNumber)
    {
        throw new NotImplementedException();
    }
}

class ColdContrainers : Container
{

    public double temperature;

    private Dictionary<string, double> dictionary = new Dictionary<string, double>()
    {
        {"Bananas", 13.3},
        {"Chocolate", 18},
        {"Fish", 2},
        {"Meat",-15},
        {"Ice cream", -18},
        {"Frozen pizza", -30},
        {"Cheese", 7.2},
        {"Sausages", 5},
        {"Butter", 20.5},
        {"Eggs", 19}
    };
    
    public ColdContrainers(int height, int weight, TypeOfContainer typeOfContainer, int weightOfContainer, int depth,double temperature, int maxPayload, string typeOfItem) : base(height, weight, typeOfContainer, weightOfContainer, depth, maxPayload, typeOfItem)
    {
        this.height = height;
        this.weight = weight;
        this.temperature = temperature;
        _typeOfContainer = typeOfContainer;
        this.weightOfContainer = weightOfContainer;
        this.depth = depth;
        MaxPayload = maxPayload;
        this.typeOfItem = typeOfItem;
        Console.WriteLine("The cold container was created. Number is: " + base.number);
    }

    public override void Loading()
    {
        if (!dictionary.ContainsKey(typeOfItem))
        {
            Console.WriteLine("You can't load the container with these products.");
        }
        else
        {
            double value = dictionary[typeOfItem];
            if (temperature != value)
            {
                Console.WriteLine("You can't store this product at this temperature");
            }
        }
        base.Loading();
        for (int i = 0; i <= 100; i+=10)
        {
            Console.WriteLine("Please wait the container is being loaded ..." + i + "%");
            Thread.Sleep(500);
        }
        Console.WriteLine("The container is loaded");
        
    }

    public override void Emptying()
    {
        base.Emptying();
    }
}