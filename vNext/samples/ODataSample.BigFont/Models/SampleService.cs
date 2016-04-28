namespace ODataSample.Models
{
    using System.Linq;

    public class SampleService : ISampleService
    {
        public IQueryable<Person> People { get; }
    }
}

