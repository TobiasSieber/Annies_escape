//! The Decision class stores a unique ID, description, decisionCall, decisionFamily.
//! All values are stored as uint since we won't handle huge numbers. Furthermore, we don't provide any setters, as we are not interested in manipulating choices made.
namespace Decision
{
    public class Decision
    {
        //! Unique ID of the decision.
        private uint _decisionID;

        //! Description of the decision.
        private string _decisionDescription;

        //! Follow-up text associated with the decision.
        private string _followText;

        //! Timeout value for the decision.
        private float _timeoutVal;

        //! Boolean flag indicating whether the decision triggers an outcome.
        private bool _triggerOut;

        //! Call ID representing the sequence or context of the decision.
        private uint _decisionCall;

        //! Family ID categorizing the decision within a decision family.
        private uint _decisionFamily;

        //! Requirement item needed to make the decision.
        private AllItems _requirment;

        //! Reward item received upon making the decision.
        private AllItems _reward;

        // Public properties for JSON deserialization
        //! Public getter for decision ID.
        public uint DecisionID { get { return _decisionID; } }

        //! Public getter for decision description.
        public string DecisionDescription { get { return _decisionDescription; } }

        //! Public getter for follow-up text.
        public string DecisionFollowtext { get { return _followText; } }

        //! Public getter for timeout value.
        public float DecisiontimeoutVal { get { return _timeoutVal; } }

        //! Public getter for trigger outcome flag.
        public bool DecisiontriggerOut { get { return _triggerOut; } }

        //! Public getter for required item.
        public AllItems Decisionrequirment { get { return _requirment; } }

        //! Public getter for reward item.
        public AllItems Decisionreward { get { return _reward; } }

        //! Public getter for decision call ID.
        public uint DecisionCall { get { return _decisionCall; } }

        //! Public getter for decision family ID.
        public uint DecisionFamily { get { return _decisionFamily; } }

        //! Constructs a Decision object, ensuring a valid decisionID within range.
        /*!
            \param decisionID Unique identifier for the decision.
            \param decisionDescription Text description of the decision.
            \param followText Follow-up text associated with the decision.
            \param timeoutVal Float value representing timeout.
            \param triggerOut Boolean value indicating if the decision triggers an outcome.
            \param decisionCall Call ID for sequence/context.
            \param decisionFamily Family ID for grouping decisions.
            \param requirment Required item for the decision.
            \param reward Reward item received upon decision.
        */
        public Decision(uint decisionID, string decisionDescription, string followText, float timeoutVal, bool triggerOut, uint decisionCall, uint decisionFamily, AllItems requirment, AllItems reward)
        {
            if (decisionID < 1 || decisionID > 1000)
            {
                throw new System.ArgumentOutOfRangeException(nameof(decisionID), "Decision ID must be between 1 and 1000.");
            }

            this._decisionID = decisionID;
            this._decisionDescription = decisionDescription;
            this._followText = followText;
            this._timeoutVal = timeoutVal;
            this._triggerOut = triggerOut;
            this._decisionCall = decisionCall;
            this._decisionFamily = decisionFamily;
            this._requirment = requirment;
            this._reward = reward;
        }

        //! Returns the unique decision ID.
        public uint GetDecisionID() { return this._decisionID; }

        //! Returns whether the decision triggers an outcome.
        public bool GetTriggerOut() { return this._triggerOut; }

        //! Returns the description of the decision.
        public string GetdecisionDescription() { return this._decisionDescription; }

        //! Returns the call ID of the decision.
        public uint GetdecisionCall() { return this._decisionCall; }

        //! Returns the reward item associated with the decision.
        public AllItems GetReward() { return this._reward; }

        //! Returns the follow-up text for the decision.
        public string GetFollowText() { return this._followText; }

        //! Returns the timeout value for the decision.
        public float GetTimeOutVal() { return this._timeoutVal; }

        //! Returns the required item for the decision.
        public AllItems GetRequirment() { return this._requirment; }

        //! Returns the family ID of the decision.
        public uint GetDecisionFamily() { return this._decisionFamily; }
    }
}
