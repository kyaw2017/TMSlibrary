using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMSLibrary.Class;

namespace TMSLibrary.Factory
{ 

    public class Client
    {
        private AbstractCreditor _Creditor;
        private AbstractDebtor _Debtor;
        private AbstractLocation _Location;

        // Constructor
        public Client(TMSFactory factory)
        {
            _Creditor = factory.CreateCreditor();
            _Debtor = factory.CreateDebtor();
            _Location = factory.CreateLocation();
        }

        public AbstractCreditor ClientCreditor {
            get { return _Creditor; }
        }

        public AbstractDebtor ClientDebtor
        {
            get { return _Debtor; }
        }

        public AbstractLocation ClientLocation
        {
            get { return _Location; }
        }

    } 

public abstract class TMSFactory
    {
        public abstract AbstractCreditor CreateCreditor();
        public abstract AbstractDebtor CreateDebtor();
        public abstract AbstractLocation CreateLocation();
    }

    /// <summary>
    /// The 'ConcreteFactory1' class
    /// </summary>
    public class UserFactory : TMSFactory
    {
        public override AbstractCreditor CreateCreditor()
        {
            return new Creditor();
        }
        public override AbstractDebtor CreateDebtor()
        {
            return new Debtor();
        }
        public override AbstractLocation CreateLocation()
        {
            return new Location();
        }
    }
    
    /// <summary>
    /// The 'Client' class 
    /// </summary>
    //class AnimalWorld
    //{
    //    private User _User; 

    //    // Constructor
    //    public AnimalWorld(TMSFactory factory)
    //    { 
    //        _User = factory.CreateUser();
    //    }

    //    public void RunFoodChain()
    //    {
    //        _carnivore.Eat(_User);
    //    }
    //}
}
