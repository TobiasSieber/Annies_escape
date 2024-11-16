

namespace Text_Scripts
{
    public class Text 
    {
        private uint _ttextID;
        private string _ttextDescription;
    
        // Public properties for JSON deserialization
        public uint DecisionID { get { return _ttextID; } }
        public string DecisionDescription { get { return _ttextDescription; } }
  
        public Text(uint ttextID, string ttextDescription)
        {
            //!The Decision object stores all relevant information to identifie a decision
            this._ttextID = ttextID;
            this._ttextDescription = ttextDescription;

        }

    
        public uint GetDecisionID()
        {
            //! returns the decisionID as a int
            return this._ttextID;
        } 

        public string GetdecisionDescription()
        {
            //! returns the decision description as a string
            return this._ttextDescription;
        }

 
    }
}
