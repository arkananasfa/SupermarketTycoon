using System.Collections.Generic;

public interface IImprovable
{

    public int Level { get; set; } 
    public float Price { get; }
    public int MaxLevel { get; }
    public List<(object, object, object)> DescriptionParameters { get; }

    public void Improve() => Level++;

}