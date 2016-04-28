namespace ODataSample.Models
{

    using System.Linq;

    public interface ISampleService
    {
        IQueryable<Person> People { get; }
    }

}