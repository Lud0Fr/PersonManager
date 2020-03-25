using PersonManager.Tools.Domain;

namespace PersonManager.Domain.Persons
{
    public class Person : Entity
    {
        public string Name { get; private set; }
        public int GroupId { get; private set; }
        public virtual Group Group { get; private set; }

        private Person()
        { }

        public static Person New(
            string name,
            int groupId)
        {
            var person = new Person
            {
                Name = name,
                GroupId = groupId
            };

            person.New();

            return person;
        }

        public Person WithId(int id)
        {
            Id = id;

            return this;
        }
    }
}
