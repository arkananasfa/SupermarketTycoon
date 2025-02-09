using System.Collections.Generic;

public interface IImprovable
{

    public int Level { get; set; } 
    public float Price { get; }
    public int MaxLevel { get; }
    public List<(object, object, object)> DescriptionParameters { get; }

    public void Improve() => Level++;

    public List<(object, object, object)> GetDescriptionParameters()
    {
        List<(object, object, object)> parameters = new();
        if (Level != MaxLevel)
            parameters.Add(("Level", Level, Level+1));
        parameters.AddRange(DescriptionParameters);
        return parameters;
    }

}