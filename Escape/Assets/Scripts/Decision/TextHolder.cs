using System.Collections.Generic;

/// \class TextHolder
/// \brief Abstract class for all classes which handle decisions
public abstract class TextHolder
{
     
        public abstract void AddDecision(Decision.Decision d);
        public abstract Decision.Decision GetDecision(uint decisionID);
        public abstract int Size();

        //!Generate a storage instanz via a singleton pattern,we use a singleton pattern since we only allow one object of the class storage to exist at a time



}
