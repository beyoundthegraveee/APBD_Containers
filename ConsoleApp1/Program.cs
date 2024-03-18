// See https://aka.ms/new-console-template for more information


class Program
{
    static void Main(String[] args)
    {
        
        Console.WriteLine("Select the container: ContainersForLiquids, ");


    }
}


public abstract class Container
{
    
    public static int CountOfContainers { get; private set; } = 0;
    protected int weight { get; }

    protected double height { get; }
    

    protected TypeOfContainer _typeOfContainer { get; }

    protected int weightOfContainer { get; }

    protected double depth { get;}

    protected double MaxPayload { get; }

    protected String number { get; }

    protected Container(int weight, double height, TypeOfContainer typeOfContainer, int weightOfContainer, double depth, double maxPayload, string number)
    {
        this.weight = weight;
        this.height = height;
        _typeOfContainer = typeOfContainer;
        this.weightOfContainer = weightOfContainer;
        this.depth = depth;
        MaxPayload = maxPayload;
        this.number = number;
        CountOfContainers++;
    }


    public virtual void Emptying()
    {

    }


    public virtual void Loading()
    {
        if (weight > MaxPayload)
        {
            throw new OverfillException("Masa ładunku jest większa niż pojemność danego kontenera");
        }

    }

}

public enum TypeOfContainer
{
    ColdContrainers,
    ContainersForLiquids,
    ContrainersForGas
}

public class OverfillException : Exception
{
    public OverfillException(string message) : base(message) { }
}

class ContainersForLiquids : Container,IHazardNotifier
{
    private String typeOfItem;
    

    public ContainersForLiquids(int weight, double height, TypeOfContainer typeOfContainer, int weightOfContainer, double depth, double maxPayload, string number, string typeOfItem) : base(weight, height, typeOfContainer, weightOfContainer, depth, maxPayload, number)
    {
        this.typeOfItem = typeOfItem;
    }

    public override void Loading()
    {
        base.Loading();
        if (typeOfItem.Equals("paliwo"))
        {
            
        }
        else
        {
            
        }
        
    }
    
    public void NotifyDanger(string containerNumber)
    {
        throw new NotImplementedException("Niebiezpieczna sytuacja w kontenerze: " + containerNumber);
    }
    
}

interface IHazardNotifier
{
    void NotifyDanger(string containerNumber);
    
}

class ContrainersForGas : Container
{
    public ContrainersForGas(int weight, double height, TypeOfContainer typeOfContainer, int weightOfContainer, double depth, double maxPayload, string number) : base(weight, height, typeOfContainer, weightOfContainer, depth, maxPayload, number)
    {
        
    }
}

class ColdContrainers : Container
{
    public ColdContrainers(int weight, double height, TypeOfContainer typeOfContainer, int weightOfContainer, double depth, double maxPayload, string number) : base(weight, height, typeOfContainer, weightOfContainer, depth, maxPayload, number)
    {
        
    }
}