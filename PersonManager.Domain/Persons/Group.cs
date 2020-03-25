using PersonManager.Tools.Domain;
using System.Collections.Generic;

namespace PersonManager.Domain.Persons
{
    public class Group : AggregateRoot
    {
        public string Name { get; private set; }
        public ICollection<Person> Persons { get; private set; }

        private Group()
        { }

        public static Group New(string name)
        {
            var group = new Group
            {
                Name = name
            };

            group.New();

            return group;
        }

        public Group WithId(int id)
        {
            Id = id;

            return this;
        }

        public void AddPerson(Person person)
        {
            if (Persons == null)
            {
                Persons = new List<Person>();
            }

            Persons.Add(person);
        }
    }
}
